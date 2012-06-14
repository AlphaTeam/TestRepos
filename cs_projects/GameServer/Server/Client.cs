using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public class Client
    {
        public Client()
        {

        }

        public Client(int id, string name, bool isFree, int gameID)
        {
            this.ID = id;
            this.Name = name;
            this.IsFree = isFree;
            this.GameID = gameID;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsFree { get; set; }
        public int GameID { get; set; }
        public int HostThreadID { get; set; }
    }
}
