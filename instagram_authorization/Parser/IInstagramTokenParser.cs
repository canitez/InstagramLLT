using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace instagram_authorization.Parser
{
    public interface IInstagramTokenParser
    {
        Task<string> TokenParser(string access_token);
    }
}
