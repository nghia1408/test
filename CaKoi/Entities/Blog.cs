using System;
using System.Collections.Generic;

namespace CaKoi.Entities;

public partial class Blog
{
    public int BlogId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public int? AuthorId { get; set; }

    public DateTime? DatePosted { get; set; }

    public virtual User? Author { get; set; }
}
