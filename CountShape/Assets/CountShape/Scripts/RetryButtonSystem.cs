using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;
using Unity.Tiny.Text;

namespace CountShape
{
    public class RetryButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            var retryButton = false;

            Entities.WithAll<RetryButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction, ref Sprite2DRenderer sprite2D) =>
            {

                if (pointerInteraction.clicked)
                {
                    retryButton = true;
                    sprite2D.color.a = 0;
                    pointerInteraction.clicked = false;
                }

            });

            //var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (retryButton)
            {

                Entities.ForEach((Entity entity, ref StartButton start, ref Sprite2DRenderer sprite2D) =>
                {
                    sprite2D.color.a = 1f;
                });

                Entities.ForEach((Entity _entity, ref OptionButton option, ref Sprite2DRenderer _sprite2D) =>
                {
                    _sprite2D.color.a = 1;

                });

                Entities.ForEach((Entity _entity, ref Title title, ref Sprite2DRenderer _sprite2D) =>
                {
                    _sprite2D.color.a = 1;

                });

                Entities.ForEach((Entity _entity, ref Result result, ref Sprite2DRenderer _sprite2D) =>
                {
                    _sprite2D.color.a = 0;

                });
                Entities.ForEach((Entity entity, ref AverageText averageText) =>
                {

 
                    EntityManager.SetBufferFromString<TextString>(entity, "");

                });


                Entities.ForEach((Entity entity, ref AccuracyText accuracyText) =>
                {


                    EntityManager.SetBufferFromString<TextString>(entity, "");

                });
                config.CorrectCounts = 0;
                config.AvReactionTime = 0;
                tinyEnv.SetConfigData(config);
            }
        }
    }
}


