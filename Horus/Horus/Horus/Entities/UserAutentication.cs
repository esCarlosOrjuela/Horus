using System;
using Horus.Interfaces;

namespace Horus.Entities
{
    public class UserAutentication : IDataService
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

