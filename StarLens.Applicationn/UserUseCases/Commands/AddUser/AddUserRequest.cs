using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.UserUseCases.Commands.AddUser
{
    public sealed record AddUserRequest(string nickname, string email, string password) : IRequest<User>
    { }
}
