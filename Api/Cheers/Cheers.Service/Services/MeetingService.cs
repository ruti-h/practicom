using AutoMapper;
using Cheers.Core.DTOs;
using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Cheers.Core.IServices;


namespace Cheers.Service.Services
{
  public  class MeetingService:IServiceMeeting
    {
        private readonly IRepositoryMeeting _repository;
        private readonly IMapper _mapper;

        public MeetingService(IRepositoryMeeting repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MeetingDTOs>> GetListOfMeetingAsync()
        {
            var meetings = await _repository.GetListOfMeetingAsync();
            return _mapper.Map<IEnumerable<MeetingDTOs>>(meetings);
        }

        public async Task<MeetingDTOs> GetMeetingByIdAsync(int id)
        {
            var meeting = await _repository.GetMeetingByIdAsync(id);
            return _mapper.Map<MeetingDTOs>(meeting);
        }

        public async Task<MeetingDTOs> AddMeetingAsync(MeetingDTOs meetingDto)
        {
            var meeting = _mapper.Map<Meeting>(meetingDto);
            var addedMeeting = await _repository.AddMeetingAsync(meeting);
            return _mapper.Map<MeetingDTOs>(addedMeeting);
        }

        public async Task<MeetingDTOs> DeleteMeetingAsync(int id)
        {
            var deletedMeeting = await _repository.DeleteMeetingAsync(id);
            return _mapper.Map<MeetingDTOs>(deletedMeeting);
        }

        public async Task<MeetingDTOs> UpdateMeetingAsync(int id, MeetingDTOs meetingDto)
        {
            var meeting = _mapper.Map<Meeting>(meetingDto);
            var updatedMeeting = await _repository.UpdateMeetingAsync(id, meeting);
            return _mapper.Map<MeetingDTOs>(updatedMeeting);
        }
    }
}
