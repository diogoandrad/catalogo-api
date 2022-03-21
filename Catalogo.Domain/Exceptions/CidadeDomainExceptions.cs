namespace Catalogo.Domain.Exceptions
{
    public class InvalidExceptions : ArgumentException
    {
        public InvalidExceptions(): base("Invalid.")
        {
        }
    }
}
