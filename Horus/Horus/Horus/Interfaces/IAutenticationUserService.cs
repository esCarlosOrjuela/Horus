using System;
using System.Threading.Tasks;

namespace Horus.Interfaces
{
    public interface IAutenticationUserService
    {
        Task<bool> UserSignIn(string user, string pass);
    }
}

