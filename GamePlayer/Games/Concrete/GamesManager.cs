using GamePlayer.Abstract;
using GamePlayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePlayer.Concrete
{
    public class GamesManager: BaseManager<Games>
    {
        public static int i = 0;
        string ans;
        string id;
        int index;

        public override void Save(int i,List<Games> listgame)
        {
            try
            {
                do
                {
                    Games game = new Games();

                    game.Id = i;

                    Console.WriteLine(" Oyun Kayıt Ekranına Hoşgeldiniz... "  );

                    Console.WriteLine(" Lütfen Oyun Adını Giriniz...");
                    game.GamesName = Console.ReadLine();

                    Console.WriteLine(" Lütfen Oyun Ücretini Giriniz...");
                    game.UnitPrace = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine(" Lütfen Stok Adedini Giriniz...");
                    game.Stock = Convert.ToInt32(Console.ReadLine());

                    listgame.Add(game);
                    base.Save(i,listgame);
                    i++;

                    Console.WriteLine("Başka oyun eklenecek mi...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();

                } while (ans == "E");
               

                Console.WriteLine("OYUN LİSTESİ");
                foreach (var item in listgame)
                {
                    Console.WriteLine(item.Id+"\t\t"+item.GamesName+"\t\t"+item.UnitPrace+"\t\t"+item.Stock);
                }
                Console.WriteLine("");
            }
            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }
        }

        public override void Update(int i, List<Games> listgame)
        {
            try
            {
                do
                {
                    Console.WriteLine(" Güncelleme Ekranına Hoşgeldiniz... ");
                    Console.WriteLine(" Lütfen Oyun Adını Giriniz...");
                    id = Console.ReadLine();

                    for (i = 0; i < listgame.Count; i++)
                    {
                        if (id == listgame[i].GamesName)
                        {
                            index = i;
                        }
                    }

                    Console.WriteLine(" Oyun Adını Giriniz...");
                    listgame[index].GamesName = Console.ReadLine();

                    Console.WriteLine(" Lütfen Fiyatı Giriniz...");
                    listgame[index].UnitPrace = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine(" Lütfen Stok Durumunu Giriniz...");
                    listgame[index].Stock= Convert.ToInt32(Console.ReadLine());
                    base.Update(index, listgame);


                    Console.WriteLine("Başka oyun güncellemesi yapacak mısınız...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();


                } while (ans == "E");

                Console.WriteLine("OYUN LİSTESİ");
                Console.WriteLine("--------------------------------------------------------------------------");
                foreach (var item in listgame)
                {
                    Console.Write("\n" + item.Id + "\t" + item.GamesName + "\t" + item.UnitPrace + "\t" + item.Stock + "\n");
                }
            }
            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }
        }

        public override void Delete(int i, List<Games> listgame)
        {
            try
            {
                do
                {
                    Console.WriteLine(" Silme Ekranına Hoşgeldiniz... ");

                    Console.WriteLine(" Lütfen Oyun Adını giriniz...");
                    id = Console.ReadLine();

                    for (int j = 0; j < listgame.Count; j++)
                    {
                        if (id == listgame[i].GamesName)
                        {
                            index = i;
                        }
                    }

                    listgame.RemoveAt(index);
                    base.Delete(index, listgame);

                    Console.WriteLine("Başka oyuncu silecek misiniz...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();

                } while (ans == "E");

                Console.WriteLine("OYUN LİSTESİ");
                Console.WriteLine("----------------------------------------------");

                foreach (var item in listgame)
                {
                    Console.Write("\n" + item.Id + "\t" + item.GamesName + "\t" + item.UnitPrace + "\t" + item.Stock + "\n");
                }
            }
            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }
        }
    }
}
