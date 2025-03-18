using AutoMapper;
using Cheers.Api.Models;
using Cheers.Core.DTOs;
using Cheers.Core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cheers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WomanController : ControllerBase
    {
        private readonly IServiceWoman _womanService;
        private readonly IMapper _mapper;

        public WomanController(IServiceWoman womanService, IMapper mapper)
        {
            _womanService = womanService;
            _mapper = mapper;
        }

        // GET: api/woman
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WomanDTOs>>> GetWomen()
        {
            var women = await _womanService.GetListOfWomenAsync();
            return Ok(women);
        }

        // GET api/woman/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WomanDTOs>> GetWoman(int id)
        {
            var woman = await _womanService.GetWomenByIdAsync(id);
            if (woman == null) return NotFound();
            return Ok(woman);
        }

        // POST api/woman
        [HttpPost]
        public async Task<ActionResult<WomanDTOs>> PostWoman([FromBody]WomanModel  woman)
        {
            if (woman == null) return BadRequest("Woman model cannot be null.");

            var womanModel = _mapper.Map<WomanDTOs>(woman); // מיפוי מ-WomanDTOs ל-Woman
            var addedWoman = await _womanService.AddWomenAsync(womanModel);
            var addedWomanDto = _mapper.Map<WomanDTOs>(addedWoman); // מיפוי חזרה ל-WomanDTOs

            return CreatedAtAction(nameof(GetWoman), new { id = addedWomanDto.Id }, addedWomanDto);
        }

        // PUT api/woman/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<WomanDTOs>> PutWoman(int id, [FromBody]WomanModel  woman)
        {
            if (woman == null) return BadRequest("Woman model cannot be null.");

            var womanModel = _mapper.Map<WomanDTOs>(woman); // מיפוי ל-Woman
            var updatedWoman = await _womanService.UpdateWomenAsync(id, womanModel);
            if (updatedWoman == null) return NotFound();

            var updatedWomanDto = _mapper.Map<WomanDTOs>(updatedWoman); // מיפוי חזרה ל-WomanDTOs
            return Ok(updatedWomanDto);
        }

        // DELETE api/woman/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<WomanDTOs>> DeleteWoman(int id)
        {
            var deletedWoman = await _womanService.DeleteWomenAsync(id);
            if (deletedWoman == null) return NotFound();

            var deletedWomanDto = _mapper.Map<WomanDTOs>(deletedWoman); // מיפוי חזרה ל-WomanDTOs
            return Ok(deletedWomanDto);
        }
    }
}
