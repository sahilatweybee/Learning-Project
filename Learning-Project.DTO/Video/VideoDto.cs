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
