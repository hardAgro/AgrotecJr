using Inova.Farm.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Inova.Farm.WebService
{
    public class Service
    {

        public Service()
        {

        }

        public WebClient Client { get; set; }
        
        
        public async Task<Irrigation> CalculateIrrigation(User user, CurrentProduction production)
        {
            HttpClient client = new HttpClient();

            SoilCondition soilCondition = new SoilCondition();
            HttpResponseMessage response = client.GetAsync(new Uri(/*STRING DE URL*/));
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        //faz alguma coisa com esse dado
                    }
                }
            }
            //faz calculo de quantidade q deve ser irrigada

            return null;

        }

    }
}
