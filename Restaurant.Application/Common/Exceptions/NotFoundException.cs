namespace Restaurant.Application.Common.Exceptions;

public sealed class NotFoundException(string resource, object key) : Exception($"{resource} with key {key} not found.");