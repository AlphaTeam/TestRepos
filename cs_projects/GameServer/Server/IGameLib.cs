using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    /// <summary>
    /// This interface describes methods to implement
    /// for any game library
    /// </summary>
    interface IGameLib
    {
        string GetMessage();
        void SetMessage(string message);
    }
}
