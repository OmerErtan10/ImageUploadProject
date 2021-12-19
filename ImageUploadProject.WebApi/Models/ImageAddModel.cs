using Microsoft.AspNetCore.Http;

namespace ImageUploadProject.WebApi.Models
{
    public class ImageAddModel
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
