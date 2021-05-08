using AutoMapper;
using Bertoni.MiniProject.Entities.Gallery;
using Bertoni.MiniProject.Models;
using Bertoni.MiniProject.Presentation.ViewModels;
using Bertoni.MiniProject.Services.Gallery;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bertoni.MiniProject.Presentation.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGalleryService _galleryService;

        public GalleryController(IMapper mapper, IGalleryService galleryService)
        {
            _mapper = mapper;
            _galleryService = galleryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Album> albums = await _galleryService.GetAllAlbums();
            List<AlbumVM> albumsVM = _mapper.Map<List<AlbumVM>>(albums);

            return View(albumsVM);
        }

        public async Task<IActionResult> Photos(int id)
        {
            List<Photo> photos = await _galleryService.GetPhotosByAlbumId(id);
            List<PhotoVM> photosVM = _mapper.Map<List<PhotoVM>>(photos);

            return View(photosVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
