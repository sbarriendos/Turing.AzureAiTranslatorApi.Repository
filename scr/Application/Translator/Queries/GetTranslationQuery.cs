using Application.DTOs;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Posts.Queries;

public class GetTranslationQuery : IRequest<TranslationDTO>
{
    public required string Guid { get; set; }
}