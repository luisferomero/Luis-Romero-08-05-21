using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bertoni.MiniProject.Presentation.ViewModels
{
    public class PhotoVM
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }

        public List<CommentVM> Comments { get; set; }
    }
}
