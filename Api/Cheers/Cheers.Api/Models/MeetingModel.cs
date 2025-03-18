using System.ComponentModel.DataAnnotations;

namespace Cheers.Api.Models
{
    public class MeetingModel
    {
        //public int Id { get; set; }
        //public int MatchMakerId { get; set; }
        //public int CanditateId1 { get; set; }
        //public int CanditateId2 { get; set; }
        //public int NumMeeting { get; set; }
        //public DateTime MeetingDate { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string MeetingPlace { get; set; }


        public int Id { get; set; }
        public int? NumMeeting { get; set; }
        public DateTime? MeetingDate { get; set; }
        public string MeetingPlace { get; set; }
    }
}
