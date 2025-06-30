using SyncDeal.Communication.Requests;
using SyncDeal.Communication.Responses;

namespace SyncDeal.Application.UseCases.User.Register
{
    public interface IRegisterUseCase
    {
        public Task<ResponseUserDTO> Execute(RequestRegisterUserDTO request);
    }
}
