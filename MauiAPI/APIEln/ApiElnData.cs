using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAPI.APIEln
{
    public class ApiElnData
    {
        private readonly HttpClient _client;
        private readonly string _baseAddress = 
        "https://sgestorweb.eletronorte.com.br/engenharia/segtrabalho/api/";
        //extintoralmoxarifados
        public ApiElnData()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseAddress);
        }
    }
}
