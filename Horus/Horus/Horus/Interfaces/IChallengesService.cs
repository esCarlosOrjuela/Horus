using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Horus.Entities.AnswersService;
using Horus.MVVM.Model;

namespace Horus.Interfaces
{
    public interface IChallengesService
    {
        Task<List<ChallengeModel>> GetChallenges();
    }
}

