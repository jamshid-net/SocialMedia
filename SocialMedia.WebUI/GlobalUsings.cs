﻿global using SocialMedia.Application.Common.Interfaces;
global using SocialMedia.Application.Users.Command;
global using SocialMedia.WebUI.Services;
global using System.Security.Claims;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using MediatR;
global using SocialMedia.Application;
global using SocialMedia.Infrastucture;
global using SocialMedia.Application.Common.Models;
global using SocialMedia.Application.Users.Queries;
global using SocialMedia.Application.Roles.Command;
global using SocialMedia.Application.Roles.Queries;
global using SocialMedia.Application.Permissions.Command;
global using SocialMedia.Application.Permissions.Queries;
global using SocialMedia.Application.Comments.Command;
global using SocialMedia.Application.Comments.Queries;
global using SocialMedia.Application.Posts.Command;
global using SocialMedia.Application.Posts.Queries;
global using SocialMedia.Application.Common.Exceptions;
global using System.Net;
global using LazyCache;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc.Filters;
global using SocialMedia.WebUI.Attributes;
global using SocialMedia.WebUI.Middlewares;
global using Microsoft.Extensions.Configuration;
global using SocialMedia.Application.Common.Notifications;

