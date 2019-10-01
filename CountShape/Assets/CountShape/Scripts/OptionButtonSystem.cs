using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;

namespace CountShape
{

    public class OptionButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            bool opitonButton = false;
            Entities.WithAll<OptionButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction, ref Sprite2DRenderer sprite) =>
            {
                if (pointerInteraction.clicked)
                {
                    opitonButton = true;
                    sprite.color.a = 0;
                    pointerInteraction.clicked = false;
                }


            });


            if (opitonButton)
            {
              

                Entities.ForEach((DynamicBuffer<DifficultyButtons> segments) =>
                {
                    for (int i = 0; i < segments.Length; i++)
                    {
                        var sprite2D = EntityManager.GetComponentData<Sprite2DRenderer>(segments[i].difficulty);
                        sprite2D.color.a = 1;
                        EntityManager.SetComponentData(segments[i].difficulty, sprite2D);
                    }


                });

                Entities.ForEach((Entity _entity, ref StartButton start, ref Sprite2DRenderer _sprite2D) =>
                {
                    _sprite2D.color.a = 0;

                });


                Entities.ForEach((Entity _entity, ref BackButton backButton, ref Sprite2DRenderer _sprite2D) =>
                {
                    _sprite2D.color.a = 1;

                });

                Entities.ForEach((Entity _entity, ref ARbutton arbutton, ref Sprite2DRenderer _sprite2D) =>
                {
                    _sprite2D.color.a = 1;

                });



            }
        }
    }
}


