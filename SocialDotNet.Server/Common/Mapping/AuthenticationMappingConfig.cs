using Mapster;
using SocialDotNet.Application.Authentication.Commands.Register;
using SocialDotNet.Application.Authentication.Common;
using SocialDotNet.Application.Authentication.Queries.Login;
using SocialDotNet.Contracts.Authentication;

namespace SocialDotNet.Server.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Id, src => src.User.Id.Value)
                .Map(dest => dest.FirstName, src => src.User.FirstName)
                .Map(dest => dest.LastName, src => src.User.LastName)
                .Map(dest => dest.Email, src => src.User.Email);
        }
    }
}
