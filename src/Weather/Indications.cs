using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public class Indications
    {
        public double temperature { get; set; } //температура - число
        public string windDirection { get; set; } // направление вветра - строка
        public double windSpeed { get; set; } // скорость ветра - число
    }
}