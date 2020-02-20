using System;

namespace FolderStructureAnalyser.Exceptions
{
    public class UnhandledEnumException : NotImplementedException
    {
        public Type UnhandledEnum { get; private set; }
        public object EnumValue { get; private set; }

        public UnhandledEnumException(Type unhandledEnum, object enumValue)
            : this(unhandledEnum, enumValue, "The handling for the enum is not implemented.") { }

        public UnhandledEnumException(Type unhandledEnum, object enumValue, string message)
            : this(unhandledEnum, enumValue, message, null) { }

        public UnhandledEnumException(Type unhandledEnum, object enumValue, string message, Exception inner)
            : base(message, inner)
        {
            UnhandledEnum = unhandledEnum;
            EnumValue = enumValue;
        }
    }
}
