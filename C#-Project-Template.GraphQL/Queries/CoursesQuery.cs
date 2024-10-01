using C__Project_Template.GraphQL.Types;
using C__Project_Template.Service;
using GraphQL;
using GraphQL.Builders;
using GraphQL.Execution;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using System.ComponentModel;

namespace C__Project_Template.GraphQL.Queries
{
    public class CoursesQuery : ObjectGraphType
    {
        public CoursesQuery(ICourseService courseService)
        {
           Field<ListGraphType<CourseType>>(name: "courses").Description("Get All Courses")
                                                            .DefaultValue(null)
                                                            .ResolveAsync(async context => await courseService.GetAllAsync());

            
            Field<CourseType>(name: "course").Description("Get Course by id")
                                             .Arguments(new QueryArgument<NonNullGraphType<IntGraphType>>()
                                             {
                                                 Description = "Id of the course being fetched",
                                                 Name = "Id",
                                                 DefaultValue = 0,
                                             })
                                             .DefaultValue(null)
                                             .ResolveAsync(async context => await courseService.GetByIdAsync(context.GetArgument("Id", int.MinValue)));


        }
    }
}
