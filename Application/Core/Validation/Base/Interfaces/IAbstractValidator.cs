using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Validation.Base.Interfaces
{
    public interface IAbstractValidator<T>
    {
        Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default);
        Task<ValidationResult> Validator(ValidationContext<T> context, CancellationToken cancellation = default);
    }
}
