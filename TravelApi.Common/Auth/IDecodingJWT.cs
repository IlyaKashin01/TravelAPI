using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Common.Auth
{
    public interface IDecodingJWT
    {
        string? getJWTTokenClaim(string token, string claimName);
    }
}
