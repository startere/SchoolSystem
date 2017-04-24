using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Contracts;
using SchoolSystem.Core;

namespace SchoolSystem.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            if (Engine.Students[int.Parse(parameters[0])].ListMarks() == string.Empty)
            {
                return "This student has no marks.";
            }
            else
            {
                return Engine.Students[int.Parse(parameters[0])].ListMarks();
            }
        }
    }
}
