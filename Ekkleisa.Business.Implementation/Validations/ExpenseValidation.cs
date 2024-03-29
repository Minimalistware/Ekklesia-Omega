﻿using Ekklesia.Entities.DTOs;
using FluentValidation;

namespace Ekkleisa.Business.Implementation.Validations
{
    public class ExpenseValidation : AbstractValidator<ExpenseDTO>
    {
        public ExpenseValidation()
        {           

            RuleFor(e => e.Responsable).NotNull().WithMessage("Uma despesa precisa ter um responsável.");

            RuleFor(r => r.Responsable.Name).NotEmpty().When(r => r.Responsable != null).WithMessage("Uma despesa precisa ter um reponsável válido.");

            RuleFor(r => r.Responsable.Id).NotEmpty().When(r => r.Responsable != null).WithMessage("Uma despesa precisa ter um reponsável válido.");
            
        }
    }
}
