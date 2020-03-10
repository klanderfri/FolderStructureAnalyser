using System;

namespace FolderStructureAnalyser.Exceptions
{
    public class UnhandledSwitchCaseException : NotImplementedException
    {
        public object UnhandledValue { get; private set; }

        public UnhandledSwitchCaseException(object unhandledValue)
            : this(unhandledValue, "The handling for the enum is not implemented.") { }

        public UnhandledSwitchCaseException(object unhandledValue, string message)
            : this(unhandledValue, message, null) { }

        public UnhandledSwitchCaseException(object unhandledValue, string message, Exception inner)
            : base(message, inner)
        {
            UnhandledValue = unhandledValue;
        }
    }
}
