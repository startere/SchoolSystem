using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Contracts;
using SchoolSystem.Core;

namespace SchoolSystem.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            Engine.Students.Remove(int.Parse(parameters[0]));
            return $"Student with ID {int.Parse(parameters[0])} was sucessfully removed.";
        }
    }
}
