using Unity.Entities;

namespace CountShape
{
    public struct GameConfig : IComponentData
    {
        public bool start;
        public bool text;
        public bool place;

        public int rounds;

        public int maxCount;
    }

}
