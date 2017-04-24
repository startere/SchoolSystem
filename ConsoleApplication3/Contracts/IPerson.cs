namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents a Person with the basic attributes First and Last name.
    /// </summary>
    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
