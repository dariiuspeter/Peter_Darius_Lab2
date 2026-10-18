using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Peter_Darius_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Publishing Date")]
        public DateTime PublishingDate { get; set; }

        [Display(Name = "Publisher")]
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; } //navigation property

        [Display(Name = "Author")]
        public int? AuthorID { get; set; }
        public Author? Author { get; set; } //navigation property
    }
}
