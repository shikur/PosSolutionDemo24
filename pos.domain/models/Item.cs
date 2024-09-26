namespace Pos.Models
{
    public class Item
    {

        public int Items_ID { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string Shape { get; set; }
        public bool Taxable { get; set; }
        public string Size { get; set; }
        public int UPC { get; set; }
    }
}