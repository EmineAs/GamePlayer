using GamePlayer.Abstract;
using GamePlayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePlayer.Concrete
{
    public class PlayerManager: BaseManager<Players>
    {     
        private IPlayerCheckService _playerCheckService;
        public static int i = 0;
        string ans;
        string nid;
        int index;
        int id2;

        public PlayerManager(IPlayerCheckService playerCheckService)
        {
            _playerCheckService = playerCheckService;
        }
        public override void Save(int i,List<Players> list)
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
                        base.Save(i,list);
                        i++;

                    }
                    else
                    {
                    throw new Exception("Not a valid Person");
                    }

                    Console.WriteLine("Başka oyuncu kayıt olacak mı...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();
                } while (ans == "E");
                

                Console.Write("ID\tTCKİMLİKNO\tADI\tSOYADI\tDOĞUM TARİHİ\n");
                Console.WriteLine("--------------------------------------------------------------------");

                foreach (var item in list)
                {
                    Console.Write("\n" + item.Id + "\t" + item.NationalityId + "\t" + item.FirtsName + "\t" + item.LastName + "\t" + item.DateofBirth + "\n");
                }
            }
            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }

        }

        public override void Update(int i, List<Players> list)
        {
            try
            {
                do
                {       
                    Console.WriteLine(" Güncelleme Ekranına Hoşgeldiniz... ");
                    Console.WriteLine(" Lütfen TC.Kimlik No giriniz...");
                    nid = Console.ReadLine();

                    for (i = 0; i < list.Count; i++)
                    {
                        if (nid == list[i].NationalityId)
                        {
                            index=i;
                        }
                    }

                    Console.WriteLine(" Lütfen Adınızı Giriniz...");
                    list[index].FirtsName = Console.ReadLine();

                    Console.WriteLine(" Lütfen Soyadınızı Giriniz...");
                    list[index].LastName = Console.ReadLine();

                    Console.WriteLine(" Lütfen Doğum Tarihinizi aralarda virgül olacak şekilde yıl ay gün şeklinde giriniz...");
                    list[index].DateofBirth = Convert.ToDateTime(Console.ReadLine());
                    base.Update(index, list);


                    Console.WriteLine("Başka oyuncu güncellemesi yapacak mısınız...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();


                } while (ans == "E");

                Console.Write("ID\tTCKİMLİKNO\tADI\tSOYADI\tDOĞUM TARİHİ\n");
                Console.WriteLine("--------------------------------------------------------------------------");

                foreach (var item in list)
                {
                    Console.Write("\n" + item.Id + "\t" + item.NationalityId + "\t" + item.FirtsName + "\t" + item.LastName + "\t" + item.DateofBirth + "\n");
                }
            }

            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }
        }

        public override void Delete(int i, List<Players> list)
        {
            try
            {
                do
                {
                    Console.WriteLine(" Silme Ekranına Hoşgeldiniz... ");

                    Console.WriteLine(" Lütfen TC.Kimlik No giriniz...");
                    nid = Console.ReadLine();

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (nid == list[i].NationalityId)
                        {
                            index = i;
                        }
                    }

                    list.RemoveAt(index);
                    base.Delete(index, list);

                    Console.WriteLine("Başka oyuncu silecek misiniz...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();

                } while (ans == "E");

                Console.Write("ID\tTCKİMLİKNO\tADI\tSOYADI\tDOĞUM TARİHİ\n");
                Console.WriteLine("----------------------------------------------");

                foreach (var item in list)
                {
                    Console.Write("\n" + item.Id + "\t" + item.NationalityId + "\t" + item.FirtsName + "\t" + item.LastName + "\t" + item.DateofBirth + "\n");
                }
            }

            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }
        }

        public override void BuyGame(int i, List<Players> list, List<Games> listgame, List<Campaign> listcampaign)
        {
            string a;
            index=-1;

            try
            {
                do
                {
                    Console.WriteLine(" Satış Ekranına Hoşgeldiniz... ");
                    Console.WriteLine(" Oyun Satın Almak için önce giriş yapmalısınız... ");

                    Console.WriteLine(" Lütfen TC.Kimlik No giriniz...");
                    nid = Console.ReadLine();

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (nid == list[j].NationalityId)
                        {
                            index = j;
                        }
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("Üye Kaydınız Bulunmamaktadır Lütfen Kayıt Olunuz...");
                        Save(i, list);
                    }


                    Console.WriteLine("Hoşgeldiniz Oyuncu "+list[i].FirtsName);

                    Console.WriteLine("OYUN LİSTESİ");
                    foreach (var item in listgame)
                    {
                        Console.WriteLine(item.Id + "\t\t" + item.GamesName + "\t\t" + item.UnitPrace + "\t\t" + item.Stock);
                    }
                    Console.WriteLine("");

                    Console.WriteLine("Almak istediğiniz Oyunun id numarasını giriniz");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Kampanyada yararlanmak ister misiniz.. (EVET = E  HAYIR=H)");
                    a = Console.ReadLine();

                    if (a == "E") 
                    {
                        Console.WriteLine("KAMPANYA LİSTESİ");
                        Console.WriteLine("----------------------------------------------");

                        foreach (var item in listcampaign)
                        {
                            Console.Write("\n" + item.Id + "\t" + item.CampaignName + "\n");
                        }

                        Console.WriteLine("Yararlanmak istediğiniz kampanyanın id numarasını giriniz...");
                        id2 = Convert.ToInt32( Console.ReadLine());
                    }

                    Console.WriteLine("Oyuncu "+list[index].FirtsName+" "+listgame[id].GamesName+" oyununu "+listcampaign[id2].CampaignName+" kampanyasından yararlanarak aldınız");
                    Console.WriteLine("Başka oyun almak ister misiniz? (EVET=E  HAYIR=H");
                    ans = Console.ReadLine();

                } while (ans == "E");

               
            }

            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }
        }
    }
}
