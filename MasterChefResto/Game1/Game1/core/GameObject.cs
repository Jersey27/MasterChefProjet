using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.core
{
    class GameObject
    {
        public Vector2 Position;
        public Texture2D Texture;
        public Rectangle Source;
        public float time;
        public float frameTime = 0.1f;
        public int frameIndex;

        public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        public enum framesIndex
        {
           top = 0,
        }
    }
    
}
