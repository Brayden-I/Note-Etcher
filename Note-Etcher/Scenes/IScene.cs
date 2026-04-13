using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Note_Etcher.IScenes.Essentials;

public interface IScene
{
    void LoadContent();
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    void UnloadContent();
}

public class SceneManager
{
    private Dictionary<Scenes, IScene> _scenes = new();
    private IScene _activeScene;

    public void Register(Scenes key, IScene scene)
    {
        _scenes[key] = scene;
    }

    public void SwitchTo(Scenes key)
    {
        _activeScene?.UnloadContent();
        _activeScene = _scenes[key];
        _activeScene.LoadContent();
    }

    public void Update(GameTime gameTime) => _activeScene?.Update(gameTime);
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Console.WriteLine(_activeScene?.GetType().Name);
        _activeScene?.Draw(gameTime, spriteBatch);
    } 
}