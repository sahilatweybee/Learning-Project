using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C__Project_Template.Data.Models;

public partial class Video
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(100)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column("index")]
    public int Index { get; set; }

    [Column("link")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Link { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("image")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Image { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Videos")]
    public virtual Course Course { get; set; } = null!;
}
