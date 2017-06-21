using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Windows.System.Threading;
using System.Threading;

namespace Brickdefense
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Object[,] rows;

        int score;
        int highscore;
        List<Ball> balls;
 
        Texture2D ballimage;
        int ballAmount;
        int ballsshot;
        
        Rectangle screenRectangle;

        public float fireRate = 0.5F;
        private float nextFire = 0.0F;

        int bricksWide = 10;
        int bricksHigh = 5;
        Texture2D blockimage;
        Block[,] blocks;


        int setter = 0;

        private static readonly TimeSpan intervalBetweenAttack = TimeSpan.FromMilliseconds(1000);
        private TimeSpan lastTimeAttack;


        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 750;
            graphics.PreferredBackBufferHeight = 600;



            screenRectangle = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            balls = new List<Ball>();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            


            //maakt een nieuwe bal
    
            ballimage = Content.Load<Texture2D>("ball");

            //maakt de stenen
            blockimage = Content.Load<Texture2D>("block");

            ballAmount = 3;
            StartGame();

        }

       

        private void StartGame()
        {

            
            
            for (int i = 0; i < ballAmount; i++)
            {
                balls.Add(new Ball(ballimage, screenRectangle));
                balls[i].SetInStartPosition();
                balls[i].setMotion(1, 1);
            }

       
            //arraylist voor het opslaan van de stenen
            blocks = new Block[bricksWide, bricksHigh];

            //geeft elke rij stenen een andere kleur
            for (int y = 0; y < bricksHigh; y++)
            {
                Color tint = Color.White;

                switch (y)
                {
                    case 0:
                        tint = Color.Blue;
                        break;
                    case 1:
                        tint = Color.Red;
                        break;
                    case 2:
                        tint = Color.Green;
                        break;
                    case 3:
                        tint = Color.Yellow;
                        break;
                    case 4:
                        tint = Color.Purple;
                        break;
                }

                //toevoegen van stenen
                for (int x = 0; x < bricksWide; x++)
                {
                    blocks[x, y] = new Block(
                        blockimage,
                        new Rectangle(
                            x * blockimage.Width,
                            y * blockimage.Height,
                            blockimage.Width,
                            blockimage.Height)
                        , 1);
                }
            }

           
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        //controle op de gebruikers input en veranderingen in het spel
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                
               
            }

            foreach (Ball ball in balls)
            {
                foreach (Block brick in blocks)
                {
                    brick.CheckCollision(ball);
                }
                ball.Update();

                if (lastTimeAttack + intervalBetweenAttack < gameTime.TotalGameTime)
                {
                    shootBalls();
                    lastTimeAttack = gameTime.TotalGameTime;
                }

                
                
                //controle of een steen is geraakt door de bal
                
            }






            base.Update(gameTime);
        }

        //tekenen van de objecten zoals de stenen, bal en balk
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();


            foreach (Ball ball in balls)
            {
               
                    ball.Draw(spriteBatch);
                
                
                
            }

            foreach (Block brick in blocks)
            {
                brick.Draw(spriteBatch);
            }

         
            

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected int getHighscore()
        {
            return highscore;
        }

        protected void setHighscore(int score)
        {
            highscore = score;
        }

        protected int getScore()
        {
            return score;
        }

        protected void setScore(int value)
        {
            score = value;
        }

        protected void newRow(int value)
        {
            // todo: create new row of blocks with value and store them
        }


       
        protected void shootBalls()
        {
            if (setter < ballAmount)
            {
                balls[this.setter].setSpeed(4f);
                setter++;
            }
        }

       

    }
}
