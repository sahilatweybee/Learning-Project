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
        
        public async Task<CourseDto> AddOrUpdateAsync(CourseDto dto)
        {
            Thread.Sleep(1000);

            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            Course? course = null;
            if(dto.Id != 0)
                course = await _courserepository.FindByIdAsync(dto.Id);

            if (course == null)
                course = new Course();

            course.Name = dto.Name;
            course.Description = dto.Description;
            course.Link = dto.Link;
            course.Image = dto.Image;

            if (dto.Id != 0) 
                _courserepository.Update(course);
            else 
                _courserepository.Insert(course);

            await _courserepository.SaveChangesAsync();

            return await Task.FromResult(new CourseDto
            {
                Id = course.Id,
                Name = dto.Name,
                Description = course.Description,
                Image = course.Image,
                Link = course.Link,
            });
        }
    }
}
