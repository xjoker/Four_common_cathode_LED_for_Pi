using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Four_common_cathode_LED_for_Pi
{
    class GPIO
    {
        static Process p = new Process();

        public enum GPIOStatic : int
        {
            GPIO_in = 1,
            GPIO_out = 2,
            GPIO_high = 3,
            GPIO_low = 4
        }

        //注册
        public static void GPIO_register(int[] num)
        {

            p.StartInfo.FileName = "sh";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();


            foreach (var item in num)
            {
                p.StandardInput.WriteLine("echo " + item + " > /sys/class/gpio/export");
            }
            p.Close();

        }

        //释放
        public static void GPIO_unregister(int[] num)
        {

            p.StartInfo.FileName = "sh";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();


            foreach (var item in num)
            {
                p.StandardInput.WriteLine("echo " + item + " > /sys/class/gpio/unexport");
            }
            p.Close();
        }

        //设置GPIO状态
        public static void GPIO_direction(int GPIO_Num, GPIOStatic status)
        {
            p.StartInfo.FileName = "sh";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();



            switch (status)
            {
                case GPIOStatic.GPIO_in:
                    p.StandardInput.WriteLine("echo in > /sys/class/gpio/gpio" + GPIO_Num + "/direction");
                    break;
                case GPIOStatic.GPIO_out:
                    p.StandardInput.WriteLine("echo out > /sys/class/gpio/gpio" + GPIO_Num + "/direction");
                    break;
                case GPIOStatic.GPIO_high:
                    p.StandardInput.WriteLine("echo high > /sys/class/gpio/gpio" + GPIO_Num + "/direction");
                    break;
                case GPIOStatic.GPIO_low:
                    p.StandardInput.WriteLine("echo low > /sys/class/gpio/gpio" + GPIO_Num + "/direction");
                    break;
                default:
                    break;
            }

            p.Close();
        }

        //发送1或者0
        public static void GPIO_send(int GPIO_Num, int GPIO_value)
        {
            p.StartInfo.FileName = "sh";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            p.StandardInput.WriteLine("echo " + GPIO_value + " > /sys/class/gpio/gpio" + GPIO_Num + "/value");
            p.Close();
        }
    }
}
