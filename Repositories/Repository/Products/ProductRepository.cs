using Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreDBContext _context;

        public ProductRepository(MyStoreDBContext context)
        {
            _context = context;
        }
    }
}
