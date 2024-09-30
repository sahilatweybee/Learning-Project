using C__Project_Template.Data.Contexts;
using C__Project_Template.Data.Models;
using C__Project_Template.DTO;
using C__Project_Template.Repository;
using Microsoft.EntityFrameworkCore;

namespace C__Project_Template.Service
{
    public class CourseService : ICourseService
    {

        private IRepository<AppDbContext, Course> _courserepository;

        public CourseService(IRepository<AppDbContext, Course> courserepository)
        {
            _courserepository = courserepository;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            Thread.Sleep(1000);
            return await _courserepository.Query().Get().Select(x => new CourseDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Link = x.Link   
            }).ToListAsync();
        }
        
        public async Task<CourseDto> GetByIdAsync(int id)
        {
            Thread.Sleep(1000);
            return await _courserepository.Query().Filter(x => x.Id.Equals(id)).Get().Select(x => new CourseDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Link = x.Link   
            }).FirstOrDefaultAsync() ?? throw new Exception($"No record found on Id {id}");
        }
    }
}
