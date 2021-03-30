using SimpleLogger.Layout.Contracts;
using System;
using System.Text;

namespace SimpleLogger.Layout
{
    public class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine("   <date>{0}</date>");
            sb.AppendLine("   <level>{1}</level>");
            sb.AppendLine("   <message>{2}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
