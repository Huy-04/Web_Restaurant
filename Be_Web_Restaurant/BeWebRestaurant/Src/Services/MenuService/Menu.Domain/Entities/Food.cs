using System;
using Domain.Core.Base;
using Menu.Domain.Enums;
using Menu.Domain.ValueObjects;


namespace Menu.Domain.Entities
{
    public class Food : Entity
    {
        public string NameFood { get; private set; }

        public Money Price { get; private set; }

        public string Img { get; private set; }

        public string Description { get; private set; }

        public FoodStatusEnum Status { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public int IdFoodType { get; private set; }

        public virtual FoodType FoodType { get; private set; }

        private Food() { }

        private Food(string nameFood, Money price, int idFoodType, string? img = null, string? description = null)
        {
            NameFood = nameFood;
            Price = price;
            IdFoodType = idFoodType;
            Img = img;
            Description = description;  
            Status = FoodStatusEnum.Available;
            CreatedAt = DateTime.UtcNow;
        }

        public static Food Create(string nameFood, Money price, int idFoodType, string? img = null, string? description = null)
        {
            return new Food(nameFood, price, idFoodType, img, description);
        }

        public void Update(string nameFood, Money price, int idFoodType, string? img, string? description, FoodStatusEnum status )
        {
            NameFood = nameFood;
            Price = price;
            IdFoodType = idFoodType;
            Img = img;
            Description = description;
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsDiscontinued()
        {
            Status = FoodStatusEnum.Discontinued;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsAvailable()
        {
            Status = FoodStatusEnum.Available;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsOutOfStock()
        {
            Status = FoodStatusEnum.OutOfStock;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
