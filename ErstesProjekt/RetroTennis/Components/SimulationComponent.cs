using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTennis.Components
{
    /*
     * Komponente für physikalische Berechnungen
     */
    internal class SimulationComponent : GameComponent
    {
        private Game1 game;

        private Vector2 ballVelocity = new Vector2(0.3f, 0.2f);

        public Vector2 BallPosition
        {
            get;
            private set;
        }

        public float PlayerPosition
        {
            get;
            private set;
        }

        public float PlayerSize
        {
            get;
            private set;
        }

        public SimulationComponent(Game1 game) : base(game)
        {
            this.game = game;
            BallPosition = new Vector2(0.3f, 0.2f);
            PlayerPosition = 0.5f;
            PlayerSize = 0.2f;
        }

        public override void Update(GameTime gameTime)
        {
            // Aktuellen Mausstatus merken
            //MouseState currentMouseState = Mouse.GetState();
            //new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            // ElapsedGameTime = Zeit die seit dem letzten Update vergangen ist
            BallPosition += ballVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            PlayerPosition += Mouse.GetState().Y * (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f;
            Console.WriteLine(Mouse.GetState().Y);

            // Kollisionsabfrage
            if (BallPosition.X < 0f)
            {
                if(BallPosition.Y < PlayerPosition - (PlayerSize / 2f) || BallPosition.Y > PlayerPosition + (PlayerSize / 2f))
                {
                    throw new Exception("Player hat verloren");
                }

                BallPosition = new Vector2(0f, BallPosition.Y);
                ballVelocity *= new Vector2(-1f, 1f);
            }

            if (BallPosition.Y < 0f)
            {
                BallPosition = new Vector2(BallPosition.X, 0f);
                ballVelocity *= new Vector2(1f, -1f);
            }

            if (BallPosition.X > 1f)
            {
                BallPosition = new Vector2(1f, BallPosition.Y);
                ballVelocity *= new Vector2(-1f, 1f);
            }

            if (BallPosition.Y > 1f)
            {
                BallPosition = new Vector2(BallPosition.X, 1f);
                ballVelocity *= new Vector2(1f, -1f);
            }

            base.Update(gameTime);

        }
    }
}
