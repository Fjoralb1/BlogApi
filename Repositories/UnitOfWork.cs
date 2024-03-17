using DevAlApplication.Interface;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
