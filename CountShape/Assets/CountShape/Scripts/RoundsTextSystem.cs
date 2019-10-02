using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Text;

namespace CountShape
{
    public class RoundsTextSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            Entities.ForEach((Entity entity, ref RoundsText roundsText) =>
            {
                if (config.optionMode)
                {
                    EntityManager.SetBufferFromString<TextString>(entity, config.MaxRound.ToString());
                }
                else
                
                {
                    EntityManager.SetBufferFromString<TextString>(entity, "");
                }


            });
        }
    }
}


