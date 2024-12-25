using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strukturni_paterni
{
    // Интерфейс устройства
    public interface IDevice
    {
        void Print(string data);
    }

    // Конкретные устройства
    public class Monitor : IDevice
    {
        public void Print(string data)
        {
            Console.WriteLine("Displaying on monitor: " + data);
        }
    }

    public class Printer : IDevice
    {
        public void Print(string data)
        {
            Console.WriteLine("Printing to paper: " + data);
        }
    }

    // Абстракция вывода
    public abstract class Output
    {
        protected IDevice Device;

        public Output(IDevice device)
        {
            Device = device;
        }

        public abstract void Render(string data);
    }

    // Конкретные абстракции
    public class TextOutput : Output
    {
        public TextOutput(IDevice device) : base(device) { }

        public override void Render(string data)
        {
            Device.Print("Text: " + data);
        }
    }

    public class ImageOutput : Output
    {
        public ImageOutput(IDevice device) : base(device) { }

        public override void Render(string data)
        {
            Device.Print("Image: [Binary data: " + data + "]");
        }
    }

}
