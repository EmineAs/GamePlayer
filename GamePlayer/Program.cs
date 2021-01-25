using System;
using GamePlayer.Abstract;
using GamePlayer.Entities;
using GamePlayer.Adepter;
using GamePlayer.Concrete;
using System.Collections.Generic;

namespace GamePlayer
{
    class Program
    {
        public static int i = 0;

        static void Main(string[] args)
        {

            BasePlayerManager playerManager = new PlayerManager(new MernisServiceAdapter());
            List<Players> list = new List<Players>();
            playerManager.Sigin(i,list);

            Console.ReadLine();
        }
    }
}
