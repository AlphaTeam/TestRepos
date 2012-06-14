using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Configuration;

namespace WinFormGameClient
{
    public class SocketClient
   {
        private const int ByteMessageSize = 1000;

        private TcpClient client;
        private NetworkStream clientStream;
        private IPAddress address;
        private UInt16 port;
        private ASCIIEncoding encoder = new ASCIIEncoding();

        public SocketClient()
        {
            this.client = new TcpClient();
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 54321);
                client.Connect(serverEndPoint);
                this.clientStream = client.GetStream();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Can't connect to server! Error: " + e.Message, e.Source);
            }
        }

        public SocketClient(string ipAddress, UInt16 port)
        {
            this.client = new TcpClient();
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                client.Connect(serverEndPoint);
                this.clientStream = client.GetStream();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Can't connect to server! Error: " + e.Message, e.Source);
            }
        }

        public string Partner { get; set; }

        public string ClientStreamStr
        {
            set
            {
                byte[] buffer = encoder.GetBytes(value);
                this.clientStream.Flush();
                this.clientStream.Write(buffer, 0, buffer.Length);
                this.clientStream.Flush();
            }
            get
            {
                byte[] message = new byte[ByteMessageSize];
                int bytesRead = 0;
                bytesRead = clientStream.Read(message, 0, ByteMessageSize);
                string str = this.encoder.GetString(message, 0, bytesRead);
                return str;
            }
        }

        public string Address
        {
            set
            {
                this.address = IPAddress.Parse(value);
            }
            get
            {
                return this.address.ToString();
            }
        }

        public UInt16 Port
        {
            set
            {
                this.port = value;
            }
            get
            {
                return this.port;
            }
        }

        public string[] GetGamersList()
        {
            this.sendRefreshCommand();
            string[] gamersList = this.ClientStreamStr.Split(new string[] { "||" }, System.StringSplitOptions.RemoveEmptyEntries);
            return gamersList;
        }

        public void SendCredentials(string senderName)
        {
            this.ClientStreamStr = "##NAME##::" + senderName + "::";
        }

        /// <summary>
        /// Checks if some client sent ivite for game
        /// </summary>
        /// <returns></returns>
        internal bool CheckInvite()
        {
            bool flag = false;
            string[] messageStrings = this.ClientStreamStr.Split(new string[] { "::" }, System.StringSplitOptions.RemoveEmptyEntries);

            if (messageStrings[0].Equals("##INVITE##"))
            {
                flag = true;
                this.Partner = messageStrings[1];
            }

            return flag;
        }

        /// <summary>
        /// Sends command 'invite' to another client
        /// </summary>
        /// <param name="receiverName">Name of the client</param>
        internal void SendInviteTo(string receiverName, string senderName)
        {
            this.ClientStreamStr = "##INVITE##::" + receiverName + "::" + senderName + "::";
        }

        /// <summary>
        /// Sends command 'refresh' to the game server.
        /// </summary>
        /// <param name="clientName"></param>
        private void sendRefreshCommand()
        {
            this.ClientStreamStr = "##REFRESH##::";
        }

        
    }
}
