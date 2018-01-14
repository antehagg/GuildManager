using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Data.GameData.Items;
using RestSharp;

namespace GuildManager.Editor.ApiCalls
{
    public class WeaponApiCall : BaseApiCall
    {
        private RestRequest _request;
        public DbWeapon GetWeapon(int id)
        {
            _request = new RestRequest("api/Weapons/{id}", Method.GET);
            _request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = Client.Execute<DbWeapon>(_request);
            return response.Data;
        }
    }
}
