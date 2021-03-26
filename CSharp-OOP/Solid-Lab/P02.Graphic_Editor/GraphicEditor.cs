namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public string DrawShape(IShape shape)
        {
            return shape.Draw();
        }
    }
}
