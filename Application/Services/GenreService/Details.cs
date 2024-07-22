using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.GenreService
{
    public class Details
    {
        public class Query : IRequest<Result<GenreDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<GenreDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<GenreDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var genre = await _dataContext.Genres.Where(s => s.Id == request.Id).FirstOrDefaultAsync();
                if (genre != null)
                    return Result<GenreDto>.Success(_mapper.Map<GenreDto>(genre));
                else
                    return Result<GenreDto>.Failure("Genre don't found.");
            }
        }
    }
}