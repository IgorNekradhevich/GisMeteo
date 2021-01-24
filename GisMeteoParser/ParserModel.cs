using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GisMeteoParser
{
    class ParserModel
    {
      
     static  public string GetWeather(string sity)
        {
            WebRequest request = WebRequest.Create("https://www.gismeteo.ru/search/"+sity);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string site = reader.ReadToEnd();


            int index = site.IndexOf("Населённые пункты");
            site = site.Remove(0, index );

            index = site.IndexOf("href");
            site = site.Remove(0,index+6);


            index = site.IndexOf("\"");
            site = site.Remove(index );

             request = WebRequest.Create("https://www.gismeteo.ru" + site+"now/");
             response = request.GetResponse();
             stream = response.GetResponseStream();
             reader = new StreamReader(stream);
             site = reader.ReadToEnd();


            index = site.IndexOf("class=\"nowvalue");
            site = site.Remove(0,index);
            return site;
        }
    }
}
