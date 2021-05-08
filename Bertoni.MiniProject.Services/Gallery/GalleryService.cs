﻿using Bertoni.MiniProject.Entities.Gallery;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.MiniProject.Services.Gallery
{
    public class GalleryService : IGalleryService
    {
        private readonly HttpClient httpClient;

        public GalleryService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://jsonplaceholder.typicode.com/")
            };
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            var response = await httpClient.GetAsync("/albums");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(jsonResponse);

            return albums;
        }

        public async Task<List<Photo>> GetPhotosByAlbumId(int albumId)
        {
            var responsePhotos = await httpClient.GetAsync("/photos");
            var jsonResponsePhotos = await responsePhotos.Content.ReadAsStringAsync();
            List<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(jsonResponsePhotos).Where(photo => photo.AlbumId == albumId).ToList();
            var responseComments = await httpClient.GetAsync("/comments");
            var jsonResponseComments = await responseComments.Content.ReadAsStringAsync();
            List<Comment> comments = JsonConvert.DeserializeObject<List<Comment>>(jsonResponseComments).ToList();

            List<Photo> response = new List<Photo>();
            foreach (var photo in photos)
            {
                photo.Comments = comments.Where(y => y.PostId == photo.Id).ToList();
                response.Add(photo);
            };

            return response;
        }

        public async Task<Photo> GetPhotoById(int photoId)
        {
            var response = await httpClient.GetAsync("/photos");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Photo photo = JsonConvert.DeserializeObject<List<Photo>>(jsonResponse).Where(photo => photo.Id == photoId).FirstOrDefault();

            return photo;
        }

        public async Task<List<Comment>> GetCommentsByPhotoId(int photoId)
        {
            var response = await httpClient.GetAsync("/comments");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Comment> comments = JsonConvert.DeserializeObject<List<Comment>>(jsonResponse).Where(comment => comment.PostId == photoId).ToList();

            return comments;
        }
    }
}
