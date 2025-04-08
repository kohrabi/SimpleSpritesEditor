﻿using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.NET.Controls;
using WinFormsApp1;
using WinFormsApp1.Data;
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

        private static readonly Point cameraClamp = new Point(100, 100);

        private Texture2D? _texture = null;
        private Vector2 mouseDownPosition = Vector2.Zero;
        private Vector2 prevCameraPosition = Vector2.Zero;
        private Vector2 prevMouseLeftDownPosition = Vector2.Zero;
        private bool leftMouseButtonPressed = false;
        private Rectangle spriteRect = Rectangle.Empty;
        private const int SnapSize = 16;
        private bool setCameraFirstPosition = false;

        
        private List<Animation> _animations = new List<Animation>();
        public int SelectedAnimationIndex = -1;
        public int SelectedFrameIndex = -1;
        
        private List<Tuple<string, Texture2D>> _textures = new List<Tuple<string, Texture2D>>();
        private Dictionary<string, int> _textureIds = new Dictionary<string, int>(); // Texture Id mapping
        private int selectedTextureIndex = 0;
        private int textureId = 0;
        
        public List<Animation> Animations => _animations;
        public List<Tuple<string, Texture2D>> Textures => _textures;

        #region Setters

        #region Textures

        public void LoadTexture(string path)
        {
            if (_textureIds.ContainsKey(path)) return;
            try
            {  
                FileStream fs = new FileStream(path, FileMode.Open);
                _texture = Texture2D.FromStream(Editor.GraphicsDevice, fs);
                
                _textures.Add(new Tuple<string, Texture2D>(path.Split('\\').Last(), _texture));
                _textureIds.Add(path, textureId++);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UnloadTexture(int index)
        {
            _textures[index].Item2.Dispose();
            _textureIds.Remove(_textures[index].Item1);
            _textures.RemoveAt(index);
        }

        public void SelectTexture(int textureIndex)
        {
            selectedTextureIndex = textureIndex;
            _texture = _textures[selectedTextureIndex].Item2;
        }
        
        #endregion

        #region Frame

        public void AddNewFrame()
        {
            if (SelectedAnimationIndex < 0 || SelectedAnimationIndex > Animations.Count - 1) return;
            AnimationFrame frame = new AnimationFrame(selectedTextureIndex);
            _animations[SelectedAnimationIndex].AddFrame(frame);
        }

        #endregion

        #endregion
        
        private Vector2 screenCenter
        {
            get => new Vector2(Editor.GraphicsDevice.Viewport.Width / 2, Editor.GraphicsDevice.Viewport.Height / 2);
        }
        
        protected override void Initialize()
        {
            Helper.PointTexture = new Texture2D(Editor.GraphicsDevice, 1, 1);
            Helper.PointTexture.SetData<Color>(new Color[] { Color.White });

            // Initialization & Content-Loading here!

            SetMultiSampleCount(8);
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
            if (SelectedAnimationIndex != -1)
            {
                Animation anim =  _animations[SelectedAnimationIndex];
                for (int i = 0; i < anim.Frames.Count; i++)
                {
                    if (anim.Frames[i].TextureId != selectedTextureIndex) continue;
                    if (i == SelectedFrameIndex)  
                        Helper.DrawRectangle(Editor.spriteBatch, anim.Frames[i].Rect, new Color(Color.Red, 0.4f), 1);
                    else   
                        Helper.DrawRectangle(Editor.spriteBatch, anim.Frames[i].Rect, new Color(Color.Blue, 0.4f), 1);
                }
            }
            Editor.spriteBatch.Draw(Helper.PointTexture, 
                new Rectangle(Helper.ScreenToWorld(Mouse.GetState().Position, Editor.Camera).ToPoint(), new Point(2)), 
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
                prevMouseLeftDownPosition = new Vector2(e.X, e.Y);
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
                    _animations[SelectedAnimationIndex].Frames[SelectedFrameIndex].SetRect(spriteRect);
                }
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

            if (leftMouseButtonPressed && _texture != null)
            {
                
                Point mouseWorld = Helper.ScreenToWorld(new Point(e.X, e.Y), Editor.Camera).ToPoint();
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
