using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GisMeteoParser
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Update(string name)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }
        string weather;
        string sity;

        public string Sity
        {
            get { return sity; }
            set
            {
                sity = value;
                Update("Sity");
            }
        }

        public myCommand ButtonClick
        {
            get {return  new myCommand(refresh); }
        }
        void refresh(object parametr)
        {
           // MessageBox.Show(parametr.ToString());
            Weather = ParserModel.GetWeather(sity);
        }

        public string Weather
        {
            get { return weather; }
            set { 
                weather = value;
                Update("Weather");
            }
        }
    }
}
