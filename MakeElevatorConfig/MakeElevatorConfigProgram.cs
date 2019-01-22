using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MakeElevatorConfig
{
    class MakeElevatorConfigProgram
    {
        static void Main(string[] args)
        {
            var s = File.ReadAllText("./cfgTmpl/ElevatorSetting.json")
                .Replace("{ServerIp}", "192.168.0.6")
                .Replace("{ServerIp}", "58395");

            var maxTestPower = 10000;
            Console.WriteLine($"[{DateTime.Now}]正在创建配置文件...");
            for (var i = 1; i <= maxTestPower; i++)
            {
                var currElevatorId = $"1867411714321213{i.ToString().PadLeft(4, '0')}";
                var fileName = $"./cfg/ElevatorSetting-{currElevatorId}.json";
                var content = s.Replace("{ElevatorId}", currElevatorId);
                if (!Directory.Exists("./cfg"))
                {
                    Directory.CreateDirectory("./cfg");
                }
                File.WriteAllText(fileName, content);
            }
            Console.WriteLine($"[{DateTime.Now}]创建完成！");
            Console.ReadKey(true);
        }
    }
}
