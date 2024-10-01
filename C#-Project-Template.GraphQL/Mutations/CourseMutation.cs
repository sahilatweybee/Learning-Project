using C__Project_Template.DTO;
using C__Project_Template.GraphQL.Types;
using C__Project_Template.Service;
using GraphQL;
using GraphQL.Types;

namespace C__Project_Template.GraphQL.Mutations
{
    public class CourseMutation : ObjectGraphType
    {
        public CourseMutation(ICourseService service)
        {
            Field<CourseType>(name: "AddUpdate").Description("Add a new Course")
                                                .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<CourseInputType>>()
                                                {
                                                    Name = "dto",
                                                    Description = "Course object being added"
                                                }))
                                                .ResolveAsync(async context =>
                                                {
                                                    var course = context.GetArgument<CourseDto>("dto");

                                                    var result = await service.AddOrUpdateAsync(course);

                                                    return result;
                                                });
        }
    }
}
