using System.Collections.Generic;
using SchoolSystem.Models;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents a Student
    /// extends a Person
    /// has a:
    /// grade,
    /// collection of marks,
    /// method for displaying those marks;
    /// </summary>
    public interface IStudent : IPerson
    {
        Grade Grade { get; set; }

        IList<IMark> Marks { get; }
        /// <summary>
        /// Generates a list of the student`s marks in a specific format.
        /// </summary>
        /// <returns>
        /// Returns string formatted as a list of marks.
        /// If there are no marks it returns appropriate error message.
        /// </returns>
        string ListMarks();

    }
}
