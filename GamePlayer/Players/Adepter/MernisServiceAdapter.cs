using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GamePlayer.Abstract;
using GamePlayer.Entities;
using MernisServiceReference;

namespace GamePlayer.Adepter
{
    public class MernisServiceAdapter:IPlayerCheckService
    {
        public bool CheckIfRealPerson(Players player)
        {
            return TaskAsync(player).Result;

        }
        public static async Task<bool> TaskAsync(Players player)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
            var st = await (client.TCKimlikNoDogrulaAsync(Convert.ToInt64(player.NationalityId), player.FirtsName, player.LastName, player.DateofBirth.Year));
            return st.Body.TCKimlikNoDogrulaResult;

        }
    }
}
