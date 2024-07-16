using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.Catergories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        IEnumerable<Category> SearchCategories(string searchTerm);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
        IEnumerable<Category> GetAllCategories();
    }
}
