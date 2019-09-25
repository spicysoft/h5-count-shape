using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.UIControls;
namespace CountShape
{

    public class PlaceButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()

        {

            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            var answerButton = false;

            if (config.place)
                return;
            Entities.ForEach((DynamicBuffer<Answers> segments) =>
            {
                for (int i = 0; i < segments.Length; i++)
                {

                    var pointerInteraction = EntityManager.GetComponentData<PointerInteraction>(segments[i].answwer);
                    var placebuttont = EntityManager.GetComponentData<PlaceButton>(segments[i].answwer);
                    if (pointerInteraction.clicked)
                    {
                        if (placebuttont.Correct)
                        {
                            config.CorrectCounts++;
                        }

                        answerButton = true;
                    }
                }

            });

           // var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (answerButton)
            {
                config.place = true;
                config.ThinkingPhase = false;
                tinyEnv.SetConfigData(config);
            }
        }
    }

}
