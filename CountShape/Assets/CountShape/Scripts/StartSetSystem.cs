using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.Input;
using Unity.Tiny.Text;

namespace CountShape
{
    public class StartSetSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var inputSystem = World.GetExistingSystem<InputSystem>();
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();



            if (!config.start)
                return;


            config.start = false;


            Entities.ForEach((Entity entity, ref PlaceButton place, ref Sprite2DRenderer sprite2D) =>
            {
                sprite2D.color.a = 1;
            });
            Entities.ForEach((Entity entity, ref Count count, ref Text2DStyle text2DStyle) =>
            {
                text2DStyle.color.a = 1;
            });
            Entities.ForEach((Entity _entity, ref StartButton start, ref Sprite2DRenderer _sprite2D) =>
            {
                _sprite2D.color.a = 0;

            });
            Entities.ForEach((DynamicBuffer<Shapes> segments) =>
            {
                for (int i = 0; i < segments.Length; i++)
                {
                    var sprite2D = EntityManager.GetComponentData<Sprite2DRenderer>(segments[i].Reference);
                    sprite2D.color.a = 1;
                    EntityManager.SetComponentData(segments[i].Reference, sprite2D);
                }

            });

            tinyEnv.SetConfigData(config);
        }






    }
}

