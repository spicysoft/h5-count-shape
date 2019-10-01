using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.Text;
using System;
namespace CountShape
{
    public class GameOverSystem : ComponentSystem
    {
        int MaxRound = 5;
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (config.rounds <= config.MaxRound)
                return;
            config.rounds = 0;



            Entities.ForEach((DynamicBuffer<Answers> segments) =>
            {
                for (int i = 0; i < segments.Length; i++)
                {
                    var sprite2D = EntityManager.GetComponentData<Sprite2DRenderer>(segments[i].answwer);
                    sprite2D.color.a = 0;
                    EntityManager.SetComponentData(segments[i].answwer, sprite2D);
                }

            });


            Entities.ForEach((DynamicBuffer<CountTexts> segments) =>
            {
                for (int i = 0; i < segments.Length; i++)
                {
                    //var sprite2D = EntityManager.GetComponentData<Text2DStyle>(segments[i].coutText);
                    //sprite2D.color.a = 0;
                    //EntityManager.SetComponentData(segments[i].coutText, sprite2D);


                    //string st = "";

                    EntityManager.SetBufferFromString<TextString>(segments[i].coutText, " ");


                }

            });

            Entities.ForEach((Entity entity, ref RetryButton retrybutton, ref Sprite2DRenderer sprite2D) =>
            {
                sprite2D.color.a = 1;
            });


            Entities.ForEach((Entity entity, ref AverageText averageText) =>
            {
                double avg = config.AvReactionTime / config.MaxRound;




                int integer = (int)avg;
                double decimals = avg - integer;

                decimals = Math.Floor(decimals * 10);

                int integer2 = (int)decimals;
                EntityManager.SetBufferFromString<TextString>(entity, integer.ToString() + "." + integer2.ToString());

            });

            Entities.ForEach((Entity entity, ref AccuracyText accuracyText) =>
            {
                double decimals = (double)config.CorrectCounts / (double)config.MaxRound;

                decimals = Math.Floor(decimals * 100);

                int accurate = (int)decimals;

                EntityManager.SetBufferFromString<TextString>(entity, accurate.ToString() + "%");



            });
            tinyEnv.SetConfigData(config);
        }
    }
}

