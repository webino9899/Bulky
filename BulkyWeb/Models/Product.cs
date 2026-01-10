namespace BulkyWeb.Models
{
    public class Product
    {
            public int Id { get; set; }
            public string Name { get; set; }
                
            public string Description { get; set; }
            public double Price { get; set; }
            public string Category { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
         public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string DescriptionUrl { get; set; }

        public Product()
        {
            Name = string.Empty;
            Description = string.Empty;
            Category = string.Empty;
            CategoryName = string.Empty;
            CategoryDescription = string.Empty;
            ImageUrl = string.Empty;
            DescriptionUrl = string.Empty;
        }

        public override string ToString()
        {
            return $"Product [Id={Id}, Name={Name}, Description={Description}, Price={Price}, Category={Category}, Stock={Stock}, ImageUrl={ImageUrl}, DescriptionUrl={DescriptionUrl}]";
        }

    }
}
