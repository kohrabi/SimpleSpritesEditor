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
    public class MainControl : MonoGameControl
    {
        // Fields & Properties here!
        private const string WelcomeMessage = "Add an image to create Animation";

        private static readonly Point cameraClamp = new Point(100, 100);

        private Vector2 mouseDownPosition = Vector2.Zero;
        private Vector2 prevCameraPosition = Vector2.Zero;
        private bool leftMouseButtonPressed = false;
        
        private Texture2D? _texture = null;
        private Rectangle spriteRect = Rectangle.Empty;
        private const int SnapSize = 16;
        private bool setCameraFirstPosition = false;
        
        public BindingList<Animation> Animations = new BindingList<Animation>();
        public int SelectedAnimationIndex = -1;
        public int SelectedFrameIndex = -1;
        
        private BindingList<AnimationTexture> _textures = new BindingList<AnimationTexture>();
        private Dictionary<int, AnimationTexture> _textureIds = new(); // Id to Texture
        private int selectedTextureIndex = 0;
        private int textureId = 0;
        
        //public List<Animation> Animations => Animations;
        public BindingList<AnimationTexture> Textures => _textures;
        public Dictionary<int, AnimationTexture> TextureIds => _textureIds;

        #region Setters

        #region Textures

        bool checkTextureExists(string path)
        {
            return _textures.FirstOrDefault(texture => texture.FilePath == path, null) != null;
        }

        public void LoadTexture(string path)
        {
            if (checkTextureExists(path)) return;
            try
            {  
                FileStream fs = new FileStream(path, FileMode.Open);
                _texture = Texture2D.FromStream(Editor.GraphicsDevice, fs);

                var texture = new AnimationTexture(path, _texture, textureId);
                _textures.Add(texture);
                _textureIds.Add(textureId, texture);
                textureId++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UnloadTexture(int index)
        {
            if (index < 0 || index > _textures.Count - 1) return;
            var texture = _textures[index];
            _textures.RemoveAt(index);
            _textureIds.Remove(texture.TextureId);
            texture.Dispose();
        }

        public void SelectTexture(int textureIndex)
        {
            if (textureIndex < 0 || textureIndex > _textures.Count - 1) return;
            selectedTextureIndex = textureIndex;
            _texture = _textures[selectedTextureIndex].Texture;
        }
        
        #endregion

        #region Frame

        public void AddNewFrame()
        {
            if (SelectedAnimationIndex < 0 || SelectedAnimationIndex > Animations.Count - 1) return;
            AnimationFrame frame = new AnimationFrame(selectedTextureIndex, _textures[selectedTextureIndex].FilePath);
            Animations[SelectedAnimationIndex].AddFrame(frame);
        }

        #endregion

        #endregion

        public void SetLoad(TextParser.TextParseLoadResult result)
        {
            Reset();
            Animations = new BindingList<Animation>(result.Animations);
            foreach (var texture in result.TextureIds)
                LoadTexture(Path.Combine(result.RootPath, texture.Key.Replace('/',  '\\')));

        }

        public void Reset()
        {
            
            foreach (var texture in _textures)
                texture.Dispose();
            _textures.Clear();
            _textureIds.Clear();
            Animations.Clear();
            _texture = null;
            spriteRect = Rectangle.Empty;
            SelectedAnimationIndex = -1;
            SelectedFrameIndex = -1;
            selectedTextureIndex = 0;
            textureId = 0;
        }
        
        public void NewAnimationList()
        {
            Animations.Clear();
            Animation defaultAnimation = new Animation();
            defaultAnimation.SetName(Animation.SpriteOnlyAnimationName);
            Animations.Add(defaultAnimation);
        }

        private Vector2 screenCenter
        {
            get => new Vector2(Editor.GraphicsDevice.Viewport.Width / 2, Editor.GraphicsDevice.Viewport.Height / 2);
        }

        
        public MainControl()
        {
            NewAnimationList();
        }
        
        protected override void Initialize()
        {
            Helper.PointTexture = new Texture2D(Editor.GraphicsDevice, 1, 1);
            Helper.PointTexture.SetData<Color>(new Color[] { Color.White });

            // Initialization & Content-Loading here!

            SetMultiSampleCount(8);
            Editor.Camera.Zoom(1.5f);
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

        }

        protected override void Draw()
        {
            if (_texture != null)
            {
                Vector2 clampSize = new Vector2(_texture.Width / 2.0f + cameraClamp.X, _texture.Height / 2.0f + cameraClamp.Y);
                Editor.Camera.Position = Vector2.Clamp(Editor.Camera.Position, screenCenter - clampSize, screenCenter + clampSize);
            }
            else
            {
                Vector2 clampSize = new Vector2(cameraClamp.X, cameraClamp.Y);
                Editor.Camera.Position = Vector2.Clamp(Editor.Camera.Position, 
                    screenCenter - clampSize,
                    screenCenter + clampSize);
            }
            
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
                    Helper.PointTexture,
                    new Rectangle(texturePosition.X, texturePosition.Y, _texture.Width, _texture.Height), 
                    Color.Gray);
                Editor.spriteBatch.Draw(
                    _texture, 
                    texturePosition.ToVector2(), 
                    Color.White);
             
                // DrawGrid(_texture.Height / 16, _texture.Width / 16, 16, 0, 0);
            }
            
            if (!spriteRect.IsEmpty)
                Helper.DrawRectangle(Editor.spriteBatch, spriteRect, new Color(Color.Red, 0.4f), 1);
            if (SelectedAnimationIndex != -1 && _texture != null)
            {
                Animation anim =  Animations[SelectedAnimationIndex];
                for (int i = 0; i < anim.Frames.Count; i++)
                {
                    if (anim.Frames[i].TextureId != selectedTextureIndex) continue;
                    Point texturePosition = screenCenter.ToPoint() - new Point(_texture.Width / 2, _texture.Height / 2);
                    Rectangle rect = anim.Frames[i].Rect;
                    rect.X += texturePosition.X;
                    rect.Y += texturePosition.Y;
                    if (i == SelectedFrameIndex)  
                        Helper.DrawRectangle(Editor.spriteBatch, rect, new Color(Color.Red, 0.4f), 1);
                    else   
                        Helper.DrawRectangle(Editor.spriteBatch, rect, new Color(Color.Blue, 0.4f), 1);
                }
            }
            Editor.spriteBatch.Draw(Helper.PointTexture, 
                new Rectangle(Helper.ScreenToWorld(Mouse.GetState().Position, Editor.Camera).ToPoint(), new Point(1)), 
                Color.Red);
            
            //Editor.spriteBatch.End();
            Editor.EndCamera2D();
            //Editor.EndAntialising();
        }

        #region Input

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

            if (e.Button == MouseButtons.Left && _texture != null)
            {
                spriteRect = Rectangle.Empty;
                Point mouseWorld = Helper.ScreenToWorld(new Point(e.X, e.Y), Editor.Camera).ToPoint();
                
                Point texturePosition = screenCenter.ToPoint() - new Point(_texture.Width / 2, _texture.Height / 2);
                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                {
                    mouseWorld.X -= texturePosition.X;
                    mouseWorld.Y -= texturePosition.Y;
                    mouseWorld.X = (int)Math.Round(mouseWorld.X / (float)SnapSize) * SnapSize;
                    mouseWorld.Y = (int)Math.Round(mouseWorld.Y / (float)SnapSize) * SnapSize;
                    mouseWorld.X += texturePosition.X;
                    mouseWorld.Y += texturePosition.Y;
                }

                mouseWorld.X = Math.Clamp(mouseWorld.X, texturePosition.X, texturePosition.X + _texture.Width);
                mouseWorld.Y = Math.Clamp(mouseWorld.Y, texturePosition.Y, texturePosition.Y + _texture.Height);


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
                if (SelectedAnimationIndex != -1 &&
                    SelectedFrameIndex != -1 &&
                    spriteRect.Width > 1 &&
                    spriteRect.Height > 1)
                {
                    Point texturePosition = screenCenter.ToPoint() - new Point(_texture.Width / 2, _texture.Height / 2);
                    spriteRect.X -= texturePosition.X;
                    spriteRect.Y -= texturePosition.Y;
                    Animations[SelectedAnimationIndex].Frames[SelectedFrameIndex]
                        .SetTexture(_textures[selectedTextureIndex].TextureId, _textures[selectedTextureIndex].FilePath);
                    Animations[SelectedAnimationIndex].Frames[SelectedFrameIndex].SetRect(spriteRect);
                }
            }
            
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Right)
            {
                Editor.Camera.Position = prevCameraPosition + (mouseDownPosition - new Vector2(e.X, e.Y));
            }

            if (leftMouseButtonPressed && _texture != null)
            {
                
                Point mouseWorld = Helper.ScreenToWorld(new Point(e.X, e.Y), Editor.Camera).ToPoint();
                Console.WriteLine(mouseWorld);
                Point texturePosition = screenCenter.ToPoint() - new Point(_texture.Width / 2, _texture.Height / 2);
                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                {
                    mouseWorld.X -= spriteRect.X;
                    mouseWorld.Y -= spriteRect.Y;
                    mouseWorld.X = (int)Math.Round(mouseWorld.X / (float)SnapSize) * SnapSize - 1;
                    mouseWorld.Y = (int)Math.Round(mouseWorld.Y / (float)SnapSize) * SnapSize - 1;
                    mouseWorld.X += spriteRect.X;
                    mouseWorld.Y += spriteRect.Y;
                }
                
                mouseWorld.X = Math.Clamp(mouseWorld.X, texturePosition.X, texturePosition.X + _texture.Width);
                mouseWorld.Y = Math.Clamp(mouseWorld.Y, texturePosition.Y, texturePosition.Y + _texture.Height);
                
                Point size = new Point(mouseWorld.X - spriteRect.Left, mouseWorld.Y - spriteRect.Top);
                spriteRect.Size = size;
            }
        }
        
        #endregion
    }
}
