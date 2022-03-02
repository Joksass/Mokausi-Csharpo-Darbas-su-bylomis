using System;

namespace Bylos // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DarbasSuBylomis obj = new DarbasSuBylomis("Failai",5);//Nurodomas bylų pagrindinio katalogo vardas ir reikiamas bylų kiekis
            obj.BylosKurimas();
            obj.Ataskaita("Ataskaita", "Report");//Nurodomas ataskaitos bylos pavadinimas ir katalogas kuriame ji bus pavadinimas
            obj.Trynimas();
            Console.ReadLine();
        }
    }
}