using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akanami.AspNetCore.Configurations
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecurityKey { get; set; }
    }
}
