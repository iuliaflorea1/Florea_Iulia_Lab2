using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Florea_Iulia_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Display(Name = "Book Title")]
        public string Title { get; set; }
        //public string Author { get; set; }
        
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int? PublisherID { get; set; }

        public Publisher? Publisher { get; set; }

        public int? AuthorID { get; set; }// Foreign Key

        [ForeignKey("AuthorID")]
        public Authors? Author { get; set; }

        //public ICollection<Book> categories { get; set; }
        //clasele se denumesc la singular, folderele se denumesc la plural
    }
}
