using System.Drawing;

namespace Shuttle.Core.Infrastructure
{
    public interface IPresentationResource
    {
        string Text { get; set; }
        Image Image { get; set; }
        bool HasImage { get; }
    }
}