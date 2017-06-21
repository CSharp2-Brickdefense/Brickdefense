using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
<<<<<<< HEAD
=======
using Windows.System.Threading;
using System.Threading;
>>>>>>> 6ff7cf06c1a267f25cfc52783e8b37fde08e5828

namespace Brickdefense
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Ball ball;
        Rectangle screen;

        //[,] rows;

        int score;
        int highscore;
        List<Ball> balls;
<<<<<<< HEAD
=======
 
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
>>>>>>> 6ff7cf06c1a267f25cfc52783e8b37fde08e5828


        int setter = 0;

        private static readonly TimeSpan intervalBetweenAttack = TimeSpan.FromMilliseconds(1000);
        private TimeSpan lastTimeAttack;


        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 750;
            graphics.PreferredBackBufferHeight = 600;

<<<<<<< HEAD
            screen = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
=======


            screenRectangle = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            balls = new List<Ball>();
>>>>>>> 6ff7cf06c1a267f25cfc52783e8b37fde08e5828
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
          
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

<<<<<<< HEAD
            Texture2D tempTexture = Content.Load<Texture2D>("ball.png");
            ball = new Ball(tempTexture, screen);
=======
            


            //maakt een nieuwe bal
    
            ballimage = Content.Load<Texture2D>("ball");

            //maakt de stenen
            blockimage = Content.Load<Texture2D>("block");

            ballAmount = 3;
            StartGame();
>>>>>>> 6ff7cf06c1a267f25cfc52783e8b37fde08e5828

            // TODO: use this.Content to load your game content here
        }

<<<<<<< HEAD
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
=======
       

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
>>>>>>> 6ff7cf06c1a267f25cfc52783e8b37fde08e5828
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
<<<<<<< HEAD
            // TODO: Add your update logic here
=======
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





>>>>>>> 6ff7cf06c1a267f25cfc52783e8b37fde08e5828

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
<<<<<<< HEAD
     
=======


            foreach (Ball ball in balls)
            {
               
                    ball.Draw(spriteBatch);
                
                
                
            }

            foreach (Block brick in blocks)
            {
                brick.Draw(spriteBatch);
            }

         
            
>>>>>>> 6ff7cf06c1a267f25cfc52783e8b37fde08e5828

            spriteBatch.End();
            // TODO: Add your drawing code here

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
