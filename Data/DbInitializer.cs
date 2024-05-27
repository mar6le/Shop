using Magazine.Models;

namespace Magazine.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MagazineContext context)
        {
            context.Database.EnsureCreated();

            // Look for any categories.
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
            new Category{CategoryId=1,CategoryName="Laptops",ImagePath=@"\ShopImage\Notebooks.png"},
            new Category{CategoryId=2,CategoryName="Computers",ImagePath=@"\ShopImage\Computers.png"},
            new Category{CategoryId=3,CategoryName="Phones",ImagePath=@"\ShopImage\Phones.png"},
            new Category{CategoryId=4,CategoryName="Cameras",ImagePath=@"\ShopImage\Cameras.png"},
           

            };
            foreach (Category s in categories)
            {
                context.Categories.Add(s);
            }
            context.SaveChanges();

            var products = new Product[]
            {
            new Product{CategoryID=1,Name="Lenovo",Description="Laptops",Price=1200,ImagePath=@"\ProductImage\Lenovo.jpg"},
            new Product{CategoryID=1,Name="Lenovo",Description="Laptops",Price=1800,ImagePath=@"\ProductImage\Lenovo2.png"},
            new Product{CategoryID=1,Name="Asus",Description="Laptops",Price=1200,ImagePath=@"\ProductImage\Asus.png"},
             new Product{CategoryID=1,Name="Acer",Description="Laptops",Price=4200,ImagePath=@"\ProductImage\Acer.png"},
            new Product{CategoryID=1,Name="Alienware",Description="Laptops",Price=5000,ImagePath=@"\ProductImage\Alienware.png"},
              new Product{CategoryID=1,Name="HP",Description="Laptops",Price=2800,ImagePath=@"\ProductImage\HP.png"},


             new Product{CategoryID=2,Name="Asus",Description="Computers",Price=1500,ImagePath=@"\ProductImage\Asus S500.png"},
            new Product{CategoryID=2,Name="Artline",Description="Computers",Price=4000,ImagePath=@"\ProductImage\Artline.png"},
            new Product{CategoryID=2,Name="Asus",Description="Computers",Price=1000,ImagePath=@"\ProductImage\Asus S500m.png"},

            new Product{CategoryID=3,Name="Samsung",Description="Phones",Price=3000,ImagePath=@"\ProductImage\Samsung.png"},
             new Product{CategoryID=3,Name="Samsung GalaxyS21",Description="Phones",Price=1500,ImagePath=@"\ProductImage\Samsung2.png"},
 new Product{CategoryID=3,Name="Sony",Description="Phones",Price=1200,ImagePath=@"\ProductImage\Sony.png"},
 new Product{CategoryID=3,Name="Iphone",Description="Phones",Price=4500,ImagePath=@"\ProductImage\Iphone.png"},
  new Product{CategoryID=3,Name="Google Pixel",Description="Phones",Price=2500,ImagePath=@"\ProductImage\Pixel.png"},
   new Product{CategoryID=3,Name="Samsung GalaxyS22",Description="Phones",Price=1700,ImagePath=@"\ProductImage\Samsung3.png"},

                new Product{CategoryID=4,Name="Canon",Description="Cameras",Price=100,ImagePath=@"\ProductImage\Canon.png"},
                new Product{CategoryID=4,Name="Leica",Description="Cameras",Price=1200,ImagePath=@"\ProductImage\Leica.png"},
new Product{CategoryID=4,Name="Nikon",Description="Cameras",Price=3000,ImagePath=@"\ProductImage\Nikon2.png"},
new Product{CategoryID=4,Name="Vertex",Description="Cameras",Price=10000,ImagePath=@"\ProductImage\Vertex.png"},



            };
            foreach (Product c in products)
            {
                context.Products.Add(c);
            }
            context.SaveChanges();

        }
    }
}
