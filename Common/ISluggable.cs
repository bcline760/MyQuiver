using System;
namespace MyQuiver
{
    public interface ISluggable
    {
        string Slug { get; set; }

        void Update();
    }
}
