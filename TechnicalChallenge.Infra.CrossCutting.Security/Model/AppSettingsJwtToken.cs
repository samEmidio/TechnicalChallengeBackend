using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Infra.CrossCutting.Security.Model
{
    public class AppSettingsJwtToken
    {
        public string Key { get; set; }
        public int Expiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
