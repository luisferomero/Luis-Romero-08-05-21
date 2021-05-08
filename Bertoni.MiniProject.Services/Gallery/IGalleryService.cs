using Bertoni.MiniProject.Entities.Gallery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.MiniProject.Services.Gallery
{
    public interface IGalleryService
    {
        Task<List<Album>> GetAllAlbums();
        Task<List<Photo>> GetPhotosByAlbumId(int albumId);
        Task<Photo> GetPhotoById(int photoId);
        Task<List<Comment>> GetCommentsByPhotoId(int photoId);
    }
}
