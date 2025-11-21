// AudioPlaybackTests.cs
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Tests
{
    [TestClass]
    public class AudioPlaybackTests
    {
        // Тест на правильное воспроизведение одной точки и тире
        [TestMethod]
        public async Task PlayMorseSequenceAsync_TestSingleDotAndDash()
        {
            // Arrange
            var mockPlayable = new Mock<IPlayable>();
            var player = new AudioPlayback(mockPlayable.Object);

            // Проигрываемая последовательность: одна точка и одно тире
            string morseCode = ".-";

            // Act
            await player.PlayMorseSequenceAsync(morseCode);

            // Assert
            mockPlayable.Verify(p => p.Beep(800, It.IsInRange<int>(190, 210, Moq.Range.Inclusive)), Times.Once()); // Высокая частота (точка)
            mockPlayable.Verify(p => p.Beep(600, It.IsInRange<int>(590, 610, Moq.Range.Inclusive)), Times.Once()); // Низкая частота (тире)
        }

        // Тест на правильную паузу между элементами
        [TestMethod]
        public async Task PlayMorseSequenceAsync_TestPauseBetweenSymbols()
        {
            // Arrange
            var mockPlayable = new Mock<IPlayable>();
            var player = new AudioPlayback(mockPlayable.Object);

            // Последовательность: точка, тире, пауза между ними
            string morseCode = ".-";

            // Act
            await player.PlayMorseSequenceAsync(morseCode);

            // Assert
            mockPlayable.Verify(p => p.Beep(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2)); // Два сигнала
        }

        // Тест на обработку пустых строк
        [TestMethod]
        public async Task PlayMorseSequenceAsync_EmptyString_ShouldNotPlay()
        {
            // Arrange
            var mockPlayable = new Mock<IPlayable>();
            var player = new AudioPlayback(mockPlayable.Object);

            // Акт пустой строки
            string emptyMorseCode = "";

            // Act
            await player.PlayMorseSequenceAsync(emptyMorseCode);

            // Assert
            mockPlayable.Verify(p => p.Beep(It.IsAny<int>(), It.IsAny<int>()), Times.Never()); // Не было никаких сигналов
        }

        // Тест на исключение при попытке воспроизведения после dispose
        [TestMethod]
        public async Task PlayMorseSequenceAsync_AfterDispose_ThrowsException()
        {
            // Arrange
            var mockPlayable = new Mock<IPlayable>();
            var player = new AudioPlayback(mockPlayable.Object);

            // Сначала выполняем dispose
            player.Dispose();

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ObjectDisposedException>(
                () => player.PlayMorseSequenceAsync(".") // Любая попытка воспроизведения должна выбрасывать исключение
            );
        }
    }
}
