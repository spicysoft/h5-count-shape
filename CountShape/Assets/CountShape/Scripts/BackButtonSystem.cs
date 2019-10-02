using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;
using Unity.Tiny.Text;

namespace CountShape
{
    public class BackButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            bool backButton = false;
            Entities.WithAll<BackButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction, ref Sprite2DRenderer sprite) =>
            {
                if (pointerInteraction.clicked)
                {
                    backButton = true;
                    pointerInteraction.clicked = false;
                    sprite.color.a = 0f;
                }


            });


            if (backButton)
            {
                config.optionMode = false;
                Entities.ForEach((DynamicBuffer<DifficultyButtons> segments) =>
                {
                    for (int i = 0; i < segments.Length; i++)
                    {
                        var sprite2D = EntityManager.GetComponentData<Sprite2DRenderer>(segments[i].difficulty);
                        sprite2D.color.a = 0;
                        EntityManager.SetComponentData(segments[i].difficulty, sprite2D);
                    }

                });

                Entities.ForEach((Entity _entity, ref StartButton start, ref Sprite2DRenderer _sprite2D) =>
                {
                    _sprite2D.color.a = 1;

                });

                Entities.ForEach((Entity _entity, ref OptionButton option, ref Sprite2DRenderer _sprite2D) =>
                {
                    _sprite2D.color.a = 1;

                });
                Entities.ForEach((Entity _entity, ref ARbutton arbutton, ref Sprite2DRenderer _sprite2D) =>
                {
                    _sprite2D.color.a = 0;

                });
                tinyEnv.SetConfigData(config);
            }
        }
    }

}

