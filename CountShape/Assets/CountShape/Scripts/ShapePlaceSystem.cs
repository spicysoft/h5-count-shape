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

        protected override void OnCreate()
        {
            _random = new Random();
            _random.InitState();
        }
        protected override void OnUpdate()
        {

            var inputSystem = World.GetExistingSystem<InputSystem>();
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();



            if (!config.place)
                return;

            Entities.ForEach((DynamicBuffer<Shapes> segments) =>
            {
                config.place = false;
                config.maxCount = _random.NextInt(5,6);
                shapeNum = _random.NextInt(0, 9);
                config.text = true;
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
                    if(i < config.maxCount)
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

