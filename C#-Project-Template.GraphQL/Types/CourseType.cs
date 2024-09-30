using C__Project_Template.DTO;
using GraphQL.Types;

namespace C__Project_Template.GraphQL.Types
{
    public class CourseType : ObjectGraphType<CourseDto>
    {
        public CourseType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Name("Id")!.Description("Id of the Course").DefaultValue(0);
            Field(x => x.Name, type: typeof(StringGraphType)).Name("Name")!.Description("Name of the Course").DefaultValue(string.Empty);
            Field(x => x.Description, type: typeof(StringGraphType)).Name("Description")!.Description("Description of the Course").DefaultValue(null);
            Field(x => x.Link, type: typeof(StringGraphType)).Name("Link")!.Description("Link Url of the Course").DefaultValue(null);
            Field(x => x.Image, type: typeof(StringGraphType)).Name("Image")!.Description("Image Url of the Course").DefaultValue(null);
        }
    }
}
