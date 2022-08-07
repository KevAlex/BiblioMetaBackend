﻿using Application.Features.UserFeatures.Commands;
using Application.Features.UserFeatures.Queries;
using Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackBiblioMeta.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "getUser")]
        // It should return a UsuarioDTO object list
        public async Task<IEnumerable<ResponseUsuarioDto>> GetUsers()
        {
            return await _mediator.Send(new GetUserListQuery());
        }

        [HttpGet(Name = "LoginUser")]
        public async Task<IActionResult> LoginUser(string alias, string pass)
        {
            return Ok(await _mediator.Send(new GetUserByAliasPasswordQuery { Alias = alias, Password = pass }));
        }

        [HttpPost(Name = "postUser")]
        public async Task<IActionResult> CreateUser(AddUsuarioCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
