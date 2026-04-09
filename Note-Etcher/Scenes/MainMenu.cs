using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Note_Etcher.IScenes.Essentials;

namespace Note_Etcher.IScenes;

public class MainMenu : IScene
{
    private Game1 _game;

    public MainMenu(Game1 game)
    {
        _game = game;
    }

    public void LoadContent()
    {
        
    }

    public void Update(GameTime gameTime)
    {
        // menu input logic here
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        // draw menu here
    }

    public void UnloadContent() { }
}