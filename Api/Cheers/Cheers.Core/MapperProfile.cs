

using AutoMapper;
using Cheers.Core.DTOs;
using Cheers.Core.Entities;

namespace Cheers.Core
{
   public class MapperProfile:Profile
    {

        public MapperProfile()
        {
            CreateMap<ContactsDTOs, Contacts>().ReverseMap();
            CreateMap<FamilyDetailDTOs, FamilyDetail>().ReverseMap();
            CreateMap<MaleDTOs, Male>().ReverseMap();
            CreateMap<MatchMakerDTOs, MatchMaker>().ReverseMap();
            CreateMap<MatchMakingDTOs, MatchMaker>().ReverseMap();
            CreateMap<MeetingDTOs, Meeting>().ReverseMap();
            CreateMap<WomanDTOs, Woman>().ReverseMap();
        }
    
    }
}
