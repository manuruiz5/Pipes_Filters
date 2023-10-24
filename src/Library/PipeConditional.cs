using System;
using CompAndDel.Filters;
using CompAndDel.Pipes;

namespace CompAndDel
{
public class PipeConditional: IPipe
{
    private IFilter trueFilter;
    private IFilter falseFilter;

    public PipeConditional(IFilter trueFilter, IFilter falseFilter)
    {
        this.trueFilter=trueFilter;
        this.falseFilter=falseFilter;
    }

    public IPicture Send(IPicture picture)
    {
        FilterConditional conditionalFilter=new FilterConditional("PathToImage.jpg", true);

        bool condition=conditionalFilter.Apply(picture);

        if (condition)
        {
            return trueFilter.Apply(picture);
        }
        else
        {
            return falseFilter.Apply(picture);
        }
    }
}
}