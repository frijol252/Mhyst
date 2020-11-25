using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Script.Configuration
{
    public class FightParameters
    {
        public static bool PlayerTurn { get; set; }

        public static List<string> Lista { get { return lista; } }
        private static List<string> lista = new List<string>
        {
            "Desde el profundo de mi ser, llamo mi voluntad, expandete, escúchame y cae.",
            "Toma mi fuerza en su estado mas puro y evapora el camino de mis enemigos.",
            "Entre volcanes y sierras, entrego mi pasión ardiendo por dentro como el sol."
        };
    }
}
