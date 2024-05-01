using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sda_onsite_2_csharp_backend_teamwork.src.Database;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;
using sda_onsite_2_csharp_backend_teamwork.src.Server;

namespace sda_onsite_2_csharp_backend_teamwork.src.Repository;

public class CategoryRepository
{
    public IEnumerable<Category> category { get; }
    private IEnumerable<Category> _category;
    public CategoryRepository()
    {
        _category = new DatabaseContext().Category;
    }
    public IEnumerable<Category> FindAll()
    {
        return category;
    }
    public Category? FindOne(string name)
    {
        return _category.FirstOrDefault((item) => item.Name == name);
    }

    public Category CreateOne(Category newCategory)
    {
        _category.Append(newCategory);
        return newCategory;
    }
    public Category UpdateOne(Category UpdateCategory)
    {
        var category = _category.Select(category =>
     {
         if (category.Name == UpdateCategory.Name)
         {
             return UpdateCategory;
         }
         return category;
     });
        _category = category.ToList();

        return UpdateCategory;
    }
    public IEnumerable<Category> DeleteOne(string id)
    {
        _category.Where(category => category.Id == id);
        return _category;
    }
}


