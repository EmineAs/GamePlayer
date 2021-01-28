using GamePlayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePlayer.Abstract
{
    public interface IBaseService<T>
    {
        void Save(int i,List<T> list);
        void Update(int i,List<T> list);
        void Delete(int i, List<T> list);
        void BuyGame(int i, List<Players> list, List<Games> listgame, List<Campaign> listcampaign);

    }
}
