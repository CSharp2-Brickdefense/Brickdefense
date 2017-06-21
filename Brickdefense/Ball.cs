using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brickdefense
{
    class Ball
    {

        Vector2 motion;
        Vector2 position;
        Rectangle bounds;
        bool collided;
        float motionX = 0;
        float motionY = 0;

        const float ballStartSpeed = 0f;
        float ballSpeed;

        Texture2D texture;
        Rectangle screenBounds;

        public Rectangle Bounds
        {
            get
            {
                bounds.X = (int)position.X;
                bounds.Y = (int)position.Y;
                return bounds;
            }
        }

        //maken van de bal
        public Ball(Texture2D texture, Rectangle screenBounds)
        {
            bounds = new Rectangle(0, 0, texture.Width, texture.Height);
            this.texture = texture;
            this.screenBounds = screenBounds;
            
        }

        public void setMotion(int motionX, int motionY)
        {
            this.motionX = motionX;
            this.motionY = motionY;

            motion = new Vector2(motionX, motionY);
            motion.Normalize();
        }

        public void setSpeed(float speed)
        {
            this.ballSpeed = speed;
        }

        //controleert op botsingen 
        public void Update()
        {
            
            collided = false;
            position += motion * ballSpeed;
          //  ballSpeed += 0.001f;

            CheckWallCollision();
        }

        //controleert op botsingen tegen de wanden en zorgt er dan voor dat de bal in tegen gestelde richting verder gaat
        private void CheckWallCollision()
        {
            if (position.X < 0)
            {
                position.X = 0;
                motion.X *= -1;
            }
            if (position.X + texture.Width > screenBounds.Width)
            {
                position.X = screenBounds.Width - texture.Width;
                motion.X *= -1;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
                motion.Y *= -1;
            }
            if (position.Y + texture.Height > screenBounds.Height)
            {
                position.Y = screenBounds.Height - texture.Height;
                motion.Y *= -1;
            }
        }

        //zet de bal in z'n startpositie die elke keer veschillend is
        public void SetInStartPosition()
        {
             Random rand = new Random();

            // motion = new Vector2(rand.Next(2, 6), -rand.Next(2, 6));
            motion = new Vector2(motionX, motionY);
              motion.Normalize();

             ballSpeed = ballStartSpeed;

            //position.X = (screenBounds.Width - texture.Width) / 2;
            //position.Y = screenBounds.Height - texture.Height - 20;
            position.X = 200;
            position.Y = 200;
        }

      

       

        //zorgt ervoor dat de bal maar een keer van richting veranderd bij een aanraking van 2 stenen tegelijk

        public void Deflection(Block brick)
        {
            if (!collided)
            {
                if(brick.Location.Left >= bounds.Right){
                    position.X += 10;
                    motion.X *= -1;
                }
                if (brick.Location.Right <= bounds.Left)
                {
                    position.X -= 10;
                    motion.X *= -1;
                }
                if (brick.Location.Bottom <= bounds.Top)
                {
                    position.Y -= 10;
                    motion.Y *= -1;
                }
                if (brick.Location.Top <= bounds.Bottom)
                {
                    position.Y += 10;
                    motion.Y *= -1;
                }




                collided = true;
            }
        }

        //tekend de bal
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

       
    }
    
}
