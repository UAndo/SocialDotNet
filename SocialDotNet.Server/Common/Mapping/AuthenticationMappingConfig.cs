using Mapster;
using SocialDotNet.Application.Authentication.Commands.Register;
using SocialDotNet.Application.Authentication.Common;
using SocialDotNet.Application.Authentication.Queries.Login;
using SocialDotNet.Application.FriendRequests.Commands.CreateFriendRequest;
using SocialDotNet.Application.FriendRequests.Queries.GetFriendRequests;
using SocialDotNet.Contracts.Authentication;
using SocialDotNet.Contracts.Friends;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

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

            config.NewConfig<CreateFriendRequest, SendFriendRequestCommand>()
                .Map(dest => dest.UserId, src => UserId.Create(src.UserId))
                .Map(dest => dest.FriendName, src => src.FriendName);

            config.NewConfig<GetFriendsRequest, GetFriendRequestsQuery>()
                .Map(dest => dest.UserId, src => UserId.Create(src.UserId));
        }
    }
}
