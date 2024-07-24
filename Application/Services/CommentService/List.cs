using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.CommentService
{
    public class List
    {
        public class Query : IRequest<List<CommentDto>>
        {
            public Guid Id { get; set; } // Id of user
        }
        public class Handler : IRequestHandler<Query, List<CommentDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<List<CommentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<CommentDto>>(await _dataContext.Comments.Include(c => c.User).ToListAsync());
            }
        }
    }
}