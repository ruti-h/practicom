using AutoMapper;
using Cheers.Core.DTOs;
using Cheers.Core.Entities;
using Cheers.Core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cheers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchMakerController : ControllerBase
    {
        private readonly IServiceMatchMaker _matchMakerService; // הוסף את השירות
        private readonly IMapper _mapper; // הוסף את ה-IMapper

        public MatchMakerController(IServiceMatchMaker matchMakerService, IMapper mapper) // הוסף את השירות וה-Mapper לקונסטרוקטור
        {
            _matchMakerService = matchMakerService;
            _mapper = mapper;
        }

        // GET: api/matchmaker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchMakerDTOs>>> Get()
        {
            var matchMakers = await _matchMakerService.GetListOfMatchMakerAsync();
            return Ok(matchMakers); // לא צריך למפות כאן כי כבר מחזירים DTOs
        }

        // GET api/matchmaker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchMakerDTOs>> Get(int id)
        {
            var matchMaker = await _matchMakerService.GetMatchMakerByIdAsync(id);
            if (matchMaker == null)
            {
                return NotFound();
            }
            return Ok(matchMaker); // לא צריך למפות כאן כי כבר מחזירים DTO
        }

        // POST api/matchmaker
        [HttpPost]
        public async Task<ActionResult<MatchMakerDTOs>> Post([FromBody]MatchMaker  matchMaker)
        {
            var matchMakerEntity = _mapper.Map<MatchMakerDTOs>(matchMaker); // מיפוי מ-MatchMakerDTOs ל-MatchMakerModel
            var addedMatchMaker = await _matchMakerService.AddMatchMakerAsync(matchMakerEntity);
            var addedMatchMakerDto = _mapper.Map<MatchMakerDTOs>(addedMatchMaker); // מיפוי חזרה ל-MatchMakerDTOs
            return CreatedAtAction(nameof(Get), new { id = addedMatchMakerDto.Id }, addedMatchMakerDto); // החזרה עם מיפוי
        }

        // PUT api/matchmaker/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]MatchMaker  matchMaker)
        {
            var matchMakerEntity = _mapper.Map<MatchMakerDTOs>(matchMaker); // מיפוי מ-MatchMakerDTOs ל-MatchMakerModel
            var updatedMatchMaker = await _matchMakerService.UpdateMatchMakerAsync(id, matchMakerEntity);
            if (updatedMatchMaker == null)
            {
                return NotFound();
            }
            var updatedMatchMakerDto = _mapper.Map<MatchMakerDTOs>(updatedMatchMaker); // מיפוי חזרה ל-MatchMakerDTOs
            return Ok(updatedMatchMakerDto); // החזרה עם המידע המעודכן
        }

        // DELETE api/matchmaker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedMatchMaker = await _matchMakerService.DeleteMatchMakerAsync(id);
            if (deletedMatchMaker == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
