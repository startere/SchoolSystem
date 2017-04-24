using System;
using NUnit.Framework;
using SchoolSystem.Models;

namespace SchoolSystem.Tests.Models
{
    [TestFixture]
    public class MarkTests
    {
        [TestCase(2.5f)]
        [TestCase(2f)]
        [TestCase(6f)]
        [TestCase(5.2f)]
        public void ConstructorShouldNotThrowWhenValidValuePassed(float value)
        {
            Assert.DoesNotThrow(() => new Mark(Subject.Bulgarian, value));
        }

        [TestCase(1f)]
        [TestCase(11f)]
        [TestCase(-6f)]
        public void Constructor_ShouldThrowArgumentOutOfRange_WhenInvalidValuePassed(float value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Mark(Subject.Math, value));
        }
    }
}
