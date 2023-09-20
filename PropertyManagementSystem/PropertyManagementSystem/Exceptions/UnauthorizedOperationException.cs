namespace PropertyManagementSystem.Exceptions
{
    public class UnauthorizedOperationException : ApplicationException
    {
        public UnauthorizedOperationException(string message) 
            : base(message)
        {
            
        }
    }
}
