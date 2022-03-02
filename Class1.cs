using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;//prideta biblioteka darbui su failais


namespace Bylos
{
    class DarbasSuBylomis
    {
        public int NeededFiles;
        public string MainDirectory;
        

        public DarbasSuBylomis(string a,int b) 
        {
            MainDirectory = a;//Pagrindinio katalogo vardas
            NeededFiles = b;//Reikiamas bylų kiekis
            
        }

        public void BylosKurimas()
        {
            //Pagrindinio katalogo kurimas
            bool IsMainDirectory = FileSystem.DirectoryExists(MainDirectory);//Tikrina ar yra pagrindinis katalogas bylos
            if (IsMainDirectory == false)
            {
                FileSystem.CreateDirectory(MainDirectory);//Sukuria pagrindini kataloga
                Console.WriteLine("Sukurtas Pagrindinis Katalogas " + MainDirectory + "\n");
            }
            else 
                Console.WriteLine("Katalogas " + MainDirectory + " Jau Egzistuoja" + "\n");//Praneša kad jau katalogas bylos sukurtas


            //Bylu kurimas pagrindiniame kataloge
            int temp = NeededFiles;//Laikinas kintamasis bylu kurimui
            while (temp > 0)
            {
                string FileName = "Byla" + temp + ".txt";//Pagrindinis bylos vardas
                bool IsFile = File.Exists(MainDirectory + "/" + FileName);//Ar jau yra tokia pagrindinė byla

                string date = DateTime.Now.ToString("yyyy/MM/dd");//Dabartinės datos gavimas
                string NewFileName = "Byla" + temp + "_" + date + ".txt";//Naujas bylos pavadinimas
                bool IsNewFile = File.Exists(MainDirectory + "/" + NewFileName);//Ar jau yra byla su nauju pavadinimu

                string RandomNumber = new Random().Next(0, 2).ToString();//Random skaičiaus nuo 0 iki 1 generavimas

                if (IsFile == false && IsNewFile == false)//Pagrindinių bylų kurimas 
                {
                    FileSystem.WriteAllText(MainDirectory + "/" + FileName, RandomNumber, false);//Bylos su pagrindiniu vardu sukurimas ir random skaicio yrasymas
                    Console.WriteLine("Sukurta byla: " + FileName);
                }
                else if (IsNewFile == false)//Bylų su nauju pavadinimu kurimas
                {
                    FileSystem.RenameFile(MainDirectory + "/" + FileName, NewFileName);//Bylos pervadinimas y nauja pavadinima
                    Console.WriteLine(FileName + " jau egzituoja ir ji pervadyta į: " + NewFileName);
                }
                else if (IsNewFile == true)//Ar jau yra bylu su nauju pavadinimu
                {
                    Console.WriteLine(NewFileName + " jau egzituoja");
                }

                temp--;
            }
        }

        public void Ataskaita(string c,string d) 
        {
            string ReportDirectory = c;
            string ReportName = d + ".txt";
            int HasZero=0;
            int HasOne=0;

            //Ataskaitos katalogo kūrimas
            bool IsReportDirectory= FileSystem.DirectoryExists(MainDirectory + "/" + ReportDirectory);
            if (IsReportDirectory == false)
            {
                FileSystem.CreateDirectory(MainDirectory + "/" + ReportDirectory);
                Console.WriteLine("\nKataloge " + MainDirectory + " Sukurtas Ataskaitos Katalogas " + ReportDirectory + "\n");
            }else
            {
                Console.WriteLine("\nKataloge " + MainDirectory + " Jau Yra Katalogas " + ReportDirectory + "\n");
            }

            //Failu turinčiu 0 ir 1 skaičiavimas
            foreach (string byla in FileSystem.GetFiles(MainDirectory + "/")) 
            {
                string CurrentFile = File.ReadAllText(byla);
                if (CurrentFile == "0")
                    HasZero++;
                else if (CurrentFile == "1")
                    HasOne++;
            }
            
            //Ataskaitos bylos kūrimas
            FileSystem.WriteAllText(MainDirectory + "/" + ReportDirectory + "/" + ReportName, "Failu turinčių nulį: " + HasZero + "\nFailų turinčių vienetą: " + HasOne, false);
            Console.WriteLine("Sukurtas ataskaitos failas pavadinimu " + ReportName);
        }

        public void Trynimas() 
        {
            foreach (string byla in FileSystem.GetFiles(MainDirectory + "/"))
            {
                string CurrentFile = File.ReadAllText(byla);
                if (CurrentFile == "0")
                    FileSystem.DeleteFile(byla);    
            }

            Console.WriteLine("\nIštrintos bylos turinčios įrašą: '0'");
        }
    }
}
