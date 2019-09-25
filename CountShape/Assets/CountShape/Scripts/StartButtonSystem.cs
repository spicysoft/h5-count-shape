using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;

namespace CountShape
{
    public class StartButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {

            var tinyEnv = World.TinyEnvironment();
            var startButton = false;
            Entities.WithAll<StartButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction) =>
            {
                if (pointerInteraction.clicked)
                {
                    startButton = true;
                    
                }


            });

            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (startButton)
            {
                config.start = true;
                config.place = true;
                tinyEnv.SetConfigData(config);
            }


        }
    }
}

