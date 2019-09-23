using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;
using Unity.Tiny.Input;
using Unity.Tiny.Text;
namespace CountShape
{
    public class ShapeSetSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            //    var tinyEnv = World.TinyEnvironment();
            //    var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            //    Entities.WithAll<Count>().ForEach((Entity entity) =>
            //    {
            //        int num = config.maxCount;
            //        EntityManager.SetBufferFromString<TextString>(entity, num.ToString());

            //    });
        }
    }
}

