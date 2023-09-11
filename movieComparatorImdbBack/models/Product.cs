
using System.ComponentModel.DataAnnotations.Schema;


namespace minimalWebApiDotNet.models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }

        //null! opérateur null forgiving. Qui allow null uniquement à l'initialisation de l'objet puis le rend non nullable
        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        public Product(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }

    }
}
