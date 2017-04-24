using NUnit.Framework;
using System;
using System.Linq;
using SchoolSystem.Core;
using Moq;
using SchoolSystem.Contracts;
using SchoolSystemTests.Extensions;


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

            //Act
            engine.Start();
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        [TestCase("TeacherAddMark 0 0 3")]
        [TestCase("RemoveStudent 0")]
        [TestCase("RemoveTeacher 0")]
        public void Start_ShouldNotThrowWhenOneValidTerminationCommandPassed(string command)
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>().Object;
            var parserMock = new Mock<IParser>().Object;
            var engine = new Engine(readerMock.Object, writerMock, parserMock);

            string terminationCommand = "End";

            readerMock.SetupMany(c => c.ReadLine(), command, terminationCommand);

            //Act and Assert
            Assert.DoesNotThrow(() => engine.Start());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Start_ShouldCallWriteLineOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>().Object;
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock);

            string terminationCommand = "End";

            readerMock.SetupMany(c => c.ReadLine(), command, terminationCommand);

            //Act
            engine.Start();

            //Assert
            writerMock.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Start_ShouldCallParseCommandOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object);

            string terminationCommand = "End";

            readerMock.SetupMany(c => c.ReadLine(), command, terminationCommand);

            //Act
            engine.Start();

            //Assert
            parserMock.Verify(c => c.ParseCommand(command), Times.Once());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Start_ShouldCallParseParametersOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object);

            string terminationCommand = "End";

            readerMock.SetupMany(c => c.ReadLine(), command, terminationCommand);

            //Act
            engine.Start();

            //Assert
            parserMock.Verify(c => c.ParseParameters(command), Times.Once());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Start_ShouldExecuteProcessedCommandOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var mockedCommand = new Mock<ICommand>();
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object);

            var terminationCommand = "End";
            var commandParameters = command.Split(' ').ToList();
            commandParameters.RemoveAt(0);

            readerMock.SetupMany(c => c.ReadLine(), command, terminationCommand);
            parserMock.Setup(c => c.ParseCommand(command)).Returns(mockedCommand.Object);
            parserMock.Setup(c => c.ParseParameters(command)).Returns(commandParameters);

            //Act
            engine.Start();

            //Assert
            mockedCommand.Verify(c => c.Execute(commandParameters), Times.Once());
        }
    }
}
