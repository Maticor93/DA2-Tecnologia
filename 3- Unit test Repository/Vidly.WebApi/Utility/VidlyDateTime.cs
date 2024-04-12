using System.Globalization;

namespace Vidly.WebApi.Utility
{
    public static class VidlyDateTime
    {
        public static DateTimeOffset Parse(string date)
        {
            var isParsed = DateTimeOffset.TryParseExact(
                date,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTimeOffset dateParsed);

            if (!isParsed)
            {
                throw new ArgumentException("Invalid published on");
            }

            return dateParsed;
        }
    }
}
