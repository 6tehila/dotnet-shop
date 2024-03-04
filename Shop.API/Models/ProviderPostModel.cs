namespace Shop.API.Models
{
    public class ProviderPostModel
    {
        public int Id { get; set; } // מזהה ייחודי של הספק
        public string Name { get; set; } // שם הספק
        public string City { get; set; } // עיר מגוריו של הספק
    }
}
