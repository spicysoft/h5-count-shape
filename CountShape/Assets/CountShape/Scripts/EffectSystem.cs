using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.Text;
using Unity.Mathematics;
namespace CountShape
{
    public class EffectSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();

            Entities.ForEach((Entity _entity, ref AnswerText answerText) =>
            {

                Entities.ForEach((Entity entity, ref Effect effect, ref Sprite2DRenderer sprite2D) =>
                {
                    if (config.effect)
                    {
                        
                        sprite2D.color.a = 1;
                        if (config.efCorrect)
                        {
                            sprite2D.color = new Color(108 / 255f, 188 / 255f, 168 / 255f);
                            sprite2D.sprite = effect.Correct.sprite;
                        }
                        else
                        {
                            sprite2D.color = new Color(188 / 255f, 108 / 255f, 112 / 255f);
                            EntityManager.SetBufferFromString<TextString>(_entity, "A." + config.maxCount.ToString());
                            sprite2D.sprite = effect.Wrong.sprite;
                        }

                    }
                    else
                    {
                        EntityManager.SetBufferFromString<TextString>(_entity, "");
                        sprite2D.color.a = 0;
                    }

                });

            });
        }
    }
}

