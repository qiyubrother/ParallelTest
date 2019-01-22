/*
 * Created by SharpDevelop.
 * User: Liuzhenhua
 * Date: 2019/1/21
 * Time: 11:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Concurrent;
using System.Data;

namespace ImportTestData
{
	class Program
	{
		public static void Main(string[] args)
		{
            var cmdPool = new ObjectPool<MySqlCommand>(()=>new MySqlCommand());

            var gElevatorCompanyId = "-2";
            var gRobotCompanyId = "-2";
            var maxTestPower = 10000;
            var pos = 1;

            using (var conn = new MySqlConnection("Server=localhost;Port=3306;Database=nnhuman.cloudelevator;uid=root;pwd=123456;SslMode=none;"))
			{
                conn.Open();

                var dt = new DataTable();
                var ada = new MySqlDataAdapter("select max(pos) as max_pos from elevatorfloor", conn);
                ada.Fill(dt);
                pos = Convert.ToInt32(dt.Rows[0][0]);
                 
                var cmd = cmdPool.GetObject();
                cmd.Connection = conn;

                #region 删除数据
                Console.WriteLine($"[{DateTime.Now}]正在删除数据...");
                //cmd.CommandText = string.Format($"delete from elevatorcompany where ElevatorCompanyId = '{gElevatorCompanyId}'");
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = string.Format($"delete from robotcompany where RobotCompanyId = '{gRobotCompanyId}'");
                //cmd.ExecuteNonQuery();
                for (var i = 1; i <= maxTestPower; i++)
                {
                    var gHotelId = 2 * maxTestPower + i;
                    var currElevatorId = $"1867411714321213{i.ToString().PadLeft(4, '0')}";
                    //cmd.CommandText = string.Format($"delete from hotel where hotelId = '{gHotelId}'");
                    //cmd.ExecuteNonQuery();
                    cmd.CommandText = string.Format($"delete from hotelelevator where hotelId = '{gHotelId}'");
                    cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"delete from hotelrobot where hotelId = '{gHotelId}'");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"delete from robotmap where RobotCompanyId = '{gRobotCompanyId}'");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"delete from elevatoridmodule where ElevatorCompanyId = '{gElevatorCompanyId}'");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"delete from elevatorfloor where ElevatorId = '{currElevatorId}'");
                    //cmd.ExecuteNonQuery();
                }

                #endregion

                #region 插入数据
                Console.WriteLine($"[{DateTime.Now}]正在添加数据...");
                //cmd.CommandText = string.Format($"INSERT INTO elevatorcompany(ElevatorCompanyId, Company) VALUES ('{gElevatorCompanyId}', '压力测试专用电梯公司')");
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = string.Format($"INSERT INTO robotcompany(RobotCompanyId, Company, CompanyAbbreviation, CompanyTag) VALUES ('{gRobotCompanyId}', '压力测试专用机器人公司', 'YLCS', 'YLCS')");
                //cmd.ExecuteNonQuery();

                for (var i = 1; i <= maxTestPower; i++)
                {
                    var fmtIndex = i.ToString().PadLeft(4, '0');

                    var gHotelId = 2* maxTestPower + i;
                    var currElevatorId = $"1867411714321213{i.ToString().PadLeft(4, '0')}";

                    //cmd.CommandText = string.Format($"INSERT INTO hotel(hotelId, hotelName, city, address) VALUES ('{gHotelId}', '压力测试专用酒店{fmtIndex}', 'beijing', '')");
                    //cmd.ExecuteNonQuery();

                    cmd.CommandText = string.Format($"INSERT INTO hotelelevator(hotelId, ElevatorId) VALUES ('{gHotelId}', '{currElevatorId}')");
                    cmd.ExecuteNonQuery();

                    //cmd.CommandText = string.Format($"INSERT INTO hotelrobot(hotelId, UniqueRobotSN, HotelRobotNo) VALUES ('{gHotelId}', 'YLCS-RobotSN{fmtIndex}', 1)");
                    //cmd.ExecuteNonQuery();

                    //cmd.CommandText = string.Format($"INSERT INTO robotmap(UniqueRobotSN, RobotSN, RobotCompanyId) VALUES ('YLCS-RobotSN{fmtIndex}', 'RobotSN{fmtIndex}', '{gRobotCompanyId}')");
                    //cmd.ExecuteNonQuery();

                    //cmd.CommandText = string.Format($"INSERT INTO elevatoridmodule(ElevatorCompanyId, ElevatorID, ModuleName) VALUES ('{gElevatorCompanyId}', '{currElevatorId}', '')");
                    //cmd.ExecuteNonQuery();

                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '1', '1', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '2', '2', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '3', '3', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '4', '4', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '5', '5', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '6', '6', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '7', '7', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '8', '8', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '9', '9', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', 'A', '10', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', 'B', '11', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', 'C', '12', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', 'D', '13', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', 'E', '14', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', 'F', '15', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '10', '16', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '11', '17', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '12', '18', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '13', '19', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '14', '20', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '15', '21', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '16', '22', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '17', '23', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '18', '24', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '19', '25', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '1A', '26', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '1B', '27', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '1C', '28', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '1D', '29', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '1E', '30', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '1F', '31', {pos++})");
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandText = string.Format($"INSERT INTO elevatorfloor(ElevatorId, InnerCode, Display, Pos) VALUES ('{currElevatorId}', '20', '32', {pos++})");
                    //cmd.ExecuteNonQuery();
                }
                #endregion

                cmdPool.PutObject(cmd);
            }

            Console.Write($"[{DateTime.Now}]数据库初始化完成.");
			Console.ReadKey(true);
		}
	}

    /// <summary>
    /// 对象池类，用于高性能服务器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T>
    {
        private ConcurrentBag<T> _objects;
        private Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            _objects = new ConcurrentBag<T>();
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException("objectGenerator");
        }

        public T GetObject() => _objects.TryTake(out T item) ? item : _objectGenerator();

        public void PutObject(T item)
        {
            _objects.Add(item);
        }
    }
}