using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brickdefense
{
    class Block
    {

        Texture2D texture;
        Rectangle location;
        Color tint;
        bool alive;


        //locatie van de steen
        public Rectangle Location
        {
            get { return location; }
        }

        //eigenschappen van de stenen
        public Block(Texture2D texture, Rectangle location, Color tint)
        {
            this.texture = texture;
            this.location = location;
            this.tint = tint;
            this.alive = true;
        }

        //controle of de steen geraakt is en zo ja dan is de alive staat false
        public void CheckCollision(Ball ball)
        {
            if (alive && ball.Bounds.Intersects(location))
            {
                alive = false;
                ball.Deflection(this);

            }
        }

        //tekent de stenen als ze nog in leven zijn
        public void Draw(SpriteBatch spriteBatch)
        {
            if (alive)
                spriteBatch.Draw(texture, location, tint);

        }
    }
}
