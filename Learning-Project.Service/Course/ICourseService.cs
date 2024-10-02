using Learning_Project.Data.Models;
using Learning_Project.DTO;

namespace Learning_Project.Service
{
    public interface ICourseService
    {
        Task<CourseDto> AddOrUpdateAsync(CourseDto dto);
        Task<bool> DeleteCourseAsync(int id);
        Task<List<CourseDto>> GetAllAsync();
        Task<CourseDto> GetByIdAsync(int id);
    }
}