using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {

        static void Main(string[] args)
        {
<<<<<<< HEAD

            double doubleX = 0.0;
            double doubleY = 0.0;
            string x = "";
            string y = "";
            string odpoved = "";
            int pocitadlo = 0;
            double vysledek = 0.0;

            while (true)
            {
                string vyssledek = Convert.ToString(vysledek);
                pocitadlo++;
                while (true)
                {
                    if (pocitadlo == 1)
                    {
                        Console.WriteLine("Zadejte první číslo");
                        x = Console.ReadLine();
                    }
                    else
                    {
                        x = vyssledek;
                    }
                    Console.WriteLine("první číslo: " + x);
                    Console.WriteLine("Zadejte druhé číslo");
                    y = Console.ReadLine();
                    Console.WriteLine("druhé číslo: " + y);
                    if (double.TryParse(x, out doubleX) && double.TryParse(y, out doubleY))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("zadána nečíslená hodnota lol");
                    }

                }
                double.Parse(x);
                double.Parse(y);

                Console.WriteLine("zadejte operátor");
                string operátor = Console.ReadLine();
                switch (operátor)
                {

                    case "+":
                        vysledek = doubleX + doubleY;
                        break;

                    case "-":
                        vysledek = doubleX - doubleY;
                        break;
                    case "*":
                        vysledek = doubleX * doubleY;
                        break;
                    case "/":
                        vysledek = (doubleX / doubleY);
                        break;
                }
                Console.WriteLine("vysledek: " + vysledek);

                Console.WriteLine("chcete dále počítat? ano/ne ");
                odpoved = Console.ReadLine();
                if (odpoved == "ne")
                {
                    break;
                }



                Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.

            }
=======
            /*
             * Pokud se budes chtit na neco zeptat a zrovna budu pomahat jinde, zkus se zeptat ChatGPT ;) - https://chat.openai.com/
             * 
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Mozna rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */

            //Tento komentar smaz a misto nej zacni psat svuj prdacky kod.


            Console.WriteLine("Zadejte první číslo");
            string x = Console.ReadLine();
            Console.WriteLine("první číslo: " + x);
            Console.WriteLine("Zadejte druhé číslo");
            string y = Console.ReadLine();
            Console.WriteLine("druhé číslo: " + y);
            int int_x = 0;
            int int_y = 0;
            if(int.TryParse(x, out int_x) && int.TryParse(y, out int_y))
            {
                Int32.Parse(x);
                Int32.Parse(y);
                int vysledek = 0;
                Console.WriteLine("zadejte operátor +/-");
                string operátor = Console.ReadLine();
                if (operátor == "+")
                {
                    vysledek = int_x + int_y;
                }
                
                else if(operátor == "-")
                {
                    vysledek = int_x - int_y;
                }
                
                
                else
                {
                    Console.WriteLine("zadejte + nebo -");
                }
                Console.WriteLine(vysledek);
            }
            else
            {
                Console.WriteLine("zadána nečíslená hodnota lol");
            }
           
            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
>>>>>>> fd207a3a56e60576b6b324293d51150dacac871a
        }
    }
}
