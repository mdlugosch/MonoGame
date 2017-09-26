using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RetroTennis.Components;

namespace RetroTennis
{
    internal class Game1 : Game
    {
        GraphicsDeviceManager graphics;


    // Zugriff auf Component Klassen über Properties
    internal InputComponent Input { get; private set; }
    internal SceneComponent Scene { get; private set; }
    internal SimulationComponent Simulation { get; private set; }


    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        // Objektinstanzen erzeugen
        Input = new InputComponent(this);
        Scene = new SceneComponent(this);
        Simulation = new SimulationComponent(this);

        // Komponenten hinzufügen
        Components.Add(Input);
        Components.Add(Scene);
        Components.Add(Simulation);

        // Update Order bestimmt in welcher Reihenfolge die Komponenten gemalt werden
        Input.UpdateOrder = 0;
        Simulation.UpdateOrder = 1;
        Scene.UpdateOrder = 2;
        }
    }
}
