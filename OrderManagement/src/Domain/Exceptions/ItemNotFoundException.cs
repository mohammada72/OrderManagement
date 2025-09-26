namespace OrderManagement.Domain.Exceptions;

public class ItemNotFoundException(string searchTerm, string objectName) 
    : Exception($"{objectName} not found with key : {searchTerm}")
{
}
