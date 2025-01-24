namespace Products.Contracts.Exceptions;

public class NotFoundException(string message) : Exception(message);