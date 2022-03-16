﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LawnHolder.Domain.DTOs.Authentication;
using LawnHolder.Web.Areas.Api.Models;
using System.Threading.Tasks;
using LawnHolder.Infrastructure.Authentication.Services;


namespace LawnHolder.Web.Areas.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Produces("application/json")]
[Area("Api")]
public class MembersController : Controller
{
    private readonly IUserService _userService;

    public MembersController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Authenticate a member
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [AllowAnonymous]
    public async Task<ApiResponse> Authenticate(AuthenticateRequest model)
    {
        var member = await _userService.Authenticate(model);

        if (member == null)
            return new ApiResponse(System.Net.HttpStatusCode.NotFound, model,"Username or password is incorrect");

        return new ApiResponse(System.Net.HttpStatusCode.OK, member);
    }
}