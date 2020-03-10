using System;

namespace FolderStructureAnalyser.Exceptions
{
    public class UnhandledSwitchCaseException : NotImplementedException
    {
        /// <summary>
        /// The value the switch-statement has no case for.
        /// </summary>
        public object UnhandledValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the FolderStructureAnalyser.Exceptions.UnhandledSwitchCaseException
        /// class with information about the value of the unhandled case.
        /// </summary>
        /// <param name="unhandledValue">The value the switch-statement has no case for.</param>
        public UnhandledSwitchCaseException(object unhandledValue)
            : this(unhandledValue, "The handling for the enum is not implemented.") { }

        /// <summary>
        /// Initializes a new instance of the FolderStructureAnalyser.Exceptions.UnhandledSwitchCaseException
        /// class with information about the value of the unhandled case and a specified error message.
        /// </summary>
        /// <param name="unhandledValue">The value the switch-statement has no case for.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public UnhandledSwitchCaseException(object unhandledValue, string message)
            : this(unhandledValue, message, null) { }

        /// <summary>
        /// Initializes a new instance of the FolderStructureAnalyser.Exceptions.UnhandledSwitchCaseException
        /// class with information about the value of the unhandled case, a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="unhandledValue">The value the switch-statement has no case for.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">
        /// The exception that is the cause of the current exception. If the inner parameter is not null,
        /// the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        public UnhandledSwitchCaseException(object unhandledValue, string message, Exception inner)
            : base(message, inner)
        {
            UnhandledValue = unhandledValue;
        }
    }
}
