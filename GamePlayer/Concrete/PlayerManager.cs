using GamePlayer.Abstract;
using GamePlayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePlayer.Concrete
{

    public class PlayerManager: BasePlayerManager
    {
       
        private IPlayerCheckService _playerCheckService;

        string ans;
        int id;
        int index;

     

        public PlayerManager(IPlayerCheckService playerCheckService)
        {
            _playerCheckService = playerCheckService;
        }
        public override void Sigin(int i,List<Players> list)
        {
            try
            {

                do
                {

                    Players player = new Players();

                    player.Id = i;

                    Console.WriteLine(" Kayıt Ekranına Hoşgeldiniz... "  );

                    Console.WriteLine(" Lütfen TC.Kimlik No giriniz...");
                    player.NationalityId = Console.ReadLine();

                    Console.WriteLine(" Lütfen Adınızı Giriniz...");
                    player.FirtsName = Console.ReadLine();

                    Console.WriteLine(" Lütfen Soyadınızı Giriniz...");
                    player.LastName = Console.ReadLine();

                    Console.WriteLine(" Lütfen Doğum Tarihinizi aralarda virgül olacak şekilde yıl ay gün şeklinde giriniz...");
                    player.DateofBirth = Convert.ToDateTime(Console.ReadLine());
 
                    if (_playerCheckService.CheckIfRealPerson(player))
                    {
                        list.Add(player);
                        base.Sigin(i,list);
                    }
                    else
                    {
                    throw new Exception("Not a valid Person");
                    }

                    Console.WriteLine("Başka oyuncu kayıt olacak mı...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();

                } while (ans == "E");

                i++;

            }

            catch (Exception hata)
            {
                Console.WriteLine(hata);

            }


        }

    }
}
