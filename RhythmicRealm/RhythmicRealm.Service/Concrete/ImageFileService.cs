using Mapster;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.GalleryViewModels;

namespace RhythmicRealm.Service.Concrete
{    public class ImageFileService : IImageFileService
    {
        private readonly IImageFileRepository _galleryRepository;

        public ImageFileService(IImageFileRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        public async Task<Response<List<ImageFileViewModel>>> GetAllAsync()
        {
            var photos= await _galleryRepository.GetAllAsync();
            if(photos == null)
                return Response<List<ImageFileViewModel>>.Fail(404, "Sonuç bulunamadı");
            var photosViewModel=photos.Adapt<List<ImageFileViewModel>>();
           return Response<List<ImageFileViewModel>>.Success(photosViewModel, 200);
            
        }
    }
}
