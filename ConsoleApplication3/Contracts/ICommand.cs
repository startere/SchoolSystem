using System.Collections.Generic;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents that command can be parsed by the parser.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executed command with passed parameters.
        /// </summary>
        /// <param name="commandParameters">Parameters to execute the command with.</param>
        /// <returns>Returns execution result message.</returns>
        string Execute(IList<string> commandParameters);
    }
}
