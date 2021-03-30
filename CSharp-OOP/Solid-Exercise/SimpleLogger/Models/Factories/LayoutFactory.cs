using SimpleLogger.Layout;
using SimpleLogger.Layout.Contracts;

namespace SimpleLogger.Models.Factories
{
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;
            if (layoutType == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (layoutType == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            return layout;
        }
    }
}
