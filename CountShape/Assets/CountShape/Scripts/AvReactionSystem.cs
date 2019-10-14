using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Text;
using System;

namespace CountShape
{   
    public class AvReactionSystem : ComponentSystem
    {
        //float amountTime = 0;// cant use float to string

        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (config.ThinkingPhase)
            {
                config.AvReactionTime += World.TinyEnvironment().frameDeltaTime;
                tinyEnv.SetConfigData(config);
            }

            Entities.ForEach((Entity entity, ref AverageText averageText) =>
            {


                int integer = (int)config.AvReactionTime;
                double decimals = config.AvReactionTime - integer;

                decimals = Math.Floor(decimals * 10);

                int integer2 = (int)decimals;

                //string st = "";
                //EntityManager.SetBufferFromString<TextString>(entity, st);

            });

        }
    }
}

