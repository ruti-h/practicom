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
    public class MeetingController : ControllerBase
    {
        private readonly IServiceMeeting _meetingService;
        private readonly IMapper _mapper;

        public MeetingController(IServiceMeeting meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }

        // GET: api/meeting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingDTOs>>> GetMeetings()
        {
            var meetings = await _meetingService.GetListOfMeetingAsync();
            return Ok(meetings);
        }

        // GET: api/meeting/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDTOs>> GetMeeting(int id)
        {
            var meeting = await _meetingService.GetMeetingByIdAsync(id);
            if (meeting == null) return NotFound();
            return Ok(meeting);
        }

        // POST: api/meeting
        [HttpPost]
        public async Task<ActionResult<MeetingDTOs>> PostMeeting([FromBody]MeetingModel  meeting)
        {
            if (meeting == null) return BadRequest("Meeting model cannot be null.");

            var meetingModel = _mapper.Map<MeetingDTOs>(meeting); // מיפוי מ-MeetingDTOs ל-Meeting
            var addedMeeting = await _meetingService.AddMeetingAsync(meetingModel);
            var addedMeetingDto = _mapper.Map<MeetingDTOs>(addedMeeting); // מיפוי חזרה ל-MeetingDTOs

            return CreatedAtAction(nameof(GetMeeting), new { id = addedMeetingDto.Id }, addedMeetingDto);
        }

        // PUT: api/meeting/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<MeetingDTOs>> PutMeeting(int id, [FromBody]MeetingModel  meeting)
        {
            if (meeting == null) return BadRequest("Meeting model cannot be null.");

            var meetingModel = _mapper.Map<MeetingDTOs>(meeting); // מיפוי ל-Meeting
            var updatedMeeting = await _meetingService.UpdateMeetingAsync(id, meetingModel);
            if (updatedMeeting == null) return NotFound();

            var updatedMeetingDto = _mapper.Map<MeetingDTOs>(updatedMeeting); // מיפוי חזרה ל-MeetingDTOs
            return Ok(updatedMeetingDto);
        }

        // DELETE: api/meeting/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeetingDTOs>> DeleteMeeting(int id)
        {
            var deletedMeeting = await _meetingService.DeleteMeetingAsync(id);
            if (deletedMeeting == null) return NotFound();

            var deletedMeetingDto = _mapper.Map<MeetingDTOs>(deletedMeeting); // מיפוי חזרה ל-MeetingDTOs
            return Ok(deletedMeetingDto);
        }
    }
}
