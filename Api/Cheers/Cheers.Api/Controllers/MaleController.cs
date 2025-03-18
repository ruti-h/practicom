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
    public class MaleController : ControllerBase
    {
        private readonly IServiceMale _maleService; // הוסף את השירות
        private readonly IMapper _mapper; // הוסף את ה-IMapper

        public MaleController(IServiceMale maleService, IMapper mapper) // הוסף את השירות וה-Mapper לקונסטרוקטור
        {
            _maleService = maleService;
            _mapper = mapper;
        }

        // GET: api/male
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaleDTOs>>> Get()
        {
            var males = await _maleService.GetListOfMaleAsync();
            return Ok(males); // לא צריך למפות כאן כי כבר מחזירים DTOs
        }

        // GET api/male/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaleDTOs>> Get(int id)
        {
            var male = await _maleService.GetMaleByIdAsync(id);
            if (male == null)
            {
                return NotFound();
            }
            return Ok(male); // לא צריך למפות כאן כי כבר מחזירים DTO
        }

        // POST api/male
        [HttpPost]
        public async Task<ActionResult<MaleDTOs>> Post([FromBody]MaleModel  male)
        {
            var maleEntity = _mapper.Map<MaleDTOs>(male); // מיפוי מ-MaleDTOs ל-Male
            var addedMale = await _maleService.AddMaleAsync(maleEntity);
            var addedMaleDto = _mapper.Map<MaleDTOs>(addedMale); // מיפוי חזרה ל-MaleDTOs
            return CreatedAtAction(nameof(Get), new { id = addedMaleDto.Id }, addedMaleDto); // החזרה עם מיפוי
        }

        // PUT api/male/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]MaleModel  male)
        {
            var maleEntity = _mapper.Map<MaleDTOs>(male); // מיפוי מ-MaleDTOs ל-Male
            var updatedMale = await _maleService.UpdateMaleAsync(id, maleEntity);
            if (updatedMale == null)
            {
                return NotFound();
            }
            var updatedMaleDto = _mapper.Map<MaleDTOs>(updatedMale); // מיפוי חזרה ל-MaleDTOs
            return Ok(updatedMaleDto); // החזרה עם המידע המעודכן
        }

        // DELETE api/male/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedMale = await _maleService.DeleteMaleAsync(id);
            if (deletedMale == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
