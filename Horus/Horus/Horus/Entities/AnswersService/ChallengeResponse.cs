using System;
using Horus.MVVM.Model;

namespace Horus.Entities.AnswersService
{
    public class ChallengeResponse
    {
        public string id { get; set; }
        public string title { get; set; }
        public int totalPoints { get; set; }
        public int currentPoints { get; set; }
        public string description { get; set; }

        public static explicit operator ChallengeModel(ChallengeResponse challengeResponse)
        {
            ChallengeModel output = new ChallengeModel()
            {
                Id = challengeResponse.id,
                Title = challengeResponse.title,
                Description = challengeResponse.description,
                Total = challengeResponse.totalPoints,
                Completed = challengeResponse.currentPoints
            };
            return output;
        }
    }
}

