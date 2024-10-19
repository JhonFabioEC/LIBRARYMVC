using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIBRARYMVC_TEST.Models;

public partial class Book
{
    public int Id { get; set; }

    [Display(Name = "Titulo")]
    public string? Title { get; set; }

    [Display(Name = "Autor")]
    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }
}
