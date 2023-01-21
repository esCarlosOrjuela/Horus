using System;
using System.Threading.Tasks;

namespace Horus.Interfaces
{
    public interface IAutenticationUser
    {
        Task<bool> UserSignIn(string user, string pass);
    }
}

