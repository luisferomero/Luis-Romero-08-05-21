using AutoMapper;
using Bertoni.MiniProject.Entities.Gallery;
using Bertoni.MiniProject.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bertoni.MiniProject.Presentation.Mappers
{
    public class GalleryProfile : Profile
    {
        public GalleryProfile()
        {
            CreateMap<Album, AlbumVM>();
            CreateMap<Photo, PhotoVM>();
            CreateMap<Comment, CommentVM>();
        }
    }
}
