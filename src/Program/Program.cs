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
            IPicture picture = provider.GetPicture(@"PathToImageToLoad.jpg");

            IFilter greyscaleFilter= new FilterGreyscale();
            IFilter negativeFilter=new FilterNegative();
            IPipe pipe1=new PipeSerial(greyscaleFilter, new PipeNull());
            IPipe pipe2=new PipeSerial(negativeFilter,new PipeNull());

            IPicture image=pipe1.Send(picture);
            IPicture finalImage=pipe2.Send(image);

        }
    }
}
