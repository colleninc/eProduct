

using eProduct.Data.Base;
using eProduct.Model;
using System.Threading.Tasks;

namespace eProduct.Data.Service
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProduct(Product data)
        {
            
            _context.Products.AddAsync(data);
            _context.SaveChangesAsync();
        }
    }
}
