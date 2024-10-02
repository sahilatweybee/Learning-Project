using Learning_Project.DTO;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Project.GraphQL.Types
{
    public class VideoType : ObjectGraphType<VideoDto>
    {
        public VideoType()
        {
            Field(name: "Id", x => x.Id, type: typeof(IdGraphType)).Description("Id of the Video").DefaultValue(0);
            Field(name: "Title", x => x.Title, type: typeof(StringGraphType)).Description("Title of the Video").DefaultValue(string.Empty);
            Field(name: "Link", x => x.Link, type: typeof(StringGraphType)).Description("Link Url of the Video").DefaultValue(null);
            Field(name: "Image", x => x.Image, type: typeof(StringGraphType)).Description("Image Url of the Video").DefaultValue(null);
            Field(name: "CourseId", x => x.CourseId, type: typeof(IntGraphType)).Description("Id of the course that video belongs to").DefaultValue(0);
            Field(name: "Course", x => x.Course, type: typeof(CourseType)).Description("Course object that video belongs to").DefaultValue(null);
            //Field(name: "Description", x => x.Description, type: typeof(StringGraphType)).Description("Description of the Video").DefaultValue(null);
            
        }
    }
}
