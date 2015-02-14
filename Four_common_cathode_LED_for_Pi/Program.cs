using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Four_common_cathode_LED_for_Pi
{
    class Program
    {
        static void Main(string[] args)
        {
            //4位初始化
            GPIO.GPIO_Control(4, SetGPIOState.GPIOState.GPIO_out);
            GPIO.GPIO_Control(17, SetGPIOState.GPIOState.GPIO_out);
            //GPIO.GPIO_Control(18, SetGPIOState.GPIOState.GPIO_out);
            //GPIO.GPIO_Control(27, SetGPIOState.GPIOState.GPIO_out);

            //8个阴极的启动方式
            //GPIO.GPIO_Control(21, SetGPIOState.GPIOState.GPIO_low);     ---    A
            //GPIO.GPIO_Control(20, SetGPIOState.GPIOState.GPIO_low);     ---    B
            //GPIO.GPIO_Control(26, SetGPIOState.GPIOState.GPIO_low);     ---    G
            //GPIO.GPIO_Control(19, SetGPIOState.GPIOState.GPIO_low);     ---    C
            //GPIO.GPIO_Control(25, SetGPIOState.GPIOState.GPIO_low);     ---    P
            //GPIO.GPIO_Control(16, SetGPIOState.GPIOState.GPIO_low);     ---    D
            //GPIO.GPIO_Control(13, SetGPIOState.GPIOState.GPIO_low);     ---    E
            //GPIO.GPIO_Control(6, SetGPIOState.GPIOState.GPIO_low);      ---    F

            //输出数字5

            while (true)
            {
                //第一位5
                GPIO.GPIO_Control(21, SetGPIOState.GPIOState.GPIO_low);
                GPIO.GPIO_Control(26, SetGPIOState.GPIOState.GPIO_low);
                GPIO.GPIO_Control(19, SetGPIOState.GPIOState.GPIO_low);
                GPIO.GPIO_Control(16, SetGPIOState.GPIOState.GPIO_low);
                GPIO.GPIO_Control(6, SetGPIOState.GPIOState.GPIO_low);

                GPIO.GPIO_Send(4, 1);

                Thread.Sleep(1);

                GPIO.GPIO_Send(4, 0);
                //GPIO.GPIO_Release_num();
                //Thread.Sleep(1000);


                //GPIO.GPIO_Control(21, SetGPIOState.GPIOState.GPIO_high);
                //GPIO.GPIO_Control(26, SetGPIOState.GPIOState.GPIO_high);
                //GPIO.GPIO_Control(19, SetGPIOState.GPIOState.GPIO_high);
                //GPIO.GPIO_Control(16, SetGPIOState.GPIOState.GPIO_high);
                //GPIO.GPIO_Control(6, SetGPIOState.GPIOState.GPIO_high);


                //第二位2
                GPIO.GPIO_Control(21, SetGPIOState.GPIOState.GPIO_low);
                GPIO.GPIO_Control(20, SetGPIOState.GPIOState.GPIO_low);
                GPIO.GPIO_Control(26, SetGPIOState.GPIOState.GPIO_low);
                GPIO.GPIO_Control(13, SetGPIOState.GPIOState.GPIO_low);
                GPIO.GPIO_Control(16, SetGPIOState.GPIOState.GPIO_low);

                GPIO.GPIO_Send(17, 1);

                Thread.Sleep(1);

                GPIO.GPIO_Send(17, 0);
               // GPIO.GPIO_Release_num();

            }
            

        }
    }
}
