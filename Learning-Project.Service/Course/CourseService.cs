using Learning_Project.Data.Contexts;
using Learning_Project.Data.Models;
using Learning_Project.DTO;
using Learning_Project.Repository;

namespace Learning_Project.Service
{
    public class CourseService : ICourseService
    {
        private IRepository<AppDbContext, Course> _courserepository;
        private bool _disposed;

        public CourseService(IRepository<AppDbContext, Course> courserepository)
        {
            _courserepository = courserepository;
        }

        public async Task<List<CourseDto>?> GetAllAsync()
        {
            Thread.Sleep(1000);
            return await _courserepository.Query().Get().IncludeEntity(x => x.Videos).Select(x => new CourseDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Link = x.Link,
                Videos = x.Videos.Select(vid => new VideoDto
                {
                    Id = vid.Id,
                    Title = vid.Title,
                    Index = vid.Index,
                    Link = vid.Link,
                    Image = vid.Image,
                    CourseId = vid.CourseId,
                }).ToList()
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

        public async Task<bool> DeleteCourseAsync(int id)
        {
            Thread.Sleep(1000);
            bool isSuccess = false;

            var course = await _courserepository.FindByIdAsync(id) ?? throw new Exception($"No record found on Id {id}");

            _courserepository.Delete(course);
            isSuccess = await _courserepository.SaveChangesAsync() > 0;
            
            return await Task.FromResult(isSuccess);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _courserepository?.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
