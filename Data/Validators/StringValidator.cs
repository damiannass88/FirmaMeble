namespace FirmaMeble.Data.Validators
{
    using System.Text.RegularExpressions;

    public static class StringValidator
    {
        public static string CheckIfStartsWithUpperCase(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            if (!Char.IsUpper(value, 0))
            {
                return "Wartość musi się rozpoczynać wielką literą";
            }

            return string.Empty;
        }
        
        public static string CheckIfStringIsEmpty(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            return string.Empty;
        }

        public static string CheckEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            if (Regex.IsMatch(value, pattern))
            {
                return string.Empty;
            }

            return "Nieprawidłowy adres e-mail";
        }

        public static string CheckIsNumeric(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            const string pattern = @"^\d+$";

            if (Regex.IsMatch(value, pattern))
            {
                return string.Empty;
            }

            return "Nieprawidłowy numer telefonu";
        }
    }
}
