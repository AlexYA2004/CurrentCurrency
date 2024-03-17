using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CurrentCurrency
{
    public class CurrencyHandler
    {
        private XmlGetter _getter;

        private XmlDocument xmlDoc;

        private string _charCode;

        public CurrencyHandler(string charCode)
        {
            _getter = new XmlGetter();

            xmlDoc = new XmlDocument();

            _charCode = charCode;
        }


        public async Task<ValuteModel> GetValuteAsync() 
        {
            var xmlString = await _getter.GetXmlString();

            xmlDoc.LoadXml(xmlString);

            var result = xmlDoc.SelectSingleNode($"//Valute[CharCode='{_charCode}']");

            if (result != null)
            {
                var valute = new ValuteModel()
                {
                    ID = result.SelectSingleNode("ID")?.InnerText,

                    NumCode = int.Parse(result.SelectSingleNode("NumCode")?.InnerText),

                    Name = result.SelectSingleNode("Name")?.InnerText,

                    CharCode = result.SelectSingleNode("CharCode")?.InnerText,

                    Nominal = int.Parse(result.SelectSingleNode("Nominal")?.InnerText),

                    Value = decimal.Parse(result.SelectSingleNode("Value")?.InnerText),

                    VunitRate = decimal.Parse(result.SelectSingleNode("VunitRate")?.InnerText)
                };

                return valute;
            }
            else
            {
                throw new Exception($"Валюта с кодом {_charCode} не найдена.");
            }

          
        }
    }
}
