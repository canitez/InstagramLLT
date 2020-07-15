using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace instagram_authorization.Model
{
    public class InstagramLongModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; } 
        public long? expires_in { get; set; }
    }
}
