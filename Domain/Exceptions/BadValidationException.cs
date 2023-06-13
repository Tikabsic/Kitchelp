namespace Domain.Exceptions
{
    public class BadValidationException : Exception
    {
        public BadValidationException(string exception) : base(exception)
        {

        }
    }
}
