using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CSharp直接连接MySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(VerifyUser("siki","siki155"));
        }

        static bool VerifyUser(string username,string password)//根据参数查询
        {
            //创建连接类实例
            string connectStr = "server=127.0.0.1;port=3306;database=taidou;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有跟数据库建立连接
            try
            {
                //建立连接
                conn.Open();
                Console.WriteLine("已经建立连接！");

                //创建sql命令类实例，执行想要的操作
                //string sql = "select * from user where username='"+username+"' and password='"+password+"'";//用到了C#字符串拼接"..."+username+"..."+password+"..."
                string sql = "select * from user where username=@username and password=@password";//使用@设置未知参数
                //string sql = "select id,username,password,age from user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("username", username);//调用MySqlComman实例.Parameters.AddWithValue()解析未知参数，绑定对应变量
                cmd.Parameters.AddWithValue("password",password);

                MySqlDataReader reader = cmd.ExecuteReader();

                //reader.Read();//读取下一页数据，如果读取成功，返回true；如果没有下一页了，读取失败，返回false
                if (reader.Read())
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();//关闭连接
            }
            return false;
        }

        static void Read()//查询
        {
            //创建连接类实例
            string connectStr = "server=127.0.0.1;port=3306;database=taidou;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有跟数据库建立连接
            try
            {
                //建立连接
                conn.Open();
                Console.WriteLine("已经建立连接！");

                //创建sql命令类实例，执行想要的操作
                string sql = "select * from user";
                //string sql = "select id,username,password,age from user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                //reader.Read();//读取下一页数据，如果读取成功，返回true；如果没有下一页了，读取失败，返回false
                //Console.WriteLine("id:"+reader[0].ToString()+" username:"+reader[1].ToString()+" password:"+reader[2].ToString()+" age:"+reader[3].ToString());
                while (reader.Read())
                {
                    //直接使用reader[0]...reader[columnCount-1]取得字段
                    //Console.WriteLine("id:" + reader[0].ToString() + " username:" + reader[1].ToString() + " password:" + reader[2].ToString() + " age:" + reader[3].ToString());

                    //使用reader.getint32(0)...reader.getint32(columnCount-1)和reader.getstring(0)...reader.getstring(columnCount-1)取得字段
                    Console.WriteLine("id:"+reader.GetInt32(0)+" username:"+reader.GetString(1)+" password:"+reader.GetString(2)+" age:"+reader.GetString(3));

                    //使用reader.getint32("columnName")和reader.getstring("columnName")取得字段
                    Console.WriteLine("id:"+reader.GetInt32("id")+" username:"+reader.GetString("username")+" password:"+reader.GetString("password")+" age"+reader.GetString("age"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }

        static void Insert()//插入
        {
            //创建连接类实例
            string connectStr = "server=127.0.0.1;port=3306;database=taidou;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有跟数据库建立连接
            try
            {
                //建立连接
                conn.Open();
                Console.WriteLine("已经建立连接！");

                //创建sql命令类实例，执行想要的操作
                //string sql = "insert into user(username,password,age) values('sk','sk154',31)";
                //string sql = "insert into user(username,password,age,registerdate) values('coco','coco153',32,'2014-01-23')";
                string sql = "insert into user(username,password,age,registerdate) values('cc','cc152',33,'"+DateTime.Now+"')";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result=cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }

        static void Update()//修改
        {
            //创建连接类实例
            string connectStr = "server=127.0.0.1;port=3306;database=taidou;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有跟数据库建立连接
            try
            {
                //建立连接
                conn.Open();
                Console.WriteLine("已经建立连接！");

                //创建sql命令类实例，执行想要的操作
                string sql = "update user set registerdate='"+DateTime.Now+"' where id<>6";//不等号<>,!=
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }

        static void Delete()//删除
        {
            //创建连接类实例
            string connectStr = "server=127.0.0.1;port=3306;database=taidou;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有跟数据库建立连接
            try
            {
                //建立连接
                conn.Open();
                Console.WriteLine("已经建立连接！");

                //创建sql命令类实例，执行想要的操作
                string sql = "delete from user where id=6";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }

        static void ReadCount()//读取表格记录数
        {
            //创建连接类实例
            string connectStr = "server=127.0.0.1;port=3306;database=taidou;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有跟数据库建立连接
            try
            {
                //建立连接
                conn.Open();
                Console.WriteLine("已经建立连接！");

                //创建sql命令类实例，执行想要的操作
                string sql = "select count(*) from user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //使用ExecuteReader()执行查询，返回整张表格
                //MySqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();
                //Console.WriteLine(Convert.ToInt32(reader[0].ToString()));

                //使用ExecuteScaler()执行查询,直接返回记录数
                Console.WriteLine(Convert.ToInt32(cmd.ExecuteScalar().ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }
    }
}
