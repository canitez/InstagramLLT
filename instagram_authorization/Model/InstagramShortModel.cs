using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace instagram_authorization.Model
{
    public class InstagramShortModel
    {
        public string access_token { get; set; }

        public long? user_id { get; set; }
    }
}
