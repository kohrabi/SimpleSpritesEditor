using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.NET.Controls;
using WinFormsApp1;
using WinFormsApp1.Objects;
using WinFormsApp1.Parsers;
using Color = Microsoft.Xna.Framework.Color;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Editor.Controls
{
    public class AnimationControl : MonoGameControl
    {

        protected override void Initialize()
        {

            // Initialization & Content-Loading here!

            SetMultiSampleCount(8);
            Editor.Camera.Zoom(1.5f);
        }

        protected override void Update(GameTime gameTime)
        {
            

        }

        protected override void Draw()
        {
        }

        #region Input

        
        #endregion
    }
}
