using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MakeRobotConfig
{
    class MakeRobotConfigProgram
    {
        static void Main(string[] args)
        {
            var s = File.ReadAllText("./cfgTmpl/RobotSetting.json")
                .Replace("{Url}", "192.168.0.6")
                .Replace("{CompanyTag}", "YLCS")
                ;

            var maxTestPower = 10000;
            var r = new Random(DateTime.Now.Millisecond);
            var floorCode = new  []{ 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10,
                                     0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C,
                                     0x3E, 0x3F, 0x40, 0x41};
            Console.WriteLine($"[{DateTime.Now}]正在创建配置文件...");
            for (var i = 1; i <= maxTestPower; i++)
            {
                var fmtIndex = i.ToString().PadLeft(4, '0');
                var robotSN = $"RobotSN{ fmtIndex}";
                var fromFloorNo = r.Next(0, floorCode.Length - 1);
                var toFloorNo = 0;
                do
                {
                    toFloorNo = r.Next(0, floorCode.Length - 1);
                } while (fromFloorNo == toFloorNo);
                var fileName = $"./cfg/RobotSetting-{fmtIndex}.json";
                var content = s.Replace("{RobotSN}", robotSN)
                                .Replace("{FromFloorNo}", Convert.ToString(floorCode[fromFloorNo], 16))
                                .Replace("{ToFloorNo}", Convert.ToString(floorCode[toFloorNo], 16))
                                ;
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
