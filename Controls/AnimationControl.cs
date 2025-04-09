
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.NET.Controls;
using WinFormsApp1;
using WinFormsApp1.Objects;
using Color = Microsoft.Xna.Framework.Color;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Editor.Controls
{
    public class AnimationControl : MonoGameControl
    {
        private static readonly Point cameraClamp = new Point(50, 50);

        private Vector2 mouseDownPosition = Vector2.Zero;
        private Vector2 prevCameraPosition = Vector2.Zero;
        public MainControl MainControl;

        float timer = 0.0f;
        Texture2D currentTexture;
        bool setCameraFirstPosition = false;
        int currentFrameIndex = 0;

        private Vector2 screenCenter
        {
            get => new Vector2(Editor.GraphicsDevice.Viewport.Width / 2, Editor.GraphicsDevice.Viewport.Height / 2);
        }

        public void SelectAnimation()
        {
            timer = 0.0f;
        }

        protected override void Initialize()
        {

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
            if (MainControl == null) return;
            timer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer <= 0)
            {
                timer = float.MaxValue;
                currentFrameIndex++;
                if (MainControl.SelectedAnimationIndex >= 0 && MainControl.SelectedAnimationIndex < MainControl.Animations.Count)
                {
                    var animation = MainControl.Animations[MainControl.SelectedAnimationIndex];
                    if (animation != null && animation.Frames.Count > 0)
                    {
                        currentFrameIndex %= animation.Frames.Count;
                        var frame = animation.Frames[currentFrameIndex];
                        if (MainControl.TextureIds.ContainsKey(frame.TextureId))
                            currentTexture = MainControl.TextureIds[frame.TextureId].Texture;
                        timer = frame.FrameTime;
                    }
                }
            }
        }


        protected override void Draw()
        {
            if (currentTexture != null)
            {
                Vector2 clampSize = new Vector2(currentTexture.Width / 2.0f + cameraClamp.X, currentTexture.Height / 2.0f + cameraClamp.Y);
                Editor.Camera.Position = Vector2.Clamp(Editor.Camera.Position, screenCenter - clampSize, screenCenter + clampSize);
            }
            else
            {
                Vector2 clampSize = new Vector2(cameraClamp.X, cameraClamp.Y);
                Editor.Camera.Position = Vector2.Clamp(Editor.Camera.Position,
                    screenCenter - clampSize,
                    screenCenter + clampSize);
            }

            Editor.GraphicsDevice.Clear(Color.Black);
            Editor.BeginCamera2D(
                SpriteSortMode.Deferred,
                null,
                SamplerState.PointClamp
                );
            Editor.spriteBatch.Draw(Helper.PointTexture, new Rectangle((int)screenCenter.X - 5, (int)screenCenter.Y - 5, 10, 10), Color.White);
            if (MainControl != null)
            {
                if (MainControl.SelectedAnimationIndex >= 0 && MainControl.SelectedAnimationIndex < MainControl.Animations.Count)
                {
                    var animation = MainControl.Animations[MainControl.SelectedAnimationIndex];
                    if (animation != null && currentTexture != null && animation.Frames.Count > 0)
                    {
                        currentFrameIndex %= animation.Frames.Count;
                        var spriteRect = animation.Frames[currentFrameIndex].Rect;
                        var sourceRect = new Rectangle(
                            (int)screenCenter.X - spriteRect.Width / 2, 
                            (int)screenCenter.Y - spriteRect.Height / 2, 
                            spriteRect.Width,
                            spriteRect.Height);
                        Editor.spriteBatch.Draw(currentTexture, sourceRect, spriteRect, Color.White);
                    }
                }
               
            }
            Editor.EndCamera2D();
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

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Right)
            {
                Editor.Camera.Position = prevCameraPosition + (mouseDownPosition - new Vector2(e.X, e.Y));
            }

        }

        #endregion
    }
}
