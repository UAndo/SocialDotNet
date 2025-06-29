﻿using ErrorOr;
using MediatR;
using SocialDotNet.Application.Authentication.Common;

namespace SocialDotNet.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
