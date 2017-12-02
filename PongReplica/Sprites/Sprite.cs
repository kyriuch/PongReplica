using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongReplica.Sprites
{
	public class Sprite
	{
		public Texture2D Texture { get; set; }
		public Vector2 Position { get; set; }
		public Vector2 Velocity { get; set; }
		public Vector2 Speed { get; set; }
		public Color Color { get; set; }

		protected Vector2 maxVector;

		public void CalculateMaxVector()
		{
			int width = Game1.graphics.GraphicsDevice.PresentationParameters.Bounds.Width;
			int height = Game1.graphics.GraphicsDevice.PresentationParameters.Bounds.Height;

			maxVector = new Vector2(width - Texture.Width, height - Texture.Height);
		}

		public virtual void Update(GameTime gameTime)
		{
			Position = Vector2.Clamp(new Vector2(Position.X + Velocity.X, Position.Y - Velocity.Y),
				Vector2.Zero, maxVector);
		}

		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, Position, Color);
		}

	}
}
