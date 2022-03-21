namespace Catalogo.Domain.Exceptions
{
    public class InvalidIdadeExceptions : ArgumentException
    {
        public InvalidIdadeExceptions(): base("Invalid age.")
        {
        }
    }
}
