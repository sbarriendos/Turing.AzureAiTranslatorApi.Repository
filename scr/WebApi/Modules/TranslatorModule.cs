using Application.DTOs;
using Application.Posts.Queries;
using Application.Translator.Commands;
using Carter;
using Domain.Entities;
using Domain.Models;
using FluentValidation;
using FluentValidation.Validators;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using Presentation.Validators;

namespace WebApi.Modules;

[AllowAnonymous]
public class TranslatorModule : CarterModule
{
    public TranslatorModule()
        : base("api/v1/translate")
    {

    }
        public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (IMediator mediator, ToTranslateDTO translator) =>
        {
            TranslateCommand command = new() { TranslatorDTO = translator };
            ToTranslateResponseDTO response = await mediator.Send(command);

            return Results.Ok(response);
        })
        .WithName("Translate text")
        .WithOpenApi()
        .AllowAnonymous()
        .AddEndpointFilter<ValidationFilter<ToTranslateDTO>>();

        app.MapGet("", async (IMediator mediator, string guid) =>
        {
            if (guid is null)
                throw new ArgumentNullException(guid, "guid must not be null");

            GetTranslationQuery query = new() { Guid = guid };
            TranslationDTO responseDTO = await mediator.Send(query);

            return TypedResults.Ok(responseDTO);
        })
        .WithName("Get translated text")
        .AllowAnonymous()
        .WithOpenApi();
    }
}
