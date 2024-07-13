using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.AnimeService
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Anime Anime { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var anime = await _dataContext.Animes.FindAsync(request.Anime.Id);
                if (anime == null) return null;

                //To Do: Should be edit functionality. Done! Via AutoMapper
                _mapper.Map(request.Anime, anime);

                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update anime.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}