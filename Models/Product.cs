namespace EFCorePostgreSQL.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
    }
}
