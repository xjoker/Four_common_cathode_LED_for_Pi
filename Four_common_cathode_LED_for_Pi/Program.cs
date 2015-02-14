using System.Diagnostics;
using System.Threading;

namespace Four_common_cathode_LED_for_Pi
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] GPIO_N = { 4, 17, 18, 27, 21, 20, 26, 19, 25, 16, 13, 6 };

            GPIO.GPIO_register(GPIO_N);

            GPIO.GPIO_direction(4, GPIO.GPIOStatic.GPIO_out);
            GPIO.GPIO_direction(17, GPIO.GPIOStatic.GPIO_out);
            GPIO.GPIO_direction(18, GPIO.GPIOStatic.GPIO_out);
            GPIO.GPIO_direction(27, GPIO.GPIOStatic.GPIO_out);

            while (true)
            {
                //5
                GPIO.GPIO_direction(21, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(19, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(16, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(6, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(26, GPIO.GPIOStatic.GPIO_low);

                GPIO.GPIO_send(4, 1);
                Thread.Sleep(300);
                GPIO.GPIO_send(4, 0);

                int[] a = { 21, 19, 16, 6, 26 };
                GPIO.GPIO_unregister(a);
                GPIO.GPIO_register(a);
                ////////////////////////////////////////////


                //2
                GPIO.GPIO_direction(21, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(20, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(26, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(13, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(16, GPIO.GPIOStatic.GPIO_low);

                GPIO.GPIO_send(17, 1);
                Thread.Sleep(300);
                GPIO.GPIO_send(17, 0);

                int[] b = { 21, 20, 26, 13, 16 };
                GPIO.GPIO_unregister(b);
                GPIO.GPIO_register(b);
                ////////////////////////////////////////////


                //0
                GPIO.GPIO_direction(21, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(20, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(19, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(16, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(13, GPIO.GPIOStatic.GPIO_low);
                GPIO.GPIO_direction(6, GPIO.GPIOStatic.GPIO_low);

                GPIO.GPIO_send(18, 1);
                Thread.Sleep(300);
                GPIO.GPIO_send(18, 0);

                int[] c = { 21, 20, 19, 13, 16, 6 };
                GPIO.GPIO_unregister(c);
                GPIO.GPIO_register(c);
                ////////////////////////////////////////////

            }


        }
    }
}
