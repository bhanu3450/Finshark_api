namespace Finshark_api.Models
{
    public class Comment
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty ;

        public DateTime CreatedOn { get; set; } = DateTime.Now ;

        public int? StockId { get; set; }
        public Stock? Stock { get; set; }
    }
}
