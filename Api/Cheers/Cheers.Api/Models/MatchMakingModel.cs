namespace Cheers.Api.Models
{
    public class MatchMakingModel
    {
        public int Id { get; set; }
        public int MaleId { get; set; }
        public int WomenId { get; set; }
        public int MatchMakerId { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int? NumMeetings { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
