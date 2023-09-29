using Application.Core.Entities;
using Application.Core.Validation.Base;
using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Validation.Funcionarios
{
    public class CommandFuncionariosValidation : AbstractValidatorBase<FuncionarioDTO>
    {
        public override Task<ValidationResult> ValidateAsync(ValidationContext<FuncionarioDTO> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.DocFederal)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Documento Federal é obrigatório.");

            RuleFor(x => x.Idade)
                .NotNull()
                .GreaterThan(18)
                .NotEmpty()
                    .WithMessage("Funcinario deve ter Idade maior que 18.");

            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Nome é obrigatório.");

            return Validator(context, cancellation);
        }
    }
}
