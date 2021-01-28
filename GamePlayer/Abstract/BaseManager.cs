using GamePlayer.Concrete;
using GamePlayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePlayer.Abstract
{
    public abstract class BaseManager<T> : IBaseService<T>
    {               
        public virtual void Save(int i,List<T> list)
        {
            Console.WriteLine("Saved to DB ");

        }

        public virtual void Update(int i, List<T> list) 
        {
            Console.WriteLine("Updated to DB " );

        }

        public virtual void Delete(int i, List<T> list)
        {
            Console.WriteLine("Deleted to DB ");

        }

        public virtual void BuyGame(int i, List<Players> list, List<Games> listgame, List<Campaign> listcampaign)
        {
            Console.WriteLine("Success... ");

        }

    }
}
