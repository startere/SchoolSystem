namespace SchoolSystem.Contracts
{
    public interface IWriter
    {
        /// <summary>
        /// Writes data to a given source.
        /// </summary>
        /// <param name="message">The information to be written.</param>
        void Write(string message);

        /// <summary>
        /// Writes data to a given source but appends a new line at the end.
        /// </summary>
        /// <param name="message">The information to be written.</param>
        void WriteLine(string message);
    }
}
