using Microsoft.AspNetCore.Http;

namespace Equinox.Utilities
{
    public class FilterSession
    {
        private readonly ISession _session;
        private const string ClubKey     = "Filter_ClubId";
        private const string CategoryKey = "Filter_CategoryId";

        public FilterSession(ISession session)
        {
            _session = session;
        }

        // Read/write ClubId
        public string ClubId
        {
            get => _session.GetString(ClubKey) ?? "all";
            set => _session.SetString(ClubKey, value);
        }

        // Read/write CategoryId
        public string CategoryId
        {
            get => _session.GetString(CategoryKey) ?? "all";
            set => _session.SetString(CategoryKey, value);
        }
    }
}
