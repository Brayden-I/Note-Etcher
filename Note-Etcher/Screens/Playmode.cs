using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;

namespace Note_Etcher.Screens
{
    partial class Playmode
    {
        public Game1 Game { get; set; }
        partial void CustomInitialize()
        {
            BackButton.Click += (_, _) =>
                Game._sceneManager.SwitchTo(Scenes.MAINMENU);
        }
    }
}
