namespace Portfolio.Models
{
    public class Scroll
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slot { get; set; }
        public string stat { get; set; }
        public int success { get; set; }
        // Make sure this never exceeds 2b
        public int price { get; set; }

    }
}
