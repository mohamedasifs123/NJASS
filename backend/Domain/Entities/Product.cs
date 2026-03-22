namespace Domain.Entities
{
    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual decimal Price { get; set; }
    }
}