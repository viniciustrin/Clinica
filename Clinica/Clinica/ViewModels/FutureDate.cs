using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Clinica.ViewModels
{
    public class FutureDate :ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = "Data precisa ser maior que hoje."; // default message
            }

            return base.FormatErrorMessage(name);
        }
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParse(Convert.ToString(value),
                out dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
    }

    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            return (isValid);
        }
    }
} 