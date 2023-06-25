using Entities.Exceptions.CommonExceptions;

namespace Entities.Exceptions;

public class CitiesNotFoundException : NotFoundException
{
    public CitiesNotFoundException() : base("CITIES_NOT_FOUND")
    {
    }
}