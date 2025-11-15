using System;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace Morze_Learn
{
    public class AudioPlayback : IDisposable
    {
        private const int DotDurationMs = 200; // Длительность точки (мс)
        private const int DashDurationMs = 600; // Длительность тире (мс)
        private const int GapBetweenElementsMs = 100; // Пауза между точкой и тире (мс)
        private const int GapBetweenLettersMs = 300; // Пауза между буквами (мс)
        private const int GapBetweenWordsMs = 700; // Пауза между словами (мс)

        private bool _disposed = false;
        private SoundPlayer _currentPlayer;

        public AudioPlayback()
        {
        }

        public async Task PlayMorseSequenceAsync(string morseCode)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(AudioPlayback));

            foreach (char ch in morseCode)
            {
                if (_disposed)
                    break;

                switch (ch)
                {
                    case '.':
                        await PlayBeep(DotDurationMs, 800); // Высокий тон для точки
                        await Task.Delay(GapBetweenElementsMs);
                        break;
                    case '-':
                        await PlayBeep(DashDurationMs, 600); // Низкий тон для тире
                        await Task.Delay(GapBetweenElementsMs);
                        break;
                    case ' ':
                        // Пауза между словами
                        await Task.Delay(GapBetweenWordsMs);
                        break;
                    case '/':
                        // Можно использовать '/' для разделения слов
                        await Task.Delay(GapBetweenWordsMs);
                        break;
                    default:
                        // Игнорировать остальные символы
                        break;
                }
            }
        }

        private async Task PlayBeep(int durationMs, int frequency)
        {
            if (_disposed)
                return;

            // Используем Console.Beep для простоты (работает в Windows)
            await Task.Run(() =>
            {
                try
                {
                    if (!_disposed)
                    {
                        Console.Beep(frequency, durationMs);
                    }
                }
                catch (Exception)
                {
                    // Если Console.Beep не поддерживается, используем альтернативный метод
                    if (!_disposed)
                    {
                        PlayBeepAlternative(durationMs);
                    }
                }
            });
        }

        // Альтернативный метод для воспроизведения с использованием System.Media.SoundPlayer
        private void PlayBeepAlternative(int durationMs)
        {
            if (_disposed)
                return;

            try
            {
                // Останавливаем предыдущий плеер, если он есть
                _currentPlayer?.Stop();
                _currentPlayer?.Dispose();

                // Создаем простой звуковой сигнал
                var stream = new MemoryStream();
                var writer = new BinaryWriter(stream);

                // RIFF заголовок
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + durationMs * 8);
                writer.Write("WAVE".ToCharArray());

                // fmt chunk
                writer.Write("fmt ".ToCharArray());
                writer.Write(16);
                writer.Write((short)1); // PCM format
                writer.Write((short)1); // mono
                writer.Write(8000); // sample rate
                writer.Write(8000); // byte rate
                writer.Write((short)1); // block align
                writer.Write((short)8); // bits per sample

                // data chunk
                writer.Write("data".ToCharArray());
                writer.Write(durationMs * 8);

                // Генерируем синусоидальную волну
                for (int i = 0; i < durationMs * 8; i++)
                {
                    if (_disposed) break;

                    double t = (double)i / 8000;
                    double frequency = 800;
                    double amplitude = 32;
                    double value = amplitude * Math.Sin(2 * Math.PI * frequency * t);
                    writer.Write((byte)(value + 128));
                }

                if (!_disposed)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    _currentPlayer = new SoundPlayer(stream);
                    _currentPlayer.PlaySync();
                }

                writer.Close();
                stream.Close();
            }
            catch (ObjectDisposedException)
            {
                // Игнорируем, если объект уже освобожден
            }
            catch (Exception ex)
            {
                // Логируем ошибку, но не прерываем выполнение
                System.Diagnostics.Debug.WriteLine($"Ошибка воспроизведения звука: {ex.Message}");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    _currentPlayer?.Stop();
                    _currentPlayer?.Dispose();
                    _currentPlayer = null;
                }

                // Освобождаем неуправляемые ресурсы (если есть)

                _disposed = true;
            }
        }

        // Финализатор на случай, если Dispose не был вызван явно
        ~AudioPlayback()
        {
            Dispose(false);
        }
    }
}
