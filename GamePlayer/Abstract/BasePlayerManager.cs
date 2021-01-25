using GamePlayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePlayer.Abstract
{
    public abstract class BasePlayerManager : IPlayerService
    {
        public virtual void Sigin(int i,List<Players> list)
        {
            Console.WriteLine("Saved to DB Player " + list[i].FirtsName);
        }

    }
}
