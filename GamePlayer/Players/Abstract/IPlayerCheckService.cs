using GamePlayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePlayer.Abstract
{
    public interface IPlayerCheckService
    {
        bool CheckIfRealPerson(Players player);

    }
}
