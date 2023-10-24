using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parte 1:carga una imagen, crea instancias de filtros, crea instacnias de pipes
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"Program/beer.jpg");

            IFilter greyscaleFilter= new FilterGreyscale();
            IFilter negativeFilter=new FilterNegative();
            IPipe pipe1=new PipeSerial(greyscaleFilter, new PipeNull());
            IPipe pipe2=new PipeSerial(negativeFilter,new PipeNull());

            //Parte2:Agregarle el filtro de persistencia a la imagen para q me guarda la imagen con solo 1 filtro aplicado
            IPipe pipePersist=new PipeSerial(new FilterPersistImage("Program/beer2.jpg"),pipe1);
            
            IPicture image=pipe2.Send(pipePersist.Send(picture));
            PictureProvider pic= new PictureProvider();
            pic.SavePicture(image, "Program/beerfinal.jpg");

        }
    }
}
