using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AlocaGFT.Utils
{
    public class CustomValidationCPFAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            return true;

            bool valido = CPFValidator.ValidaCPF(value.ToString());
            return valido;
        }

    }
}