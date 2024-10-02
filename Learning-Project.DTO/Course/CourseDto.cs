namespace Learning_Project.DTO
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Link { get; set; }

        public string? Image { get; set; }
        public List<VideoDto>? Videos { get; set; } = new List<VideoDto>();
        public int VideosCount { get => Videos?.Count ?? 0; }
    }

}
