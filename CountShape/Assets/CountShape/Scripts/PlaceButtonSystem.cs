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
            var answerButton = false;

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
                            answerButton = true;
                        }

                    }



                }


            });

            //Entities.WithAll<PlaceButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction) =>
            //{
            //    answerButton = pointerInteraction.clicked;

            //});

            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            if (answerButton)
            {
                config.place = true;
                tinyEnv.SetConfigData(config);
            }

        }
    }

}
