

using Cheers.Core.Entities;
using Cheers.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Cheers.Data.Repositories
{
    public class RepositoryMeeting: IRepositoryMeeting
    {
         private readonly DataContext _context;

            public RepositoryMeeting(DataContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Meeting>> GetListOfMeetingAsync()
            {
                return await _context.Meetings
                    .Include(m => m.MatchMaking) // כולל את המידע על השידוכים
                    .ToListAsync();
            }

            public async Task<Meeting> GetMeetingByIdAsync(int id)
            {
                return await _context.Meetings
                    .Include(m => m.MatchMaking)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }

            public async Task<Meeting> AddMeetingAsync(Meeting meeting)
            {
                _context.Meetings.Add(meeting);
                await _context.SaveChangesAsync();
                return meeting;
            }

            public async Task<Meeting> DeleteMeetingAsync(int id)
            {
                var meeting = await _context.Meetings.FindAsync(id);
                if (meeting != null)
                {
                    _context.Meetings.Remove(meeting);
                    await _context.SaveChangesAsync();
                }
                return meeting;
            }

            public async Task<Meeting> UpdateMeetingAsync(int id, Meeting meeting)
            {
                var existingMeeting = await GetMeetingByIdAsync(id);
                if (existingMeeting != null)
                {
                    _context.Entry(existingMeeting).CurrentValues.SetValues(meeting);
                    await _context.SaveChangesAsync();
                }
                return existingMeeting;
            }
        }
    }
