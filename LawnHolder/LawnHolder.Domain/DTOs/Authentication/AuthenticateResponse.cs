﻿using LawnHolder.Domain.Entities.Identity;

namespace LawnHolder.Domain.DTOs.Authentication;

public class AuthenticateResponse
{
    public AuthenticateResponse(ApplicationUser user, string token)
    {
        Id = user.Id;
        Username = user.UserName;
        Token = token;
    }

    public string Id { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
}