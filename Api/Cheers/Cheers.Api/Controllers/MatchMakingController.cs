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
    public class MatchMakingController : ControllerBase
    {
        private readonly IServiceMatchMaking _matchMakingService; // הוסף את השירות
        private readonly IMapper _mapper; // הוסף את ה-IMapper

        public MatchMakingController(IServiceMatchMaking matchMakingService, IMapper mapper) // הוסף את השירות וה-Mapper לקונסטרוקטור
        {
            _matchMakingService = matchMakingService;
            _mapper = mapper;
        }

        // GET: api/matchmaking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchMakingDTOs>>> Get()
        {
            var matchMakings = await _matchMakingService.GetListOfMatchMakingAsync();
            return Ok(matchMakings); // לא צריך למפות כאן כי כבר מחזירים DTOs
        }

        // GET api/matchmaking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchMakingDTOs>> Get(int id)
        {
            var matchMaking = await _matchMakingService.GetMatchMakingByIdAsync(id);
            if (matchMaking == null)
            {
                return NotFound();
            }
            return Ok(matchMaking); // לא צריך למפות כאן כי כבר מחזירים DTO
        }

        //// POST api/matchmaking
        //[HttpPost]
        //public async Task<ActionResult<MatchMakingDTOs>> Post([FromBody]MatchMakingModel  matchMakingDto)
        //{
        //    var matchMakingEntity = _mapper.Map<MatchMakingDTOs>(matchMakingDto); // מיפוי מ-MatchMakingDTOs ל-MatchMakingModel
        //    var addedMatchMaking = await _matchMakingService.AddMatchMakingAsync(matchMakingEntity);
        //    var addedMatchMakingDto = _mapper.Map<MatchMakingDTOs>(addedMatchMaking); // מיפוי חזרה ל-MatchMakingDTOs
        //    return CreatedAtAction(nameof(Get), new { id = addedMatchMakingDto.Id }, addedMatchMakingDto); // החזרה עם מיפוי
        //}
        // POST api/matchmaking
        [HttpPost]
        public async Task<ActionResult<MatchMakingDTOs>> Post([FromBody] MatchMaking matchMaking)
        {
            if (matchMaking == null) return BadRequest("MatchMaking model cannot be null.");

            var matchMakingEntity = _mapper.Map<MatchMakingDTOs>(matchMaking); // מיפוי מ-MatchMakingDTOs ל-MatchMakingModel
            var addedMatchMaking = await _matchMakingService.AddMatchMakingAsync(matchMakingEntity);

            if (addedMatchMaking == null)
                return Conflict("MatchMaking entry already exists."); // החזרת קוד 409 במקרה של קונפליקט

            var addedMatchMakingDto = _mapper.Map<MatchMakingDTOs>(addedMatchMaking); // מיפוי חזרה ל-MatchMakingDTOs
            return CreatedAtAction(nameof(Get), new { id = addedMatchMakingDto.Id }, addedMatchMakingDto); // החזרה עם המידע החדש
        }


        // PUT api/matchmaking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MatchMaking matchMakingDto)
        {
            var matchMakingEntity = _mapper.Map<MatchMakingDTOs>(matchMakingDto); // מיפוי מ-MatchMakingDTOs ל-MatchMakingModel
            var updatedMatchMaking = await _matchMakingService.UpdateMatchMakingAsync(id, matchMakingEntity);
            if (updatedMatchMaking == null)
            {
                return NotFound();
            }
            var updatedMatchMakingDto = _mapper.Map<MatchMakingDTOs>(updatedMatchMaking); // מיפוי חזרה ל-MatchMakingDTOs
            return Ok(updatedMatchMakingDto); // החזרה עם המידע המעודכן
        }

        // DELETE api/matchmaking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedMatchMaking = await _matchMakingService.DeleteMatchMakingAsync(id);
            if (deletedMatchMaking == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
