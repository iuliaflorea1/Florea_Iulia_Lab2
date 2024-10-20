using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Florea_Iulia_Lab2.Models
{
    public class Authors
    {
        public int ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public string AuthorName {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public ICollection<Book> Books { get; set; }
    }
}
