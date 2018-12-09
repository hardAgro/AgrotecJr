using Inova.Farm.SistemaInterfaceWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Inova.Farm.SistemaInterfaceWeb.Services
{
    public class ServiceIrrigation
    {
        public async Task<int> CalculateIrrigation(User user, CurrentProduction production)
        {
            HttpClient client = new HttpClient();
            //Irrigation irrigation = new Irrigation();
            int valorMedido = 0;
            HttpResponseMessage response = new HttpResponseMessage();
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        valorMedido = Convert.ToInt32(reader.ReadLine());
                    }
                }
            }
            return valorMedido;

        }

    }
}