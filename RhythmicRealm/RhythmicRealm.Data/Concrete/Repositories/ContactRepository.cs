using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;

namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class ContactRepository:GenericRepository<Contact>,IContactRepository
	{
        public ContactRepository(RRContext _context):base(_context)
        {
            
        }
        private RRContext RRContext
        {
            get {return _dbContext as RRContext; }
        }
    }
}
