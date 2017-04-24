using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Contracts;
using SchoolSystem.Core;

namespace SchoolSystem.Commands
{
    public class TeacherAddMarkCommand //: ICommand
    {
        public void Execute(IList<string> parameters)
        {
            var teacherID = int.Parse(parameters[0]);
            var studentID = int.Parse(parameters[1]);
            var student = Engine.Students[studentID];
            var teacher = Engine.Teachers[teacherID];
            //return teacher.AddMark(student, float.Parse(parameters[2]));
        }
    }
}
