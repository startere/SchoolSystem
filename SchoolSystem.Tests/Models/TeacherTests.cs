using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using Moq;
using NUnit;
using SchoolSystem.Models;
using SchoolSystem.Contracts;

namespace SchoolSystemTests.Models
{
    /// <summary>
    /// Summary description for TeacherTests
    /// </summary>
    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void Constructor_ShouldSetSubjectProperty_WhenInitialized()
        {
            //Arrange
            var expectedSubject = Subject.Bulgarian;

            //Act
            var teacher = new Teacher("Pesho", "Peshov", expectedSubject);

            //Assert
            Assert.AreEqual(expectedSubject, teacher.Subject);
        }
        
        [TestCase("P", "Geshev")]
        [TestCase("Pesho", "P")]
        [TestCase("Peshopeshopeshopeshopeshopeshopesho", "Geshev")]
        [TestCase("Pesho", "Peshopeshopeshopeshopeshopeshopesho")]
        [TestCase("123", "Geshev")]
        [TestCase("Geshev", "123")]
        public void Constructor_ShouldThrowArgumentException_WhenInvalidFirstOrLastNamePassed(string firstName, string lastName)
        {
            //Arrange, act and assert
            Assert.Throws<FormatException>(() => new Teacher(firstName, lastName, Subject.Bulgarian));
        }

        [Test]
        public void AddMark_ShouldAddMarkToPassedStudentWhenValidMarkPassed()
        {
            //Arrange
            var expectedSubject = Subject.Bulgarian;
            var expectedValue = 6;

            var teacher = new Teacher("Pesho", "Peshev", expectedSubject);
            var student = new Mock<IStudent>();

            student.Setup(c => c.Marks).Returns(new List<IMark>());

            //Act
            teacher.AddMark(student.Object, expectedValue);

            //Assert
            Assert.AreEqual(expectedSubject, student.Object.Marks.Single().Subject);
            Assert.AreEqual(expectedValue, student.Object.Marks.Single().Value);
        }

        [Test]
        public void AddMark_ShouldThrowArgumentException_WhenAddingMoreThan20Marks()
        {
            //Arrange
            var teacher = new Teacher("Pesho", "Peshev", Subject.Bulgarian);
            var student = new Mock<IStudent>();

            var mark = new Mock<IMark>();

            var marks = Enumerable.Repeat(mark.Object, 20).ToList();

            student.Setup(c => c.Marks).Returns(marks);

            //Act and Assert
            Assert.Throws<ArgumentException>(() => teacher.AddMark(student.Object, 6));
        }

    }
}
