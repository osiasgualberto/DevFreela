using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject
{
    public  class InsertProjectHandler(DevFreelaDbContext context): IRequestHandler< InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context = context;

        //public InsertProjectHandler(DevFreelaDbContext context)
        //{
       //     _context = context;
       // }


        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();

            await _context.Projects.AddAsync(project);

            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(project.Id);

        }
    }
}
