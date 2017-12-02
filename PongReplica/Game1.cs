using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongReplica.Sprites;
using System;
using System.Collections.Generic;

namespace PongReplica
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		List<Sprite> sprites;
		Player player1;
		Bot player2;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
			sprites = new List<Sprite>();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
			int width = graphics.GraphicsDevice.PresentationParameters.Bounds.Width;
			int height = graphics.GraphicsDevice.PresentationParameters.Bounds.Height;
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			player1 = new Player
			{
				Color = Color.White,
				Up = Keys.W,
				Down = Keys.S,
				Position = new Vector2(0, 50),
				Speed = new Vector2(0, 10),
				Texture = Content.Load<Texture2D>("paletka")
			};

			player2 = new Bot
			{
				Color = Color.White,
				Position = new Vector2(width - 20, 50),
				Speed = new Vector2(0, 10),
				Texture = Content.Load<Texture2D>("paletka")
			};

			player1.CalculateMaxVector();
			player2.CalculateMaxVector();
			sprites.Add(player1);
			sprites.Add(player2);

			Random random = new Random();

			Vector2 velocityVector = new Vector2(random.Next(2, 5) * (random.Next(2) == 1 ? 1 : -1),
				random.Next(2, 5) * (random.Next(2) == 1 ? 1 : -1));
			velocityVector.Normalize();
			velocityVector *= 5;

			Ball ball = new Ball
			{
				Color = Color.White,
				Position = new Vector2(width / 2, height / 2),
				Speed = Vector2.Zero,
				Velocity = velocityVector,
				Texture = Content.Load<Texture2D>("pileczka"),
				player1 = player1,
				player2 = player2
			};

			ball.CalculateMaxVector();
			sprites.Add(ball);

			player2.Ball = ball;



			// TODO: use this.Content to load your game content here
		}

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here

			foreach (var sprite in sprites)
				sprite.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

			// TODO: Add your drawing code here

			spriteBatch.Begin();

			foreach (var sprite in sprites)
				sprite.Draw(gameTime, spriteBatch);

			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
