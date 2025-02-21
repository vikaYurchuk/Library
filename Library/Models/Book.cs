namespace Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int Pages { get; set; }
        public string Genre { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int? SequelTo { get; set; }
        public Book? Sequel { get; set; } 
        public Book? Previous { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}