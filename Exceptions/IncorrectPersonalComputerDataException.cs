namespace Lab_WebAPI.Exceptions
{
    [System.Serializable]
    public class IncorrectPersonalComputerDataException : Exception
    {
        public IncorrectPersonalComputerDataException() { }
        public IncorrectPersonalComputerDataException(string message) : base(message) { }
        public IncorrectPersonalComputerDataException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectPersonalComputerDataException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
