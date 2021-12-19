using ImageUploadProject.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Add(Entities.Concrete.Image image)
        {
            await _genericService.AddAsync(image);
            return Ok();
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
