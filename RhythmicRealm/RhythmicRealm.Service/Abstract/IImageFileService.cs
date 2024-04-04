using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.GalleryViewModels;

namespace RhythmicRealm.Service.Abstract
{
    public interface IImageFileService
    {
        Task<Response<List<ImageFileViewModel>>> GetAllAsync();
    }
}
