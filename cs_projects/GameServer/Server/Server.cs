using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Server
{
    class Server
    {
        private List<Client> listOfGamers = new List<Client>();
        private List<Couple> listOfGames = new List<Couple>();
        private int idCount = 0;
        private int gameIDCount = 0;

        private TcpListener tcpListener;
        private Thread listenThread;
        private ASCIIEncoding encoder = new ASCIIEncoding();
        private const int ByteMessageSize = 1000;

        private class NetworkClient
        {
            public TcpClient tcpClient;
            public int HostThreadID;
        }

        private List<NetworkClient> ListOfNetworkClient = new List<NetworkClient>();

        public Server()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 54321);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        private Couple getIDOfGamers(string message)
        {
            Couple gamers = new Couple();
            
            return gamers;
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();
            Console.WriteLine("Server is started");

            while (true)
            {
                ///blocks until a client has connected to the server
                NetworkClient client = new NetworkClient();
                client.tcpClient = this.tcpListener.AcceptTcpClient();
                ///create a thread to handle communication 
                ///with connected client
                Thread clientThread = new Thread(HandleClientComm);//new ParameterizedThreadStart(HandleClientComm));
                client.HostThreadID = clientThread.ManagedThreadId;

                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            NetworkClient nClient = (NetworkClient)client;
            //TcpClient tcpClient = nClient.tcpClient;
            
            NetworkStream clientStream = nClient.tcpClient.GetStream();
            byte[] message = new byte[ByteMessageSize];
            int bytesRead;
            string stringToProcess;
            string[] messageStrings;
            string header;
            string body;

            this.ListOfNetworkClient.Add(nClient);

            while (true)
            {
                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, ByteMessageSize);
                    clientStream.Flush();
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                stringToProcess = this.encoder.GetString(message, 0, bytesRead);
                messageStrings = stringToProcess.Split(new string[] { "::" }, System.StringSplitOptions.RemoveEmptyEntries);
                header = messageStrings[0];

                if(header.Equals("##NAME##"))
                {
                    this.addPlayerToList(messageStrings[1], nClient.HostThreadID);
                    this.sendListOfGamersToClient(nClient.tcpClient);
                }

                if (header.Equals("##REFRESH##"))
                {
                    this.sendListOfGamersToClient(nClient.tcpClient);
                }

                if (header.Equals("##INVITE##"))
                {
                    this.sendInviteToClient(messageStrings[1], messageStrings[2]);
                }

            }

            nClient.tcpClient.Close();
        
        }

        private void HandleClientComm(NetworkClient nClient)
        {
            //NetworkClient nClient = (NetworkClient)client;
            //TcpClient tcpClient = nClient.tcpClient;

            NetworkStream clientStream = nClient.tcpClient.GetStream();
            byte[] message = new byte[ByteMessageSize];
            int bytesRead;
            string stringToProcess;
            string[] messageStrings;
            string header;
            string body;

            this.ListOfNetworkClient.Add(nClient);

            while (true)
            {
                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, ByteMessageSize);
                    clientStream.Flush();
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                stringToProcess = this.encoder.GetString(message, 0, bytesRead);
                messageStrings = stringToProcess.Split(new string[] { "::" }, System.StringSplitOptions.RemoveEmptyEntries);
                header = messageStrings[0];

                if (header.Equals("##NAME##"))
                {
                    this.addPlayerToList(messageStrings[1], nClient.HostThreadID);
                    this.sendListOfGamersToClient(nClient.tcpClient);
                }

                if (header.Equals("##REFRESH##"))
                {
                    this.sendListOfGamersToClient(nClient.tcpClient);
                }

                if (header.Equals("##INVITE##"))
                {
                    this.sendInviteToClient(messageStrings[1], messageStrings[2]);
                }

            }

            nClient.tcpClient.Close();

        }

        private void addPlayerToList(string name, int hostThreadID)
        {
            Client player = new Client(this.idCount + 1, name, true, this.gameIDCount + 1);
            player.HostThreadID = hostThreadID;
            this.listOfGamers.Add(player);
            Console.WriteLine("Added new player " + player.Name);
        }

        private void sendListOfGamersToClient(TcpClient tcpClient)
        {
            ///Message string format: name::is_free||.
            ///E.g., "Striker::0" means that player Striker isn't free for game.
            ///"||" means goto next string.
            StringBuilder messageString = new StringBuilder();
            foreach (var gamer in this.listOfGamers)
            {
                messageString.Append(gamer.Name);
                messageString.Append("::");
                messageString.Append(gamer.IsFree ? "Free" : "Playing");
                messageString.Append("||");
            }

            NetworkStream clientStream = tcpClient.GetStream();
            byte[] message = this.encoder.GetBytes(messageString.ToString());

            clientStream.Write(message, 0, message.Length);
            Console.WriteLine("List of gamers is sent to client" + tcpClient.Client.Handle.ToString());
        }

        private void sendInviteToClient(string clientNameTo, string clientNameFrom)
        {
            Client client = new Client();

            foreach (var gamer in this.listOfGamers)
            {
                if (gamer.Name.Equals(clientNameTo))
                {
                    client = gamer;
                    break;
                }
            }

            foreach (var networkClient in this.ListOfNetworkClient)
            {
                if (client.HostThreadID == networkClient.HostThreadID)
                {
                    StringBuilder messageString = new StringBuilder();
                    messageString.Append("##INVITE##::");
                    messageString.Append(clientNameFrom);
                    messageString.Append("::");
                    NetworkStream clientStream = networkClient.tcpClient.GetStream();
                    byte[] message = this.encoder.GetBytes(messageString.ToString());

                    clientStream.Write(message, 0, message.Length);
                    Console.WriteLine("The invite from {0} has been sent to {1}", clientNameFrom, clientNameTo);
                    break;
                }
            }
        }

        private void SendMessageToClient(string clientName)
        {
            ///This function is for sending various messages to client, e.g., turns in game.
        }
    }
}
