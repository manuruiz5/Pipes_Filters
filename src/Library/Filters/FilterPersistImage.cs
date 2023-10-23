using System;
using System.IO;
using CompAndDel;
//Parte 2:creo un filtro para poder guardar la imagen en el disco
public class FilterPersistImage: IFilter
{
    private string outputPath;
    public FilterPersistImage(string outputPath)
    {
        this.outputPath=outputPath;
    }
    public IPicture Filter(IPicture image)
    {
        PictureProvider provider=new PictureProvider();
        provider.SavePicture(image, outputPath);
        return image;
    }
}