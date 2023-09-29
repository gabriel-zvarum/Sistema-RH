using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Validation.Base
{
    public class AbstractValidatorBase<T> : AbstractValidator<T>
    {
        public Task<ValidationResult> Validator(ValidationContext<T> context, CancellationToken cancellation)
        {
            var validate = base.ValidateAsync(context, cancellation);
            if (validate.Result.IsValid)
                return validate;
            else
            {
                throw new Exception(validate.Result.Errors.First().ToString());
            }
        }
    }
}
