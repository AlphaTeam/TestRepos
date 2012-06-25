using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Server
{
    class GameDatabase
    {
        private List<Game> listOfGames = new List<Game>();

        private List<string> makeUpListOfGames()
        {
            this.listOfGames.Clear();
            // папка с плагинами
            string folderServer = @"Games\ForServer";
            string folderClient = @"Games\ForClient";
            // dll-файлы в этой папке
            string[] files = Directory.GetFiles(folderServer, "*.dll");
            List<string> gameNames = new List<string>();

            foreach (string file in files)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    Game game = new Game();
                    game.GameLib = file;
                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("IGameLib");

                        if (iface != null)
                        {
                            IGameLib plugin = (IGameLib)Activator.CreateInstance(type);
                            game.NameOfGame = (string)plugin.GetType().InvokeMember("nameOfGame", BindingFlags.GetField, null, plugin, new Object[] { });
                            this.listOfGames.Add(game);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            files = Directory.GetFiles(folderClient, "*.dll");

            foreach (var game in this.listOfGames)
            {
                foreach (string file in files)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(file);
                        foreach (Type type in assembly.GetTypes())
                        {
                            Type iface = type.GetInterface("IGameClient");

                            if (iface != null)
                            {
                                IGameLib plugin = (IGameLib)Activator.CreateInstance(type);
                                string name = (string)plugin.GetType().InvokeMember("nameOfGame", BindingFlags.GetField, null, plugin, new Object[] { });

                                if(name.Equals(game.NameOfGame))
                                {
                                    game.GameClient = file;
                                    gameNames.Add(name);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return gameNames;
        }

    }
}
