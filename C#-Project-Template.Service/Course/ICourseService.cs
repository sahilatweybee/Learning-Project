using C__Project_Template.Data.Models;
using C__Project_Template.DTO;

namespace C__Project_Template.Service
{
    public interface ICourseService
    {
        Task<CourseDto> AddOrUpdateAsync(CourseDto dto);
        Task<bool> DeleteCourseAsync(int id);
        Task<List<CourseDto>> GetAllAsync();
        Task<CourseDto> GetByIdAsync(int id);
    }
}