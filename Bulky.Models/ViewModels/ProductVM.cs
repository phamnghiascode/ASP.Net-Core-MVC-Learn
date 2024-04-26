// using Microsoft.AspNetCore.Mvc;


// i dont know why it not work here
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bulky.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}