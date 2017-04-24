using SchoolSystem.Contracts;
using SchoolSystem.Core;

namespace SchoolSystem.Models
{
    public class Teacher : Person
    {
        public Subject Subject;

        public Teacher(string firstName, string lastName, Subject subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
        }

        public string AddMark(IStudent student, float markValue)
        {
            var newMark = new Mark(this.Subject, markValue);

            Validators.NumberOfMarksValidator(student.Marks);

            student.Marks.Add(newMark);

            return $"Teacher {this.FirstName} {this.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {this.Subject}.";
        }
    }
}
