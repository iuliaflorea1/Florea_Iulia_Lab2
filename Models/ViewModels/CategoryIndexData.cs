using Florea_Iulia_Lab2.Models;

namespace Florea_Iulia_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
