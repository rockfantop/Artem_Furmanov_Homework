using System.Collections.Generic;

namespace DI.App.Abstractions.BLL
{
    public interface IUserStore
    {
        IEnumerable<IUser> Users { get; }

        void AddUser(IUser user);

        IUser FindUserByName(string name);

        IUser FindUserById(int id);
    }
}