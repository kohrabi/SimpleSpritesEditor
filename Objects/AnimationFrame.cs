namespace WinFormsApp1.Data;

using Microsoft.Xna.Framework;

public class AnimationFrame
{
    private string _name = "New Frame";
    private Rectangle _rect = Rectangle.Empty;
    private int _textureId = -1;

    public string Name => _name;
    public Rectangle Rect => _rect;
    public int TextureId => _textureId;

    public AnimationFrame(int textureId)
    {
        _textureId = textureId;
    }
    
    public void SetName(string name)
    {
        _name = name;
    }

    public void SetRect(Rectangle rect)
    {
        _rect = rect;
    }
}

