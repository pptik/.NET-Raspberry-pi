using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using System.Threading;
using System.Threading.Tasks;

namespace WiringPiDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");

            Console.WriteLine(Pi.Info);
            Pi.Init<BootstrapWiringPi>();
            var tokenSource = new CancellationTokenSource();
            var task = Blink(BcmPin.Gpio17, tokenSource.Token);
            Console.ReadLine();
            tokenSource.Cancel();
            task.Wait();

        }

        static async Task Blink(BcmPin pinNumber, CancellationToken cancellationToken)
    {
        var pin = Pi.Gpio[pinNumber];
        pin.PinMode = GpioPinDriveMode.Output;

        while (!cancellationToken.IsCancellationRequested)
        {
            pin.Write(!pin.Value);
            await Task.Delay(500);
        }

        pin.Write(false);
    }
    }

    
}
