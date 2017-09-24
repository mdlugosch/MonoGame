using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMitKomponenten.Components
{
    // Klasse ist nur innerhalb des Projektes verfügbar
    /*
     * Komponente die die Benutzereingaben abfängt
     */
    internal class InputComponent : GameComponent
    {
        Game1 game;


        public InputComponent(Game1 game) : base(game)
        {
            this.game = game;
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();

            base.Update(gameTime);
        }
    }
}
