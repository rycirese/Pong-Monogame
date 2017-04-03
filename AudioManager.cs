using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using System.Collections.Generic;

namespace Pong
{
    public class AudioManager
    {
        IDictionary<string, SoundEffect> soundEffects;

        public AudioManager()
        {
            soundEffects = new Dictionary<string, SoundEffect>();
        }

        public void LoadContent(ContentManager Content)
        {
            soundEffects.Add("paddle", Content.Load<SoundEffect>("Sounds/ball_paddle"));
            soundEffects.Add("wall", Content.Load<SoundEffect>("Sounds/ball_wall"));
            soundEffects.Add("score", Content.Load<SoundEffect>("Sounds/score"));
        }

        public void PlaySoundEffect(string name)
        {
            SoundEffect soundEffect;
            soundEffects.TryGetValue(name, out soundEffect);
            soundEffect.Play();
        }

        public void UnloadContent()
        {
            soundEffects.Clear();
        }
    }
}
