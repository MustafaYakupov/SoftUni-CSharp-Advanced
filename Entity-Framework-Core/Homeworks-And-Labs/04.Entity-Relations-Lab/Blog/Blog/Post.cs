﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDemo;

[Table("Posts", Schema = "blg")]
public class Post
{
    [Key]
    public int PostId { get; set; }

    [Required]
    [MaxLength(100)]
    public string PostTitle { get; set; } = null!; // NOT NULL

    [Required]
    public string Body { get; set; } = null!;

    public int BlogId { get; set; }

    [ForeignKey(nameof(BlogId))]
    public Blog Blog { get; set; }

    public List<PostTag> PostTags { get; set; } = new List<PostTag>();
}
