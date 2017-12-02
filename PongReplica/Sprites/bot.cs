

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongReplica.Sprites
{
	public class Bot : Sprite
	{
		public Ball Ball { get; set; }
		public override void Update(GameTime gameTime)
			{
		base.Update(gameTime);

			if (Ball.Position.Y < Position.Y)
				Position = Vector2.Clamp(new Vector2(Position.X, Position.Y - Ball.Velocity.Y * 0.9f),
					Vector2.Zero, maxVector);
			else
				Position = Vector2.Clamp(new Vector2(Position.X, Position.Y + Ball.Velocity.Y * 0.9f),
					Vector2.Zero, maxVector);


		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw(gameTime, spriteBatch);
		}

	}
}
