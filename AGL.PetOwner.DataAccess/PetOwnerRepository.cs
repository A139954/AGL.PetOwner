using AGL.PetOwner.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Configuration;
using AGL.PetOwner.Utilities.Constant;
using System.Net;
using AGL.PetOwner.Utilities;

namespace AGL.PetOwner.DataAccess
{
    public class PetOwnerRepository : IPetOwnerRepository
    {
        public IEnumerable<Owner> GetPetOwnerDetails()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.Accept.ToString(), "application/json");
                    var response = httpClient.GetStringAsync(new Uri(ConfigurationManager.AppSettings[Constant.ApiUrl])).Result;
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    return JsonConvert.DeserializeObject<List<Owner>>(response, settings);
                }
            }
            catch (Exception ex)
            {
                Logger.HandleException(ex);
                throw;
            }
        }
    }
} 
