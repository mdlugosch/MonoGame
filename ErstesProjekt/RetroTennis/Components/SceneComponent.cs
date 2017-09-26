using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTennis.Components
{
    /*
     * Komponente die für das Rendern der Grafik zuständig ist
     */
    internal class SceneComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        //private Texture2D star;
        private Texture2D pixel;

        private Game1 game;

        public SceneComponent(Game1 game) : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //star = Game.Content.Load<Texture2D>("starGold");

            // pixel wird eine eigene Textur zugewiesen
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            // Daten der Textur in pixel setzen
            pixel.SetData<Color>(new Color[] { Color.White });

        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //spriteBatch.Draw(star, game.Simulation.Position, Color.White);

            // Draw-Methode vergrößert das pixel zu einem Rechteck.
            // Destination Rectangle übernimmt diese Aufgabe und ersetzt auch eine Positionsangabe in dieser Überladung
            spriteBatch.Draw(pixel, new Rectangle((int)game.Simulation.Position.X, (int)game.Simulation.Position.Y, 10, 10), Color.White);

            // Neben dem Ball muss das Spielfeld Ränder haben die aus den Werten des Spielfensters ermittelt werden
            spriteBatch.Draw(pixel, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, 10), Color.DarkGray);
            spriteBatch.Draw(pixel, new Rectangle(0, GraphicsDevice.Viewport.Height -10, GraphicsDevice.Viewport.Width, 10), Color.DarkGray);
            spriteBatch.Draw(pixel, new Rectangle(0, 0, 10, GraphicsDevice.Viewport.Height), Color.DarkGray);
            spriteBatch.Draw(pixel, new Rectangle(GraphicsDevice.Viewport.Width - 10, 0, 10, GraphicsDevice.Viewport.Height), Color.DarkGray);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
