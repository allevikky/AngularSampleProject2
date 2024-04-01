namespace AngularSampleProject2.Server.Models
{
    public class Product
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public decimal? price { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public string? category { get; set; }
        public Rating? Rating { get; set; }
    }


    public class Rating
    {
        public decimal? rate { get; set; }
        public int? count { get; set; }
    }
}
