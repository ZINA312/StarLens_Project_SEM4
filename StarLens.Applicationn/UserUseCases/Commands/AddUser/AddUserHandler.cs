using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.UserUseCases.Commands.AddUser
{
    internal class AddUserHandler : IRequestHandler<AddUserRequest, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            User newUser = new User(request.nickname, request.password, request.email);
            await _unitOfWork.UserRepository.AddAsync(newUser, cancellationToken);
            return newUser;
        }
    }
}
