using Point = Microsoft.Xna.Framework.Point;

namespace WinFormsApp1;

public struct EditorSetting
{
    public string Delimeter = " ";
    public Point GridSize = new Point(16);

    public EditorSetting()
    {}
}