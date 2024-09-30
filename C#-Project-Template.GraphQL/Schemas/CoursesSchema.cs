using C__Project_Template.GraphQL.Queries;
using GraphQL.Types;

namespace C__Project_Template.GraphQL.Schemas
{
    public class CoursesSchema : Schema
    {
        public CoursesSchema(CoursesQuery query)
        {
            this.Query = query;
        }
    }
}
