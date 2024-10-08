﻿using Learning_Project.GraphQL.Types;
using Learning_Project.Service;
using GraphQL;
using GraphQL.Builders;
using GraphQL.Execution;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using System.ComponentModel;

namespace Learning_Project.GraphQL.Queries
{
    public class CourseQuery : ObjectGraphType
    {
        public CourseQuery(ICourseService courseService)
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