using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIBRARYMVC_TEST.Models;

public partial class Author
{
    public int Id { get; set; }

    [Display(Name = "Nombre del Autor")]
    public string? Name { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
