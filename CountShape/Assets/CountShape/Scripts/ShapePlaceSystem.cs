using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;
using Unity.Tiny.Input;

namespace CountShape
{
    public class ShapePlaceSystem : ComponentSystem
    {


        private Random _random;
        int shapeNum;

        float interval = 1;
        float time;

        protected override void OnCreate()
        {
            _random = new Random();
            _random.InitState();
            time = interval;
        }
        protected override void OnUpdate()
        {

            var inputSystem = World.GetExistingSystem<InputSystem>();
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();



            if (!config.place)
                return;


            

            if(config.rounds != 0) //dont wait one second, if it is first round
            {
                time -= World.TinyEnvironment().frameDeltaTime;//wait  for one second
                config.effect = true;
                tinyEnv.SetConfigData(config);
                if (time > 0)

                    return;
            }
            config.effect = false;
            config.place = false;
            config.rounds++;
            tinyEnv.SetConfigData(config);

            Entities.ForEach((DynamicBuffer<Shapes> segments) =>
            {

                time = interval;
                config.maxCount = _random.NextInt(5,6);
                shapeNum = _random.NextInt(0, 9);
                config.text = true;
                if (config.rounds <= config.MaxRound)
                {
                    config.ThinkingPhase = true;
                }

                tinyEnv.SetConfigData(config);
                for (int i = 0; i < segments.Length; i++)
                {
                    
                    var shape = EntityManager.GetComponentData<Shape>(segments[i].Reference);
                    var translation = EntityManager.GetComponentData<Translation>(segments[i].Reference);
                    var sprite2D = EntityManager.GetComponentData<Sprite2DRenderer>(segments[i].Reference);

                    switch (shapeNum)
                    {
                        case 0:

                            sprite2D.sprite = shape.sprite0.sprite;

                            break;

                        case 1 :

                            sprite2D.sprite = shape.sprite1.sprite;

                            break;

                        case 2:

                            sprite2D.sprite = shape.sprite2.sprite;

                            break;

                        case 3:

                            sprite2D.sprite = shape.sprite3.sprite;

                            break;

                        case 4:

                            sprite2D.sprite = shape.sprite4.sprite;

                            break;

                        case 5:

                            sprite2D.sprite = shape.sprite5.sprite;

                            break;

                        case 6:

                            sprite2D.sprite = shape.sprite6.sprite;

                            break;

                        case 7:

                            sprite2D.sprite = shape.sprite7.sprite;

                            break;

                        case 8:

                            sprite2D.sprite = shape.sprite8.sprite;

                            break;


                    }

                    if(config.rounds > config.MaxRound) //if it is Maxround, shapes doesnt show up
                    {

                            sprite2D.color.a = 0;
                            EntityManager.SetComponentData(segments[i].Reference, sprite2D);

                    }

                    if (i < config.maxCount)
                    {
                        translation.Value = _random.NextInt3(new int3(x: -10, y: 0, z: 0), new int3(x: 10, y: 18, z: 0));
                        EntityManager.SetComponentData(segments[i].Reference, translation);
                        EntityManager.SetComponentData(segments[i].Reference, shape);
                        EntityManager.SetComponentData(segments[i].Reference, sprite2D);
                    }

                    else if (i >= config.maxCount)
                    {
                        translation.Value = new int3(0,25,0);
                        EntityManager.SetComponentData(segments[i].Reference, translation);
                        EntityManager.SetComponentData(segments[i].Reference, shape);
                        EntityManager.SetComponentData(segments[i].Reference, sprite2D);
                    }

                }

                
            });
        }

    }
}

