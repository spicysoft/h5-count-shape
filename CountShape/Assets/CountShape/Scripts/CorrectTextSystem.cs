using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Text;
namespace CountShape
{
    public class CorrectTextSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {

            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            Entities.ForEach((Entity entity, ref CorrectText correctText) =>
            {

                EntityManager.SetBufferFromString<TextString>(entity, " Correct:" + config.CorrectCounts.ToString());

            });




        }



    }
}

