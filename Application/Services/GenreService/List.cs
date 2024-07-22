using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.GenreService
{
    public class List
    {
        public class Query : IRequest<List<GenreDto>> { }
        public class Handler : IRequestHandler<Query, List<GenreDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<List<GenreDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<GenreDto>>(await _dataContext.Genres.ToListAsync());
            }
        }
    }
}