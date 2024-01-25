namespace FirmaMeble.Data.Validators
{
    public static class BusinessValidator
    {
        public static string CheckIfNumberIsSet(int? value)
        {
            if (value < 1)
            {
                return "Liczba nie może byc zerem";
            }

            return string.Empty;
        }

        public static string CheckIfIsNotLessThanZero(decimal? value)
        {
            if (value != null)
            {
                if (value < 0)
                {
                    return "Wartość nie może być mniejsza od 0";
                }
            }

            return string.Empty;
        }

        public static string CheckDateIsNotEarlier(DateTime prev, DateTime? later)
        {
            if (prev != null && later != null)
            {
                if (prev > later)
                {
                    return "Data nie może być wcześniej niż poprzednia";
                }
            }

            return string.Empty;
        }

        public static string CheckNip(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            if (value.Length != 10)
            {
                return "Numer NIP powinien składać się z 10 cyfr.";
            }

            return string.Empty;
        }

        public static string CheckPesel(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            int length = value.Length;
            if (length != 11)
            {
                return "Numer PESEL powinien składać się z 11 cyfr.";
            }

            return string.Empty;
        }
    }
}
