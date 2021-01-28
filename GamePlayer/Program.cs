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
            BaseManager<Players> playerManager = new PlayerManager(new MernisServiceAdapter());
            List<Players> list = new List<Players>();

            BaseManager<Games> gameManager = new GamesManager();
            List<Games> listgame = new List<Games>();

            BaseManager<Campaign> campaignManager = new CampaignManager();
            List<Campaign> listcampaign = new List<Campaign>();

            MainMenu();

            void MainMenu()
            {
                Console.WriteLine("*********ANA MENÜ*********");
                Console.WriteLine("*                        *");
                Console.WriteLine("* 1- Oyuncu İşlemleri    *");
                Console.WriteLine("* 2- Oyun İşlemleri      *");
                Console.WriteLine("* 3- Kampanya İşlemleri  *");
                Console.WriteLine("* 4- Satış İşlemleri     *");
                Console.WriteLine("* 5- Çıkış               *");
                Console.WriteLine("*                        *");
                Console.WriteLine("**************************");

                Console.WriteLine("\nLütfen Yapmak İstediğiniz İşlemi Seçiniz");
                int ans = Convert.ToInt32(Console.ReadLine());

                switch (ans) 
                {
                    case 1:
                        PlayerMenu(playerManager, list);
                        break;
                    case 2:
                        GameMenu(gameManager,listgame);
                        break;
                    case 3:
                        CampaignMenu(campaignManager, listcampaign);
                        break;
                    case 4:
                        playerManager.BuyGame(i,list,listgame,listcampaign);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
           
            }

            void PlayerMenu(BaseManager<Players> obj, List<Players> list)
            {
                int ans;
                do
                {
                    Console.WriteLine("*******OYUNCU İŞLEMLERİ********");
                    Console.WriteLine("*                             *");
                    Console.WriteLine("* 1- Oyuncu Ekle              *");
                    Console.WriteLine("* 2- Oyuncu Bilgileri Güncelle*");
                    Console.WriteLine("* 3- Oyuncu Sil               *");
                    Console.WriteLine("* 4- Ana Menüye Dön           *");
                    Console.WriteLine("*                             *");
                    Console.WriteLine("*******************************");

                    Console.WriteLine("\nLütfen Yapmak İstediğiniz İşlemi Seçiniz");
                    ans = Convert.ToInt32(Console.ReadLine());
                    
                    switch (ans)
                    {
                        case 1:
                            playerManager.Save(i, list);
                            break;

                        case 2:
                            playerManager.Update(i, list);
                            break;

                        case 3:
                            playerManager.Delete(i, list);
                            break;

                        case 4:
                            MainMenu();
                            break;
                    }  
                    
                } while (ans != 4);
            }

            void GameMenu(BaseManager<Games> gameManager, List<Games> listgame)
            {
                int ans;
                do
                {
                    Console.WriteLine("*******OYUNCU İŞLEMLERİ********");
                    Console.WriteLine("*                             *");
                    Console.WriteLine("* 1- Oyun Ekle                *");
                    Console.WriteLine("* 2- Oyun Bilgileri Güncelle  *");
                    Console.WriteLine("* 3- Oyun Sil                 *");
                    Console.WriteLine("* 4- Ana Menüye Dön           *");
                    Console.WriteLine("*                             *");
                    Console.WriteLine("*******************************");

                    Console.WriteLine("\nLütfen Yapmak İstediğiniz İşlemi Seçiniz");
                    ans = Convert.ToInt32(Console.ReadLine());

                    switch (ans)
                    {
                        case 1:
                            gameManager.Save(i, listgame);
                            break;

                        case 2:
                            gameManager.Update(i, listgame);
                            break;

                        case 3:
                            gameManager.Delete(i, listgame);
                            break;

                        case 4:
                            MainMenu();
                            break;
                    }

                } while (ans != 4);
            }

            void CampaignMenu(BaseManager<Campaign> campaignManager, List<Campaign> listcampaign)
            {
                int ans;
                do
                {
                    Console.WriteLine("********KAMPANYA İŞLEMLERİ*********");
                    Console.WriteLine("*                                 *");
                    Console.WriteLine("* 1- Kampanya Ekle                *");
                    Console.WriteLine("* 2- Kampanya Bilgileri Güncelle  *");
                    Console.WriteLine("* 3- Kampanya Sil                 *");
                    Console.WriteLine("* 4- Ana Menüye Dön               *");
                    Console.WriteLine("*                                 *");
                    Console.WriteLine("***********************************");
                    Console.WriteLine("\nLütfen Yapmak İstediğiniz İşlemi Seçiniz");
                    ans = Convert.ToInt32(Console.ReadLine());

                    switch (ans)
                    {
                        case 1:
                            campaignManager.Save(i, listcampaign);
                            break;

                        case 2:
                            campaignManager.Update(i, listcampaign);
                            break;

                        case 3:
                            campaignManager.Delete(i, listcampaign);
                            break;

                        case 4:
                            MainMenu();
                            break;
                    }

                } while (ans != 4);
            }


        }
    }
}
