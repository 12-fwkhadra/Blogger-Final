using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFK.Models
{
  internal class SeedCategory : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> entity)
    {
      entity.HasData(new Category
            {
                categoryId = 1,
                categoryName = "math"
            },
            new Category
            {
                categoryId = 2,
                categoryName = "programming"
            },
            new Category
            {
                categoryId = 3,
                categoryName = "books"
            },
            new Category
            {
                categoryId = 4,
                categoryName = "pets"
            },
            new Category
            {
                categoryId = 5,
                categoryName = "gaming"
            },new Category
            {
                categoryId = 6,
                categoryName = "politics"
            },new Category
            {
                categoryId = 7,
                categoryName = "gaming"
            });
    }
  }

}