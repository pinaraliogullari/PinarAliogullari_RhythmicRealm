using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete.Others;

namespace RhythmicRealm.Data.Concrete.Repositories
{
    public class ImageFileRepository:GenericRepository<ImageFile>, IImageFileRepository
    {
        public ImageFileRepository(RRContext _context):base(_context)
        {
            
        }
        private RRContext RRContext
        {
            get { return _dbContext as RRContext;}
        }
    }
}
