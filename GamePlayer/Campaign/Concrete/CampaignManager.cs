using GamePlayer.Abstract;
using GamePlayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePlayer.Concrete
{
    public class CampaignManager: BaseManager<Campaign>
    {
        public static int i = 0;
        string ans;
        string id;
        int index;

        public override void Save(int i,List<Campaign> listcampaign)
        {
            try
            {
                do
                {
                    Campaign campaign = new Campaign();

                    campaign.Id = i;

                    Console.WriteLine(" Kampanya Kayıt Ekranına Hoşgeldiniz... "  );

                    Console.WriteLine(" Lütfen Kampanya Adını Giriniz...");
                    campaign.CampaignName = Console.ReadLine();

                    listcampaign.Add(campaign);
                    base.Save(i, listcampaign);
                    i++;


                    Console.WriteLine("Başka kampanya eklenecek mi...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();


                } while (ans == "E");
               

                Console.WriteLine("KAMPANYA LİSTESİ");
                foreach (var item in listcampaign)
                {
                    Console.WriteLine(item.Id+"\t\t"+item.CampaignName);
                }

                Console.WriteLine("");
            }
            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }
        }

        public override void Update(int i, List<Campaign> listcampaign)
        {
            try
            {
                do
                {
                    Console.WriteLine(" Güncelleme Ekranına Hoşgeldiniz... ");
                    Console.WriteLine(" Lütfen Oyun Adını Giriniz...");
                    id = Console.ReadLine();

                    for (i = 0; i < listcampaign.Count; i++)
                    {
                        if (id == listcampaign[i].CampaignName)
                        {
                            index = i;
                        }
                    }

                    Console.WriteLine(" Yeni Kampanya Adını Giriniz...");
                    listcampaign[index].CampaignName = Console.ReadLine();

                    base.Update(index, listcampaign);


                    Console.WriteLine("Başka kampanya güncellemesi yapacak mısınız...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();


                } while (ans == "E");


                Console.WriteLine("KAMPANYA LİSTESİ");
                Console.WriteLine("--------------------------------------------------------------------------");
                foreach (var item in listcampaign)
                {
                    Console.WriteLine(item.Id + "\t\t" + item.CampaignName);
                }
            }
            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }
        }

        public override void Delete(int i, List<Campaign> listcampaign)
        {
            try
            {
                do
                {
                    Console.WriteLine(" Silme Ekranına Hoşgeldiniz... ");

                    Console.WriteLine(" Lütfen kampanya Adını giriniz...");
                    id = Console.ReadLine();

                    for (int j = 0; j < listcampaign.Count; j++)
                    {
                        if (id == listcampaign[i].CampaignName)
                        {
                            index = i;
                        }
                    }

                    listcampaign.RemoveAt(index);
                    base.Delete(index, listcampaign);

                    Console.WriteLine("Başka kampanya silecek misiniz...(Evet=E  Hayır=H)");
                    ans = Console.ReadLine();

                } while (ans == "E");

                Console.WriteLine("KAMPANYA LİSTESİ");
                Console.WriteLine("----------------------------------------------");

                foreach (var item in listcampaign)
                {
                    Console.Write("\n" + item.Id + "\t" + item.CampaignName+ "\n");
                }
            }
            catch (Exception hata)
            {
                Console.WriteLine(hata);
            }
        }
    }
}
