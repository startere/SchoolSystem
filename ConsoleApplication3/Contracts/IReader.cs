using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Interface for a source Reader provider
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads data from a source.
        /// </summary>
        /// <returns>Returns read data as string.</returns>
        string ReadLine();
    }
}
