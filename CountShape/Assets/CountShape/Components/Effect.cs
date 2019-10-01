using Unity.Entities;
using Unity.Tiny.Core2D;
namespace CountShape {
    public struct Effect : IComponentData
    {
        public bool tes;
        public Sprite2DRenderer Correct;
        public Sprite2DRenderer Wrong;

    }
}


