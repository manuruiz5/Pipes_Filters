using System;
using CompAndDel.Filters;
using CompAndDel;

namespace CompAndDel
{
public class FilterConditional :IFilter
{
    private readonly string imagePath;
    private readonly bool markFaces;

    public FilterConditional(string imagePath, bool markFaces)
    {
        this.imagePath=imagePath;
        this.markFaces=markFaces;
    }

    public bool Apply(IPicture image)
    {
        CognitiveFace cog=new CognitiveFace(this.markFaces, Color.GreenYellow);
        cog.Recognize(this.imagePath);

        return cog.FaceFound;
    }
}
}