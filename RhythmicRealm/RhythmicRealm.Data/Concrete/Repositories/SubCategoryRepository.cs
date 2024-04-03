using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;

namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
	{
		public SubCategoryRepository(RRContext _context) : base(_context)
		{

		}
		private RRContext RRContext
		{
			get { return _dbContext as RRContext; }
		}
	}
}
