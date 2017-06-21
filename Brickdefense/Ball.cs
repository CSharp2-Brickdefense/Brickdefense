using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickdefense
{
    class Ball
    {
    
        Vector2 motion;
        Vector2 position;
        Rectangle bounds;
        bool collided;

        const float ballStartSpeed = 8f;
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

        //controleert op botsingen en zorgt dat de bal steeds sneller gaat
        public void Update()
        {
            collided = false;
            position += motion * ballSpeed;
            ballSpeed += 0.001f;

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
        }

        //zet de bal in z'n startpositie die elke keer veschillend is
        public void SetInStartPosition(Rectangle paddleLocation)
        {
            Random rand = new Random();

            motion = new Vector2(rand.Next(2, 6), -rand.Next(2, 6));
            motion.Normalize();

            ballSpeed = ballStartSpeed;

            position.Y = paddleLocation.Y - texture.Height;
            position.X = paddleLocation.X + (paddleLocation.Width - texture.Width) / 2;
        }

        //controle of de bal de onderkant van het scherm raakt
        public bool OffBottom()
        {
            if (position.Y > screenBounds.Height)
            {
                return true;
            }
            return false;
        }

        //controle of de bal en de balk elkaar raken als dat zo is gaat de bal in tegengestelde richting verder
        public void PaddleCollision(Rectangle paddleLocation)
        {
            Rectangle ballLocation = new Rectangle(
                (int)position.X,
                (int)position.Y,
                texture.Width,
                texture.Height);

            if (paddleLocation.Intersects(ballLocation))
            {
                position.Y = paddleLocation.Y - texture.Height;
                motion.Y *= -1;
            }
        }

        //zorgt ervoor dat de bal maar een keer van richting veranderd bij een aanraking van 2 stenen tegelijk
        public void Deflection(Block brick)
        {
            if (!collided)
            {
                motion.Y *= -1;
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
