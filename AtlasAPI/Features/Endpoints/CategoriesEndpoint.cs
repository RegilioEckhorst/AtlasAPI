using AtlasAPI.Features.Categories;
using Microsoft.EntityFrameworkCore;

namespace AtlasAPI.Features.Endpoints;

public static class CategoriesEndpoint
{
    public static void RegisterCategories(this WebApplication app)
    {
        var categories = app.MapGroup("/categories");
        categories.MapGet("/", GetAllCategories);
        categories.MapPost("/", CreateCategory);
        categories.MapGet("/{id}", GetCategoryById);
        categories.MapPut("/{id}", UpdateCategory);
        categories.MapDelete("/{id}", DeleteCategory);
        categories.MapDelete("/delete", DeleteAllCategories);

        static async Task<IResult> CreateCategory(Category category, DBContext db)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/addCategory/{category.Id}", category);
        }

        static async Task<IResult> GetAllCategories(DBContext db)
        {
            var categories = await db.Categories.ToListAsync();
            if (categories.Count == 0)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(categories);
        }

        static async Task<IResult> GetCategoryById(int id, DBContext db)
        {
            var category = await db.Categories.FindAsync(id);
            return category is not null ? TypedResults.Ok(category) : TypedResults.NotFound();
        }

        static async Task<IResult> UpdateCategory(int id, Category inputCategory, DBContext db)
        {
            Category? category = await db.Categories.FindAsync(id);
            if (category is null) return TypedResults.NotFound();
            category.Name = inputCategory.Name;
            category.UpdatedAt = DateTime.UtcNow;
            await db.SaveChangesAsync();
            return TypedResults.Ok("Updated");
        }

        static async Task<IResult> DeleteCategory(int id, DBContext db)
        {
            if (await db.Categories.FindAsync(id) is Category category)
            {
                db.Categories.Remove(category);
                await db.SaveChangesAsync();
                return TypedResults.Ok("Deleted");
            }
            return TypedResults.NotFound();
        }

        static async Task<IResult> DeleteAllCategories(DBContext db)
        {
            List<Category> categories = await db.Categories.ToListAsync();
            db.Categories.RemoveRange(categories);
            int deletedCount = await db.SaveChangesAsync();
            return TypedResults.Ok(new { DeletedCount = deletedCount });
        }
    }
}