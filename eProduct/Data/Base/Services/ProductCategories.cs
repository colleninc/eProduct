

using eProduct.Data.Base;
using eProduct.Model;
using System.Threading.Tasks;

namespace eProduct.Data.Service
{
    public class ProductsCategoriesService : EntityBaseRepository<ProductCategory>, IProductCategories
    {
        private readonly AppDbContext _context;
        public ProductsCategoriesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewCategory(ProductCategory data)
        {
            
            _context.Categories.AddAsync(data);
            _context.SaveChangesAsync();
        }
    }
}
