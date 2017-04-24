using System;
using System.Collections.Generic;
using SchoolSystem.Contracts;
using SchoolSystem.Core;
using SchoolSystem.Models;

namespace SchoolSystem.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            //Engine.Students.Add(id, new Student(parameters[0], parameters[1], (Grade)Enum.Parse(typeof(Grade), parameters[2])));
            return $"A new student with name {parameters[0]} {parameters[1]}, grade {(Grade)Enum.Parse(typeof(Grade), parameters[2])} and ID {id++} was created.";
        }
    }
}
