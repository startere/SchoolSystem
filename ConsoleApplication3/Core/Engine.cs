using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using SchoolSystem.Contracts;
using SchoolSystem.Models;

namespace SchoolSystem.Core
{
    public class Engine
    {
        private const string TerminationCommand = "End";
        private const string NullProvidersExceptionMessageEnding = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;

        public Engine(IReader readerProvider, IWriter writerProvider, IParser parserProvider)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException($"Reader {NullProvidersExceptionMessageEnding}");
            }
            if (writerProvider == null)
            {
                throw new ArgumentNullException($"Writer {NullProvidersExceptionMessageEnding}");
            }
            if (parserProvider == null)
            {
                throw new ArgumentNullException($"Parser {NullProvidersExceptionMessageEnding}");
            }

            this.reader = readerProvider;
            this.writer = writerProvider;
            this.parser = parserProvider;

            Teachers = new Dictionary<int, ITeacher>();
            Students = new Dictionary<int, IStudent>();
        }

        public static IDictionary<int, ITeacher> Teachers { get; set; }

        public static IDictionary<int, IStudent> Students { get; set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.writer.WriteLine(executionResult);
        }
    }
}
