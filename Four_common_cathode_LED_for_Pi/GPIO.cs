using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Four_common_cathode_LED_for_Pi
{
    class GPIO
    {
        public static string export;
        public static string sendGPIO;
        public static string direction;


        public static void GPIO_Control(int GPIO_Num,SetGPIOState.GPIOState status)
        {
            //添加管理的GPIO
            export = "echo " + GPIO_Num + " > /sys/class/gpio/export";

            //判断设置GPIO的类型
            switch (status)
            {
                case SetGPIOState.GPIOState.GPIO_in:
                    direction = "echo in > /sys/class/gpio/gpio" + GPIO_Num + "/direction";
                    break;
                case SetGPIOState.GPIOState.GPIO_out:
                    direction = "echo out > /sys/class/gpio/gpio" + GPIO_Num + "/direction";
                    break;
                case SetGPIOState.GPIOState.GPIO_high:
                    direction = "echo high > /sys/class/gpio/gpio" + GPIO_Num + "/direction";
                    break;
                case SetGPIOState.GPIOState.GPIO_low:
                    direction = "echo low > /sys/class/gpio/gpio" + GPIO_Num + "/direction";
                    break;
                default:
                    break;
            }

            Process p = new Process();
            p.StartInfo.FileName = "sh";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            //启动控制开始
            p.StandardInput.WriteLine(export);
            p.StandardInput.WriteLine(direction);
            p.Close();
        }

        public static void GPIO_Send(int GPIO_Num,int GPIO_value)
        {
            ////当GPIO_value进来的值不为1或者0的时候强制设置为0
            //if (GPIO_value == 1 || GPIO_value == 0)
            //    GPIO_value = 0;

            //发送指令，只可发送1或者0
            sendGPIO = "echo " + GPIO_value + " > /sys/class/gpio/gpio" + GPIO_Num + "/value";

            Process p = new Process();
            p.StartInfo.FileName = "sh";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(sendGPIO);
            p.Close();
        }

        public static void GPIO_Release(int GPIO_Num)
        {
            string release = "echo " + GPIO_Num + " > /sys/class/gpio/unexport";

            Process p = new Process();
            p.StartInfo.FileName = "sh";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            p.StandardInput.WriteLine(release);
            p.Close();

        }

        public static void GPIO_Release_num()
        {
            string release;

            Process p = new Process();
            p.StartInfo.FileName = "sh";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            for (int i = 0; i <= 26; i++)
            {
                release = "echo " + i + " > /sys/class/gpio/unexport";
                p.StandardInput.WriteLine(release);
            }
            
            p.Close();

        }

    }
}
