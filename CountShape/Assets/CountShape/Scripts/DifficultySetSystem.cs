using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.UIControls;

namespace CountShape
{
    public class DifficultySetSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {

            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            var answerButton = false;

            if (config.place)
                return;

            Entities.ForEach((DynamicBuffer<DifficultyButtons> segments) =>
            {
                for (int i = 0; i < segments.Length; i++)
                {

                    var pointerInteraction = EntityManager.GetComponentData<PointerInteraction>(segments[i].difficulty);
                    var optionDifficulty = EntityManager.GetComponentData<OptionDifficulty>(segments[i].difficulty);
                    if (pointerInteraction.clicked)
                    {
                        pointerInteraction.clicked = false;

                        if (optionDifficulty.difficulty == 0)//easy
                        {
                            config.difficulty = 8;
                            config.speed = 0.5f;
                        }
                        else if (optionDifficulty.difficulty == 1)//easy
                        {
                            config.difficulty = 12;
                            config.speed = 1;
                        }
                        else if (optionDifficulty.difficulty == 2)//easy
                        {
                            config.difficulty = 16;
                            config.speed = 2;
                        }
                        tinyEnv.SetConfigData(config);
                        answerButton = true;
                    }
                }

            });

            if (answerButton)
            {

            }




        }
    }
}

