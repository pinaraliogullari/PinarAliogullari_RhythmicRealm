using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;

namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class BrandRepository:GenericRepository<Brand>,IBrandRepository
	{
		public BrandRepository(RRContext _context) : base(_context)
		{
		}

		private RRContext RRContext
		{
			get { return _dbContext as RRContext; }
		}
	}
}
