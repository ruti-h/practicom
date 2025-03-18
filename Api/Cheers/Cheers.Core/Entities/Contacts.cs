using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheers.Core.Entities
{
    public class Contacts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public int? MaleId { get; set; }
        public Male? Male { get; set; }

        public int? WomenId { get; set; }
        public Woman? Women { get; set; }

        public int? MatchMakerId { get; set; }
        public MatchMaker? MatchMaker { get; set; }
    }
}
