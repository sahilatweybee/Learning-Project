﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Learning_Project.Data.Models;

public partial class Course
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Link { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Image { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
