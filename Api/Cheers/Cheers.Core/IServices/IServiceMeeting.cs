using Cheers.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheers.Core.IServices
{
   public interface IServiceMeeting
    {
        public Task<IEnumerable<MeetingDTOs>> GetListOfMeetingAsync();
        public Task<MeetingDTOs> GetMeetingByIdAsync(int id);
        public Task<MeetingDTOs> AddMeetingAsync(MeetingDTOs women);
        public Task<MeetingDTOs> DeleteMeetingAsync(int id);
        public Task<MeetingDTOs> UpdateMeetingAsync(int id, MeetingDTOs women);
    }
}
