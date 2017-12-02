using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongReplica.Sprites
{
	public class Ball : Sprite
	{
		public Sprite player1 { get; set; }
		public Sprite player2 { get; set; }

		private void reset()
		{
			Random random = new Random();

			Vector2 velocityVector = new Vector2(random.Next(2, 5) * (random.Next(2) == 1 ? 1 : -1),
				random.Next(2, 5) * (random.Next(2) == 1 ? 1 : -1));
			velocityVector.Normalize();
			velocityVector *= 5;

			Position =
				new Vector2(
					Game1.graphics.GraphicsDevice.PresentationParameters.Bounds.Width / 2,
				Game1.graphics.GraphicsDevice.PresentationParameters.Bounds.Height / 2);

			Velocity = velocityVector;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			if (Position.Y <= 0 ||
				Position.Y >= Game1.graphics.GraphicsDevice.PresentationParameters.Bounds.Height - Texture.Height)
				Velocity = new Vector2(Velocity.X, Velocity.Y * (-1));

			if (Position.X <= player1.Position.X + player1.Texture.Width)
				if (Position.Y + Texture.Height + 1 >= player1.Position.Y
					&& Position.Y - 1 <= player1.Position.Y + player1.Texture.Height)
					Velocity = new Vector2(Velocity.X * (-1), Velocity.Y);
				else
					reset();

			if (Position.X + Texture.Width >= player2.Position.X)
				if (Position.Y + Texture.Height + 1 >= player2.Position.Y
					&& Position.Y - 1 <= player2.Position.Y + player2.Texture.Height)
					Velocity = new Vector2(Velocity.X * (-1), Velocity.Y);
				else
					reset();
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw(gameTime, spriteBatch);
		}
	}
}
