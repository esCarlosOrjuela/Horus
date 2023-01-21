using System;
using System.Threading.Tasks;
using Horus.Interfaces;

namespace Horus.Services
{
    public class AutenticationUser : IAutenticationUser
    {
        public Task<bool> UserSignIn(string user, string pass)
        {
            throw new NotImplementedException();
        }
    }
}

