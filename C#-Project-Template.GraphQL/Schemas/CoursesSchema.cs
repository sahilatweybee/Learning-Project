using C__Project_Template.GraphQL.Mutations;
using C__Project_Template.GraphQL.Queries;
using GraphQL.Types;

namespace C__Project_Template.GraphQL.Schemas
{
    public class CoursesSchema : Schema
    {
        public CoursesSchema(CourseQuery query, CourseMutation mutation)
        {
            this.Query = query;
            this.Mutation = mutation;
        }
    }
}
