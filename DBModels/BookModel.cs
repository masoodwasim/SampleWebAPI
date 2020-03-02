using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebAPI.DBModels
{
    public class BookModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public string Publisher { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
