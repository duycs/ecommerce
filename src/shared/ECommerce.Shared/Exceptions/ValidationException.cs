using ECommerce.Shared.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Shared.Exceptions
{
    public class ValidationException : Exception
    {
        public IList<ValidationError> Errors { get; set; }

        public ValidationException()
        {
        }

        public ValidationException(ValidationError error)
        {
            Errors = new List<ValidationError> { error };
        }

        public ValidationException(string field, string message)
            : this(new ValidationError(field, message))
        {
        }

        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Errors = errors.ToList();
        }

        public ModelStateDictionary GetModelState(IStringLocalizer localizer)
        {
            ModelStateDictionary modelStateDictionary = new ModelStateDictionary();
            foreach (ValidationError error in Errors)
            {
                modelStateDictionary.AddModelError(error.Field, localizer[error.Message]);
            }

            return modelStateDictionary;
        }
    }
    public class ValidationError
    {
        public string Field { get; set; }

        public string Message { get; set; }

        public ValidationError(string field, string message)
        {
            Field = field?.ToCamelCasing();
            Message = message;
        }

        public ValidationError(string message)
        {
            Field = string.Empty;
            Message = message;
        }

        public override string ToString()
        {
            return "Field = " + Field + " | Message = " + Message;
        }
    }
}
