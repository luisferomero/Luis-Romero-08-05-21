using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bertoni.MiniProject.Presentation.ViewModels
{
    public class AlbumVM
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        public List<PhotoVM> Photos { get; set; }
    }
}
