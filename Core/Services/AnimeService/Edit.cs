using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Core.Services.AnimeService
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
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var anime = await _dataContext.Animes.FindAsync(request.Anime.Id);
                if (anime == null) return null;

                //To Do: Should be edit functionality

                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update anime.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}