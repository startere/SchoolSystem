using SchoolSystem.Models;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents a Teacher
    /// extends Person
    /// has:
    /// a Subject,
    /// methods of assigning Marks to Students.
    /// </summary>
    public interface ITeacher : IPerson
    {
        Subject Subject { get; set; }

        /// <summary>
        /// Adds a mark to a given student.
        /// </summary>
        ///<param name="student">Student who will get a mark.</param>
        ///<param name="mark">Mark that the student will get.</param>
        void AddMark(IStudent student, float mark);
    }
}
