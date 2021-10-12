using apirestbeam.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apirestbeam.Controllers
{
    public class EmployeValidator : AbstractValidator<Employe>
    {
        public EmployeValidator()
        {
            RuleFor(e => e.FullName)
                    .NotNull().WithMessage("'Nombre' no puede ser vacio o nulo.")
                    .NotEmpty().WithMessage("'Nombre' no puede ser vacio o nulo.")
                    .MinimumLength(3).WithMessage("'Nombre' no tiene el formato correcto");
            RuleFor(e => e.BirthDate).Must(isFullAge).WithMessage("'{PropertyName}' edad minima no valida.");
            RuleFor(e => e.Country)
                .NotNull().WithMessage("'Pais' no puede ser vacio o nulo.")
                .NotEmpty().WithMessage("'Pais' no puede ser vacio o nulo.");
            RuleFor(e => e.Country)
                .NotNull().WithMessage("'Pais' no puede ser vacio o nulo.")
                .NotEmpty().WithMessage("'Pais' no puede ser vacio o nulo.");
            RuleFor(e => e.User)
               .MinimumLength(6).WithMessage("'Usuario' debe tener minimo 6 caracteres.")
               .NotNull().WithMessage("'Usuario' no puede ser vacio o nulo.")
               .NotEmpty().WithMessage("'Usuario' no puede ser vacio o nulo.")
               .WithMessage("'Usuario' no tiene el formato correcto.");
            RuleFor(e => e.DateContracting)
                .NotNull().WithMessage("'Fecha de contratación' no puede ser vacio o nulo.")
                .NotEmpty().WithMessage("'Fecha de contratación' no puede ser vacio o nulo.");
            RuleFor(e => e.State)
                .NotNull().WithMessage("'Estado Empleado' no puede ser vacio o nulo.")
                .NotEmpty().WithMessage("'Estado Empleado' no puede ser vacio o nulo.")
                .Must(x => x >=1 && x <=3 ).WithMessage("'Estado Empleado' no valido.");


        }

        public bool isFullAge(DateTime BirthDate)
        {
            return DateTime.Now.AddYears(-18) >= BirthDate;
        }

        
    }
}
}