using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Equinox.Utilities
{
    public class BookingCookies
    {
        private const string Key = "bookings";
        private readonly IRequestCookieCollection requestCookies;
        private readonly IResponseCookies responseCookies;

        public BookingCookies(IRequestCookieCollection requestCookies, IResponseCookies responseCookies)
        {
            this.requestCookies = requestCookies;
            this.responseCookies = responseCookies;
        }

        public List<int> GetBookings()
        {
            if (requestCookies.TryGetValue(Key, out string? data))
            {
                return JsonSerializer.Deserialize<List<int>>(data) ?? new List<int>();
            }

            return new List<int>();
        }

        public void SetBookings(List<int> classIds)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                IsEssential = true
            };

            string data = JsonSerializer.Serialize(classIds);
            responseCookies.Append(Key, data, options);
        }

        public void ClearBookings()
        {
            responseCookies.Delete(Key);
        }
    }
}
