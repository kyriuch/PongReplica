using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongReplica.Sprites
{
	public class Player : Sprite
	{
		public Keys Up { get; set; }
		public Keys Down { get; set; }

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			if (Keyboard.GetState().IsKeyDown(Up))
				Position = Vector2.Clamp(new Vector2(Position.X, Position.Y - Speed.Y),
				Vector2.Zero, maxVector);
			else if (Keyboard.GetState().IsKeyDown(Down))
				Position = Vector2.Clamp(new Vector2(Position.X, Position.Y + Speed.Y),
				Vector2.Zero, maxVector);


		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw(gameTime, spriteBatch);
		}

	}
}
