using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormGameClient
{
    class ClientEvents
    {
        public delegate void ClientCallHandler();

        public event ClientCallHandler clientCallHandler;

    }
}
