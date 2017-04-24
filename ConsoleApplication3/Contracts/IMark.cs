using SchoolSystem.Models;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents Marks students get from Teachers.
    /// contains subject and value
    /// </summary>
    public interface IMark
    {
        Subject Subject { get; set; }

        float Value { get; }
    }
}
