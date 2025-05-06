using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SocialDotNet.Server.Controllers
{
    [Route("api/groups")]
    public class GroupsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public GroupsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> CreateGroup(
        //    CreateGroupRequest request,
        //    string)
        //{
        //    var command = _mapper.Map<CreateGroupCommand>(request);

        //    var createGroupResult = await _mediator.Send(command);

        //    return createGroupResult.Match(
        //        group => Ok(_mapper.Map<GroupResponse>(group)),
        //        errors => Problem(errors));
        //}
    }
}
