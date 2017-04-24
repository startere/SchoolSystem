using NUnit.Framework;
using System;
using SchoolSystem.Core;
using Moq;
using SchoolSystem.Contracts;

namespace SchoolSystemTests.CoreTests
{
    [TestFixture]
    public class SchoolSystemTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullReaderPassed()
        {
            //Arrange
            var writerMock = new Mock<IWriter>().Object;
            var parserMock = new Mock<IParser>().Object;

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(null, writerMock, parserMock));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullWriterPassed()
        {
            //Arrange
            var readerMock = new Mock<IReader>().Object;
            var parserMock = new Mock<IParser>().Object;

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(readerMock, null, parserMock));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullParserPassed()
        {
            //Arrange
            var readerMock = new Mock<IReader>().Object;
            var writerMock = new Mock<IWriter>().Object;

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(readerMock, writerMock, null));
        }

        [Test, Timeout(2500)]
        public void EngineShouldNotFallIntoInfiniteLoopWhenValidTerminationCommandPassed()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>().Object;
            var parserMock = new Mock<IParser>().Object;
            var engine = new Engine(readerMock.Object, writerMock, parserMock);

            string terminationCommand = "End";

            readerMock.Setup(c => c.ReadLine()).Returns(terminationCommand);

            engine.Start();
        }
    }
}
