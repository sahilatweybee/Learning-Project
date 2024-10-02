using Learning_Project.DTO;
using Learning_Project.GraphQL.Types;
using Learning_Project.Service;
using GraphQL;
using GraphQL.Types;
using Microsoft.Identity.Client;

namespace Learning_Project.GraphQL.Mutations
{
    public class CourseMutation : ObjectGraphType
    {
        public CourseMutation(ICourseService service)
        {
            Field<CourseType>(name: "Add").Description("Add a new Course")
                                          .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<CourseInputType>>()
                                          {
                                              Name = "dto",
                                              Description = "Course object being added"
                                          }))
                                          .ResolveAsync(async context =>
                                          {
                                              var course = context.GetArgument<CourseDto>("dto");
                                              course.Id = 0;
                                              var result = await service.AddOrUpdateAsync(course);
                                              return result;
                                          });
            
            Field<CourseType>(name: "Update").Description("Add a new Course")
                                             .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<CourseInputType>>()
                                                {
                                                    Name = "Dto",
                                                    Description = "Course object being updated"
                                             },
                                                new QueryArgument<NonNullGraphType<IdGraphType>>()
                                                {
                                                    Name = "Id",
                                                    Description = "Id of the course being updated",
                                                    DefaultValue = 0
                                                }))
                                             .ResolveAsync(async context =>
                                                {
                                                    var id = context.GetArgument<int>("Id");
                                                    if (id == 0)
                                                        throw new Exception("Non null and non Zero Id is required");

                                                    var course = context.GetArgument<CourseDto>("Dto");
                                                    course.Id = id;
                                                    var result = await service.AddOrUpdateAsync(course);
                                                    return result;
                                                });

            Field<BooleanGraphType>(name: "Delete").Description("Add a new Course")
                                                   .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>()
                                             {
                                                 Name = "Id",
                                                 Description = "Id of the course being deleted",
                                                 DefaultValue = 0
                                             }))
                                                   .ResolveAsync(async context =>
                                             {
                                                 var id = context.GetArgument<int>("Id");
                                                 if (id == 0)
                                                     throw new Exception("Non null and non Zero Id is required");

                                                 var result = await service.DeleteCourseAsync(id);
                                                 return result;
                                             });
        }
    }
}
