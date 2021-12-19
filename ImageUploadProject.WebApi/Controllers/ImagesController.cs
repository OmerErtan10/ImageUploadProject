using ImageUploadProject.Business.Interfaces;
using ImageUploadProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageUploadProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IGenericService<Entities.Concrete.Image> _genericService;
        public ImagesController(IGenericService<Entities.Concrete.Image> genericService)
        {
            _genericService = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _genericService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByID(int id)
        {
            return Ok(await _genericService.FindByIdAsync(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(ImageAddModel imageAddModel)
        {
            if (imageAddModel.Image != null)
            {

                if (imageAddModel.Image.ContentType != "image/jpeg")
                {
                    return BadRequest("Uygunsuz dosya türü");
                }
                var newName = Guid.NewGuid() + Path.GetExtension(imageAddModel.Image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img" + newName);
                var stream = new FileStream(path, FileMode.Create);

                await imageAddModel.Image.CopyToAsync(stream);

                imageAddModel.ImagePath = newName;

                await _genericService.AddAsync(new Entities.Concrete.Image
                {
                    Name = imageAddModel.Name,
                    ImagePath = imageAddModel.ImagePath
                });
                return Created("", imageAddModel);

            }
            return BadRequest("Resim dosyası yok");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _genericService.DeleteAsync(new Entities.Concrete.Image { Id = id });
                return NoContent();
            } 
            else
            {
                return BadRequest();
            }
           
        }
    }
}
