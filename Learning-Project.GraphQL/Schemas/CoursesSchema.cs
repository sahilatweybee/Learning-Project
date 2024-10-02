using Learning_Project.GraphQL.Mutations;
using Learning_Project.GraphQL.Queries;
using GraphQL.Types;

namespace Learning_Project.GraphQL.Schemas
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
