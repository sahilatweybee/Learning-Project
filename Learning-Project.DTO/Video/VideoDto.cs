using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Project.DTO
{
    public class VideoDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Index { get; set; }
        public string? Link { get; set; }
        public int CourseId { get; set; }
        public string? Image { get; set; }
        public CourseDto? Course { get; set; } = null!;
    }
}
