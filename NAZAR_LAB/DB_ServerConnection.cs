using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
namespace NAZAR_LAB
{
    public class DB_ServerConnection // singleton
    {
        private Socket sender1;
        private IPAddress ipAddr;
        private IPEndPoint localEndPoint;

        private static DB_ServerConnection instance;

        public static DB_ServerConnection getInstance()
        {
            if (instance == null)
                instance = new DB_ServerConnection();
            return instance;
        }

        private DB_ServerConnection()
        {
            try
            {
            
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                ipAddr = IPAddress.Parse("192.168.2.185");
                localEndPoint = new IPEndPoint(ipAddr, 11111);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
             }
         }
        public string Connect(string request)
        {
            try
            {
                sender1 = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender1.Connect(localEndPoint);
                byte[] messageSent = Encoding.UTF8.GetBytes(request);
                int byteSent = sender1.Send(messageSent);

                byte[] messageReceived = new byte[1024*1024];
                int byteRecv = sender1.Receive(messageReceived);

                sender1.Shutdown(SocketShutdown.Both);
                sender1.Close();
                return Encoding.UTF8.GetString(messageReceived, 0, byteRecv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        public static List<Student> MakeListFromString(string str)
        {
            string[] data = str.Split('/');
            List <Student> students_list = new List<Student>();
            for (int i = 0; i < data.Length / 7; ++i)
            {
                students_list.Add(new Student
                {
                    FirstName = data[i * 7 + 0],
                    LastName = data[i * 7 + 1],
                    Age = data[i * 7 + 2],
                    Group = data[i * 7 + 3],
                    Institute = data[i * 7 + 4],
                    Specialty = data[i * 7 + 5],
                    Student_Card_ID = data[i * 7 + 6]
                });
            }
            return students_list;
        }
    }
}

