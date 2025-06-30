using AutoMapper;
using SyncDeal.Communication.Requests;
using SyncDeal.Communication.Responses;
using SyncDeal.Domain.Entities;

namespace SyncDeal.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestRegisterUserDTO, User>();
        }

        private void EntityToResponse()
        {
            CreateMap<User, ResponseUserDTO>();
        }
    }
}
