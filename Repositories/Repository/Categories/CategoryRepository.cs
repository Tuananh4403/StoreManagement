using Repositories.EF;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.Catergories
{
    public class CategoryRepository :ICategoryRepository
    {
        private readonly MyStoreDBContext _context;

        public CategoryRepository(MyStoreDBContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public IEnumerable<Category> SearchCategories(string searchTerm)
        {
            return _context.Categories
                           .Where(c => c.CategoryName.Contains(searchTerm))
                           .ToList();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
