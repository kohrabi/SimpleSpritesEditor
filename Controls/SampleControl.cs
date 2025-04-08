using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.NET.Controls;
using Color = Microsoft.Xna.Framework.Color;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Editor.Controls
{
    public class SampleControl : MonoGameControl
    {
        // Fields & Properties here!
        private const string WelcomeMessage = "Welcome to MonoGame.Forms!";

        private Texture2D? _texture = null;
        private Texture2D _pointTexture;
        private Vector2 mouseDownPosition = Vector2.Zero;
        private Vector2 prevCameraPosition = Vector2.Zero;
        private Vector2 prevMouseLeftDownPosition = Vector2.Zero;
        private bool leftMouseButtonPressed = false;
        private List<Rectangle> spriteRects = new List<Rectangle>();
        private Rectangle spriteRect = Rectangle.Empty;
        private const int SnapSize = 16;
        private bool setCameraFirstPosition = false;

        private Vector2 screenCenter
        {
            get => new Vector2(Editor.GraphicsDevice.Viewport.Width / 2, Editor.GraphicsDevice.Viewport.Height / 2);
        }

        public void LoadTexture(string path)
        {
            try
            {  
                FileStream fs = new FileStream(path, FileMode.Open);
                _texture = Texture2D.FromStream(Editor.GraphicsDevice, fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void Initialize()
        {
            _pointTexture = new Texture2D(Editor.GraphicsDevice, 1, 1);
            _pointTexture.SetData<Color>(new Color[] { Color.White });

            // Initialization & Content-Loading here!

            SetMultiSampleCount(8);

            //Editor.Content.Load<Texture2D>("");

            // Remove FPS-Panel:
            //Components.Remove(Editor.FPSCounter);

            // Remove Default (Built-In) components (this includes the Camera2D):
            //Editor.RemoveDefaultComponents();

            // Editor.Camera.Zoom(0.5f);
        }

        protected override void Update(GameTime gameTime)
        {
            if (!setCameraFirstPosition)
            {
                Editor.Camera.Position = new Vector2(
                    (Editor.GraphicsDevice.Viewport.Width / 2),
                    (Editor.GraphicsDevice.Viewport.Height / 2));
                setCameraFirstPosition = true;
            }
            ; //-new Vector2((Editor.GraphicsDevice.Viewport.Width), (Editor.GraphicsDevice.Viewport.Height)) * 0.5f;
            // Updating here!
            // if (Mouse.GetState().ScrollWheelValue != 0)
            // {
            //     Editor.Camera.Zoom(Editor.Camera.GetZoom() + 0.02f * Math.Sign(Mouse.GetState().ScrollWheelValue));
            // }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta != 0)
            {
                Editor.Camera.Zoom(Editor.Camera.GetZoom() + 0.1f * Math.Sign(e.Delta));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
            {
                mouseDownPosition = new Vector2(e.X, e.Y);
                prevCameraPosition = Editor.Camera.Position;
            }

            if (e.Button == MouseButtons.Left)
            {
                prevMouseLeftDownPosition = new Vector2(e.X, e.Y);
                Point mouseWorld = ScreenToWorld(new Point(e.X, e.Y)).ToPoint();
                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) && _texture != null)
                {
                    Point texturePosition = screenCenter.ToPoint() - new Point(_texture.Width / 2, _texture.Height / 2);
                    mouseWorld.X -= texturePosition.X;
                    mouseWorld.Y -= texturePosition.Y;
                    mouseWorld.X = (int)Math.Round(mouseWorld.X / (float)SnapSize) * SnapSize;
                    mouseWorld.Y = (int)Math.Round(mouseWorld.Y / (float)SnapSize) * SnapSize;
                    mouseWorld.X += texturePosition.X;
                    mouseWorld.Y += texturePosition.Y;
                }

                spriteRect.X = mouseWorld.X;
                spriteRect.Y = mouseWorld.Y;
                leftMouseButtonPressed = true;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                leftMouseButtonPressed = false;
                if (!spriteRect.IsEmpty && spriteRect.Width > 1 && spriteRect.Height > 1)
                    spriteRects.Add(spriteRect);
                spriteRect = Rectangle.Empty;
            }
            
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Right)
            {
                Editor.Camera.Position = prevCameraPosition + (mouseDownPosition - new Vector2(e.X, e.Y));
            }

            if (leftMouseButtonPressed)
            {
                
                Point mouseWorld = ScreenToWorld(new Point(e.X, e.Y)).ToPoint();
                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                {
                    Point texturePosition = screenCenter.ToPoint() - new Point(_texture.Width / 2, _texture.Height / 2);
                    mouseWorld.X -= texturePosition.X;
                    mouseWorld.Y -= texturePosition.Y;
                    mouseWorld.X = (int)Math.Round(mouseWorld.X / (float)SnapSize) * SnapSize - 1;
                    mouseWorld.Y = (int)Math.Round(mouseWorld.Y / (float)SnapSize) * SnapSize - 1;
                    mouseWorld.X += texturePosition.X;
                    mouseWorld.Y += texturePosition.Y;
                }
                Point size = new Point(mouseWorld.X - spriteRect.Left, mouseWorld.Y - spriteRect.Top);
                spriteRect.Size = size;
                

            }
        }

        protected override void Draw()
        {
            // Drawing here!
            Editor.BeginCamera2D(
                SpriteSortMode.Deferred,
                null,
                SamplerState.PointClamp
                );
            Editor.GraphicsDevice.Clear(Color.Black);
            //Editor.BeginAntialising();
            //Editor.spriteBatch.Begin();

            Editor.spriteBatch.DrawString(Editor.Font, WelcomeMessage, new Vector2(
                screenCenter.X - (Editor.Font.MeasureString(WelcomeMessage).X / 2),
                screenCenter.Y - (Editor.FontHeight / 2)),
                Color.White);

            if (_texture != null)
            {
                Point texturePosition = screenCenter.ToPoint() - new Point(_texture.Width / 2, _texture.Height / 2);
                Editor.spriteBatch.Draw(
                    _pointTexture,
                    new Rectangle(texturePosition.X, texturePosition.Y, _texture.Width, _texture.Height), 
                    Color.Gray);
                Editor.spriteBatch.Draw(
                    _texture, 
                    texturePosition.ToVector2(), 
                    Color.White);
             
                // DrawGrid(_texture.Height / 16, _texture.Width / 16, 16, 0, 0);
            }
            
            if (!spriteRect.IsEmpty)
                DrawRectangle(Editor.spriteBatch, spriteRect, new Color(Color.Red, 0.4f), 1);
            foreach (var rect in spriteRects)
            {
                DrawRectangle(Editor.spriteBatch, rect, new Color(Color.Red, 0.4f), 1);
            }
            //Editor.spriteBatch.End();
            Editor.EndCamera2D();
            //Editor.EndAntialising();
        }

        Vector2 ScreenToWorld(Point screenPosition)
        {
            return Vector2.Transform(screenPosition.ToVector2(), Matrix.Invert(Editor.Camera.GetTransform()));
        }
        
        private void DrawGrid(int rows, int cols, int gridSize, int addedX, int addedY)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    DrawRectangle(Editor.spriteBatch, 
                        new Rectangle(j * gridSize + addedX, i * gridSize + addedY, gridSize, gridSize), 
                        new Color(Color.DarkBlue, 0.2f), 
                        1);
            }
        }
        
        private void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color, int lineWidth)
        {
            spriteBatch.Draw(_pointTexture,
                new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(_pointTexture, 
                new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
            spriteBatch.Draw(_pointTexture, 
                new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(_pointTexture, 
                new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
        }
    }
}
