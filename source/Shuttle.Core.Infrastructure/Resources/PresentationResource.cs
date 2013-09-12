using System.Drawing;

namespace Shuttle.Core.Infrastructure
{
    public class PresentationResource : IPresentationResource
    {
        public PresentationResource(string text)
            : this(text, null)
        {
        }

        public PresentationResource(string text, Image image)
        {
            Text = text;
            Image = image;
        }

        public string Text { get; set; }
        public Image Image { get; set; }

        public bool HasImage
        {
            get { return Image != null; }
        }

        public static IPresentationResource Create(string text)
        {
            return new PresentationResource(text);
        }

        public static IPresentationResource Create(string text, Image image)
        {
            return new PresentationResource(text, image);
        }
    }
}