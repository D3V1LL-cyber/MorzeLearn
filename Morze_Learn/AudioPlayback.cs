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

        // Новые свойства для настройки звука
        public float Volume { get; set; } = 0.8f;
        public int BaseFrequency { get; set; } = 800;
        public float SpeedMultiplier { get; set; } = 1.0f;

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
                        await PlayBeep(GetAdjustedDuration(DotDurationMs), GetAdjustedFrequency(BaseFrequency));
                        await Task.Delay(GetAdjustedDuration(GapBetweenElementsMs));
                        break;
                    case '-':
                        await PlayBeep(GetAdjustedDuration(DashDurationMs), GetAdjustedFrequency(BaseFrequency - 200));
                        await Task.Delay(GetAdjustedDuration(GapBetweenElementsMs));
                        break;
                    case ' ':
                        // Пауза между словами
                        await Task.Delay(GetAdjustedDuration(GapBetweenWordsMs));
                        break;
                    case '/':
                        // Можно использовать '/' для разделения слов
                        await Task.Delay(GetAdjustedDuration(GapBetweenWordsMs));
                        break;
                    default:
                        // Игнорировать остальные символы
                        break;
                }
            }
        }

        private int GetAdjustedDuration(int baseDuration)
        {
            return (int)(baseDuration / SpeedMultiplier);
        }

        private int GetAdjustedFrequency(int baseFrequency)
        {
            return baseFrequency;
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
                catch (PlatformNotSupportedException)
                {
                    // Console.Beep не поддерживается на этой платформе
                    if (!_disposed)
                    {
                        PlayBeepAlternative(durationMs, frequency);
                    }
                }
                catch (Exception ex)
                {
                    // Другие ошибки Console.Beep
                    System.Diagnostics.Debug.WriteLine($"Ошибка Console.Beep: {ex.Message}");
                    if (!_disposed)
                    {
                        PlayBeepAlternative(durationMs, frequency);
                    }
                }
            });
        }

        // Альтернативный метод для воспроизведения с использованием System.Media.SoundPlayer
        private void PlayBeepAlternative(int durationMs, int frequency)
        {
            if (_disposed)
                return;

            MemoryStream stream = null;
            BinaryWriter writer = null;

            try
            {
                // Останавливаем предыдущий плеер, если он есть
                _currentPlayer?.Stop();
                _currentPlayer?.Dispose();

                // Создаем простой звуковой сигнал
                stream = new MemoryStream();
                writer = new BinaryWriter(stream);

                const int SAMPLE_RATE = 8000;
                short channels = 1;
                short bitsPerSample = 16;
                short frameSize = (short)(channels * (bitsPerSample / 8));
                int bytesPerSecond = SAMPLE_RATE * frameSize;

                // RIFF заголовок
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + (int)(durationMs * 0.001 * SAMPLE_RATE * frameSize));
                writer.Write("WAVE".ToCharArray());

                // fmt chunk
                writer.Write("fmt ".ToCharArray());
                writer.Write(16);
                writer.Write((short)1); // PCM format
                writer.Write(channels); // mono
                writer.Write(SAMPLE_RATE); // sample rate
                writer.Write(bytesPerSecond); // byte rate
                writer.Write(frameSize); // block align
                writer.Write(bitsPerSample); // bits per sample

                // data chunk
                writer.Write("data".ToCharArray());
                writer.Write((int)(durationMs * 0.001 * SAMPLE_RATE * frameSize));

                // Генерируем синусоидальную волну
                double amplitude = Volume * 32000; // Учитываем громкость
                int samples = (int)(durationMs * 0.001 * SAMPLE_RATE);

                for (int i = 0; i < samples; i++)
                {
                    if (_disposed) break;

                    double t = (double)i / SAMPLE_RATE;
                    double value = amplitude * Math.Sin(2 * Math.PI * frequency * t);
                    writer.Write((short)value);
                }

                if (!_disposed && stream.Length > 0)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    _currentPlayer = new SoundPlayer(stream);
                    _currentPlayer.PlaySync();
                }
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
            finally
            {
                // Освобождаем ресурсы
                writer?.Close();
                stream?.Close();
                writer?.Dispose();
                stream?.Dispose();
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