using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Moq;
using SchoolSystem.Models;
using SchoolSystem.Contracts;

namespace SchoolSystemTests.Models
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Constructor_ShouldSetGradePropertyWhenCalled()
        {
            var expectedGrade = Grade.Fifth;
            var student = new Student("Koko", "Kekev", expectedGrade);
            
            Assert.AreEqual(expectedGrade, student.Grade);
        }

        [Test]
        public void Constructor_ShouldSetInstanceToMarksCollection_WhenInitialized()
        {
            var student = new Student("Koko", "Kekev", Grade.First);
            var result = student.ListMarks().ToLower();
            Assert.AreNotEqual(null, student.Grade);
        }

        [Test]
        public void ListMarks_ShouldThrowError_WhenStudentHasNoMarks()
        {
            var student = new Student("Tesho", "Teshev", Grade.Eighth);

            var result = student.ListMarks().ToLower();

            Assert.That(result.Contains("no marks"));
        }

        [Test]
        public void ListMarks_ShouldListMarksWhenStudentHasMarks()
        {
            var mark = new Mock<IMark>();

            mark.Setup(m => m.Subject).Returns(Subject.Math);
            mark.Setup(m => m.Value).Returns(4);

            var student = new Student("Fresh", "Freshev", Grade.Eighth);

            student.Marks.Add(mark.Object);

            var textList = student.ListMarks().ToLower();

            Assert.That(textList.Contains("has"));
            Assert.That(textList.Contains("marks"));
            Assert.That(textList.Contains("math"));
            Assert.That(textList.Contains("4"));
        }
    }
}
