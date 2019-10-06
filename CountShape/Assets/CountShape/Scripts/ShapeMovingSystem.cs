using Unity.Entities;
using Unity.Mathematics;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
namespace CountShape
{
    public class ShapeMovingSystem : ComponentSystem
    {

        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();


            Entities.ForEach((DynamicBuffer<Shapes> segments) =>
            {

                for (int i = 0; i < segments.Length; i++)
                {
                    var shape = EntityManager.GetComponentData<Shape>(segments[i].Reference);
                    var translation = EntityManager.GetComponentData<Translation>(segments[i].Reference);
                    var position = translation.Value;


                    if (i < config.maxCount)
                    {
                        if (config.ThinkingPhase)
                        {
                            position += shape.direction * config.speed * World.TinyEnvironment().frameDeltaTime;


                            if (translation.Value.y >= 12)
                            {
                                shape.direction = new int3(0, -1, 0);
                            }

                            else if (translation.Value.y <= 0)
                            {
                                shape.direction = new int3(0, 1, 0);
                            }
                            else if (translation.Value.x >= 10)
                            {
                                shape.direction = new int3(-1, 0, 0);
                            }
                            else if (translation.Value.x <= -10)
                            {
                                shape.direction = new int3(1, 0, 0);
                            }


                        }

                        else
                        {
                            position += 0;
                        }



                    }

                    else
                    {
                        shape.direction = new int3 (0, 0, 0);
                    }




                    translation.Value = position;
                    EntityManager.SetComponentData(segments[i].Reference, translation);
                    EntityManager.SetComponentData(segments[i].Reference, shape);
                }
            });


        }
    }
}

