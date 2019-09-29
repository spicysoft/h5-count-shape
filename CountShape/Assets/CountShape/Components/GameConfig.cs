using Unity.Entities;

namespace CountShape
{
    public struct GameConfig : IComponentData
    {
        public bool start;
        public bool text;
        public bool place;
        public bool efCorrect;

        public int rounds;
        public int MaxRound;

        public int maxCount;

        public bool ThinkingPhase;

        public bool effect;
        //Result

        public double AvReactionTime;
        public int CorrectCounts;
    }

}
