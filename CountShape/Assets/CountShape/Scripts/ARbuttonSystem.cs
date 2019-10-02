using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.UIControls;


namespace CountShape
{
    public class ARbuttonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();


            Entities.ForEach((DynamicBuffer<AddReductButtons> segments) =>
            {
                for (int i = 0; i < segments.Length; i++)
                {

                    var pointerInteraction = EntityManager.GetComponentData<PointerInteraction>(segments[i].arButton);
                    var _arbutton = EntityManager.GetComponentData<ARbutton>(segments[i].arButton);
                    if (pointerInteraction.clicked)
                    {
                        pointerInteraction.clicked = false;

                        config.MaxRound += _arbutton.direction;

                        if(config.MaxRound > 20)
                        {
                            config.MaxRound = 5;
                        }
                        else if (config.MaxRound < 5)
                        {
                            config.MaxRound = 20;
                        }
                       
                    }

                    tinyEnv.SetConfigData(config);
                }

            });
        }
    }
}

