using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LIBRARYMVC_TEST.Models.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }

        [BindNever]
        public List<SelectListItem>? AuthorList { get; set; }
    }
}
