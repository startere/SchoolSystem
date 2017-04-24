using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchoolSystem.Core;
using SchoolSystem.Contracts;

namespace SchoolSystem.Models
{
    public class Student : Person, IStudent
    {

        public Student(string firstName, string lastName, Grade grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public Grade Grade { get; set; }

        public IList<IMark> Marks { get; set; }

        public string ListMarks()
        {
            List<string> output = new List<string>();
            string currStrArr;

            var noMarks = Validators.StudentHasNoMarksValidator(this.Marks);

            for (int i = 0; i < this.Marks.Count; i++)
            {
                currStrArr = this.Marks[i].Subject.ToString()
                             + " => " +
                             this.Marks[i].Value.ToString()
                             + "\n";
                output.Add(currStrArr);
            }

            if (noMarks != string.Empty)
            {
                return noMarks;
            }
            else
            {
                return "The student has these marks: " + string.Join("\n", output);
            }
        }
    }
}
