using Learning_Project.DTO;
using GraphQL.Types;

namespace Learning_Project.GraphQL.Types
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
            Field(name: "Videos", x => x.Videos, type: typeof(ListGraphType<VideoType>)).Description("Videos that are available in tyhe course").DefaultValue(null);
            Field(name: "VideosCount", x => x.VideosCount, type: typeof(IntGraphType)).Description("Number of videos available in the course").DefaultValue(0);
        }
    }
}
