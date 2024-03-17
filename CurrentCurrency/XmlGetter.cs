using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrentCurrency
{
    public class XmlGetter
    {
        private string apiUrl;

        public XmlGetter()
        {
            apiUrl = $"https://www.cbr.ru/scripts/XML_daily.asp?date_req={DateTime.Today:dd/MM/yyyy}";

        }

        public async Task<string> GetXmlString()
        {
            string xmlString;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                response.Content.Headers.ContentType.CharSet = "UTF-8";

                xmlString = await response.Content.ReadAsStringAsync();
            }
            return xmlString;
        }


    }
}
