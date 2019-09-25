using Unity.Entities;

namespace CountShape
{
    public struct GameConfig : IComponentData
    {
        public bool start;
        public bool text;
        public bool place;

        public int rounds;
        public int MaxRound;

        public int maxCount;

        public bool ThinkingPhase;

        //Result

        public float AvReactionTime;
        public int CorrectCounts;
    }

}
