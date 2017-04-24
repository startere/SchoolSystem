using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Contracts;
using SchoolSystem.Core;
using SchoolSystem.Models;

namespace SchoolSystem.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            //Engine.Teachers.Add(id, new Teacher(parameters[0], parameters[1], (Subject)Enum.Parse(typeof(Subject), parameters[2])));
            return $"A new teacher with name {parameters[0]} {parameters[1]}, subject {(Subject)Enum.Parse(typeof(Subject), parameters[2])} and ID {id++} was created.";
        }
    }
}
