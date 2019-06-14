using ArkhamAsylum.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkhamAsylum.Lib.Services.CountryConnectors
{
    public class FranceConnector //: IGovernmentConnector
    {
        public string GetFullName(string nationalId)
        {
            return "este usuario lo hubiéramos pedido a http://www.france.fr";
        }
    }
}
