﻿using FluentValidation.Results;

namespace Application.Exceptions;
public class ValidationException : Exception
{
    public ValidationException() : base("One or more failures has been occurred")
    {
        Errors = new List<string>();
    }
    public List<string> Errors { get; set; }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }
}

