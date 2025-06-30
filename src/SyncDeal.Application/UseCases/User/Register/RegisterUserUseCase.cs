using AutoMapper;
using SyncDeal.Application.UseCases.User.Register;
using SyncDeal.Communication.Requests;
using SyncDeal.Communication.Responses;
using SyncDeal.Domain.Repositories;
using SyncDeal.Exceptions.Errors;

namespace SyncDeal.Application.UseCases.User.Create
{
    public class RegisterUserUseCase : IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserUseCase(
            IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseUserDTO> Execute(RequestRegisterUserDTO request)
        {
            Validate(request);

            var entity = _mapper.Map<SyncDeal.Domain.Entities.User>(request);
            var createdEntity = await _userRepository.Add(entity);

            await _unitOfWork.Commit();

            return _mapper.Map<ResponseUserDTO>(createdEntity);
        }

        private void Validate(RequestRegisterUserDTO request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if(!result.IsValid)
            {
                List<string> errors = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
