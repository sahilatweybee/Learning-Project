using C__Project_Template.Data.Models;
using C__Project_Template.DTO;

namespace C__Project_Template.Service
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAll();
    }
}