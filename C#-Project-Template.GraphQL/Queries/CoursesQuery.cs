using C__Project_Template.GraphQL.Types;
using C__Project_Template.Service;
using GraphQL.Types;

namespace C__Project_Template.GraphQL.Queries
{
    public class CoursesQuery : ObjectGraphType
    {
        public CoursesQuery(ICourseService courseService)
        {
            Field<ListGraphType<CourseType>>(
                name: "courses",
                description: "Get All Courses",
                arguments: null,
                resolve: context => courseService.GetAll().Result.ToList()!
                );
        }
    }
}
