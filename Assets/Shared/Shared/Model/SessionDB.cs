using Newtonsoft.Json;
using System;

namespace Shared.Model
{
    public class SessionKey
    {
        public long SessionServerId { get; set; }
        public long AccountServerId { get; set; }

        [JsonIgnore]
        public bool HasValue => SessionServerId != 0 && AccountServerId != 0;
    }

    public class SessionDB
    {
        public SessionKey SessionKey { get; set; }
        public DateTime LastConnect { get; set; }
        public int ConnectionTime { get; set; }
    }
}
