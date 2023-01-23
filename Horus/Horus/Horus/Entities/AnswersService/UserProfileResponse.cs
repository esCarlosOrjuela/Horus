using System;
namespace Horus.Entities.AnswersService
{
    public class UserProfileResponse
    {
        public string email { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string authorizationToken { get; set; }
    }
}

