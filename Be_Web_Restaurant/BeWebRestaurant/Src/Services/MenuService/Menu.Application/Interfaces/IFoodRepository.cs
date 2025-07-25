﻿using Menu.Domain.Entities;
using Menu.Domain.ValueObjects;

namespace Menu.Application.Interfaces
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetAllAsync();

        Task<Food?> GetByIdAsync(Guid idFood);

        Task<IEnumerable<Food>> GetByFoodTypeAsync(Guid idFoodType);

        Task<Food> CreateAsync(Food food);

        Task<Food> UpdateAsync(Food food);

        Task<bool> DeleteAsync(Guid idFood);

        Task<bool> ExistsByNameAsync(FoodName foodName);
    }
}