using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions.Interfaces
{
    public interface IUserService
    {
        IServiceResult CreateUser(IDTOModel newUser);

        IServiceResult<IDTOModel> GetUser(Func<User, bool> condition);
    }
}
