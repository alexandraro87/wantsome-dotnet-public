namespace OpenClosedDrawingShapesAfter
{
    using OpenClosedDrawingShapesAfter.Contracts;

    public class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            shape.Draw();
        }
    }
}
