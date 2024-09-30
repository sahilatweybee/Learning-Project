using C__Project_Template.DTO;
using GraphQL.Types;

namespace C__Project_Template.GraphQL.Types
{
    public class CourseType : ObjectGraphType<CourseDto>
    {
        public CourseType()
        {
            Field(name: "Id", x => x.Id, type: typeof(IdGraphType)).Description("Id of the Course").DefaultValue(0);
            Field(name: "Name", x => x.Name, type: typeof(StringGraphType)).Description("Name of the Course").DefaultValue(string.Empty);
            Field(name: "Description", x => x.Description, type: typeof(StringGraphType)).Description("Description of the Course").DefaultValue(null);
            Field(name: "Link", x => x.Link, type: typeof(StringGraphType)).Description("Link Url of the Course").DefaultValue(null);
            Field(name: "Image", x => x.Image, type: typeof(StringGraphType)).Description("Image Url of the Course").DefaultValue(null);
        }
    }
}
