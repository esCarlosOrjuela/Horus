using System;
using Horus.Entities;

namespace Horus.MVVM.Model
{
    public class ChallengeModel : StyleChallengeItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Total { get; set; }
        public int Completed { get; set; }
        public string AmountCompleted { get { return Completed + "/" + Total; } }
        public float FloatCompleted { get { return (((float)Completed * 100) / Total) / 100; } }
        public string PercentageCompleted { get { return (int)((Completed * 100) / Total) + "%"; } }
    }
}

