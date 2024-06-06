using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDotNet.Contracts.Authentication
{
    public record RefreshTokenRequest(
        string RefreshToken);
}
