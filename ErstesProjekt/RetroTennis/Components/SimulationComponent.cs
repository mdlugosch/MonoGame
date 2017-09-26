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
        public Vector2 Position { get; private set; }

        // Mausstatus merken um eine Änderung festzustellen
        MouseState originalMouseState = Mouse.GetState();

        public SimulationComponent(Game1 game) : base(game)
        {
            this.game = game;
            Position = new Vector2(100f, 100f);
        }

        public override void Update(GameTime gameTime)
        {
            // Aktuellen Mausstatus merken
            MouseState currentMouseState = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Left)) Position += new Vector2(-1f, 0f);
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) Position += new Vector2(1f, 0f);
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) Position += new Vector2(0f, -1f);
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) Position += new Vector2(0f, 1f);

            // Wenn der Mausstatus sich im Vergleich zum alten Status geändert hat dann setze die Position neu
            if (currentMouseState != originalMouseState)
                Position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            base.Update(gameTime);

            // Aktuellerstatus wird als original Status gemerkt.
            originalMouseState = currentMouseState;
        }
    }
}
