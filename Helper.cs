using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.NET.Components.Interfaces;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace WinFormsApp1;

public static class Helper
{
    
    public static Texture2D PointTexture;
    public static Vector2 ScreenToWorld(Point screenPosition, ICamera2D camera)
    {
        return Vector2.Transform(screenPosition.ToVector2(), Matrix.Invert(camera.GetTransform()));
    }
        
    public static void DrawGrid(SpriteBatch spriteBatch, int rows, int cols, int gridSize, int addedX, int addedY)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                DrawRectangle(spriteBatch, 
                    new Rectangle(j * gridSize + addedX, i * gridSize + addedY, gridSize, gridSize), 
                    new Color(Color.DarkBlue, 0.2f), 
                    1);
        }
    }
        
    public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color, int lineWidth)
    {
        spriteBatch.Draw(PointTexture,
            new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
        spriteBatch.Draw(PointTexture, 
            new Rectangle(rectangle.X + 1, rectangle.Y, rectangle.Width + lineWidth - 1, lineWidth), color);
        spriteBatch.Draw(PointTexture, 
            new Rectangle(rectangle.X + rectangle.Width, rectangle.Y + 1, lineWidth, rectangle.Height + lineWidth - 1), color);
        spriteBatch.Draw(PointTexture, 
            new Rectangle(rectangle.X + 1, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth - 1, lineWidth), color);
    }
}