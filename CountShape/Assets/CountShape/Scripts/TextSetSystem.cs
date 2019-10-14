using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Text;
using Unity.Mathematics;
namespace CountShape
{
    public class TextSetSystem : ComponentSystem
    {
        int correctNum = 2;
        int num ;

        private Random _random;
        //int shapeNum;

        protected override void OnCreate()
        {
            _random = new Random();
            _random.InitState();
        }


        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (!config.text)
                return;
            config.text = false;
            tinyEnv.SetConfigData(config);

            correctNum = _random.NextInt(0, 4);

            Entities.ForEach((DynamicBuffer<Answers> segments) =>
            {
                for (int i = 0; i < segments.Length; i++)
                {
                    var placeButton = EntityManager.GetComponentData<PlaceButton>(segments[i].answwer);
                    if (i == correctNum)
                    {
                        placeButton.Correct = true;
                        EntityManager.SetComponentData(segments[i].answwer, placeButton);
                    }

                    if (i != correctNum)
                    {
                        placeButton.Correct = false;
                        EntityManager.SetComponentData(segments[i].answwer, placeButton);
                    }

                }

            });


            Entities.ForEach((DynamicBuffer<CountTexts> segments) =>
            {

                for (int i = 0; i < segments.Length; i++)
                {

                    if (i == 0)
                    {
                        num = config.maxCount - correctNum;
                        EntityManager.SetBufferFromString<TextString>(segments[i].coutText, num.ToString());
                    }

                    else
                    {
                        num ++;
                        EntityManager.SetBufferFromString<TextString>(segments[i].coutText, num.ToString());

                    }

                }

            });

        }
    }
}
