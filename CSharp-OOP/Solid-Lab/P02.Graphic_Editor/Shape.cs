namespace P02.Graphic_Editor
{
    public abstract class Shape : IShape
    {
        public string Draw()
        {
            return $"I'm {this.GetType().Name}";
        }
    }
}
