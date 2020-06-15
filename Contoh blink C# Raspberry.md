# Contoh Program C# pada Raspberry pi 3

Buka visual studio code 
untuk tools dan software yang harus diinstall dapat dilihat pada [Readme](https://github.com/pptik/.NET-Raspberry-pi/blob/master/README.md#net-raspberry-pi)

import library yang digunakan

```
using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using System.Threading;
using System.Threading.Tasks;
```


Buat main program

```
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
```

Buat method untuk fungsi blink
```
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
 ```
 
 
