using System;

namespace FolderStructureAnalyser.Exceptions
{
    public class UnhandledSwitchCaseException : NotImplementedException
    {
        public Type TypeOfValue { get; private set; }
        public object UnhandledValue { get; private set; }

        public UnhandledSwitchCaseException(Type typeOfValue, object unhandledValue)
            : this(typeOfValue, unhandledValue, "The handling for the enum is not implemented.") { }

        public UnhandledSwitchCaseException(Type typeOfValue, object unhandledValue, string message)
            : this(typeOfValue, unhandledValue, message, null) { }

        public UnhandledSwitchCaseException(Type typeOfValue, object unhandledValue, string message, Exception inner)
            : base(message, inner)
        {
            TypeOfValue = typeOfValue;
            UnhandledValue = unhandledValue;
        }
    }
}
