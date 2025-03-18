using AutoMapper;
using Cheers.Api.Models;
using Cheers.Core.DTOs;

namespace Cheers.Api
{
    public class MappingProfilePostModel:Profile
    {

        public MappingProfilePostModel()
        {
            CreateMap<ContactsModel, ContactsDTOs>().ReverseMap();
            CreateMap<FamilyDetailsModel,FamilyDetailDTOs>().ReverseMap();
            CreateMap<MaleModel,MaleDTOs>().ReverseMap();
            CreateMap<MatchmakerModel,MatchMakerDTOs>().ReverseMap();
            CreateMap<MatchMakingModel,MatchMakingDTOs>().ReverseMap();
            CreateMap<MeetingModel,MeetingDTOs>().ReverseMap();
            CreateMap<WomanModel,WomanDTOs>().ReverseMap();
        }
    }
}
