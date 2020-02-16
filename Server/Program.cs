using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            IPAddress ipAddr = IPAddress.Parse("192.168.2.185");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // MessageBox.Show("Connection Open  !");
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                while (true)
                {
                    Console.WriteLine("Waiting connection ... ");
                    Socket clientSocket = listener.Accept();
                    Console.WriteLine("Connected!");
                    byte[] bytes = new Byte[1024 * 1024];

                    int numByte = clientSocket.Receive(bytes);

                    string data = Encoding.UTF8.GetString(bytes, 0, numByte);

                    Console.WriteLine("Text received -> {0} ", data);

                    string answer = DB_Req(data);
                    
                    byte[] message = Encoding.UTF8.GetBytes(answer);

                    clientSocket.Send(message);

                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
        private static String DB_Req(string request)
        {
            string connetionString = @"Data Source = localhost;Initial Catalog = Students_DB; Integrated Security = True";
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = request;
            SqlDataReader reader = cmd.ExecuteReader();
            string res = "";
            while (reader != null && reader.Read())
            {

                for(int i = 0; i < reader.FieldCount; ++i)
                    res += reader[i].ToString() + "/";
            }
            Console.WriteLine(res);
            cnn.Close();
            return res;
        }
    }
}
