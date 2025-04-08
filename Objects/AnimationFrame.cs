namespace WinFormsApp1.Data;

using Microsoft.Xna.Framework;

public class AnimationFrame
{
    public int Id = 0;
    private string _name = "New Frame";
    private Rectangle _rect = Rectangle.Empty;
    private int _textureId;
    private int _frameTime = 10;

    public string Name => _name;
    public Rectangle Rect => _rect;
    public int TextureId => _textureId;
    public int FrameTime => _frameTime;

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

    public void SetFrameTime(int frameTime)
    {
        _frameTime = frameTime;
    }
}

