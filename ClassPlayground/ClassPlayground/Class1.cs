using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
/*   
 * 1) Vytvoř třídu Rectangle, kterou budeme reprezentovat obecný obdélník
 * Přidej třídě Rectangle dvě proměnné - width a height(datový typ nechám na tobě)
 *    Přidej třídě Rectangle tři funkce - CalculateArea, která spočítá obsah plochy obdélníka
 *                                      - CalculateAspectRatio, která spočítá poměr stran.Využij spočítaný poměr k určení toho, jestli je obdélník široký, vysoký, nebo je to čtverec
 *                                      - ContainsPoint, která jako vstupní parametr přijme souřadnice x, y nějakého bodu a určí, jestli se daný bod nachází v obdélníku, nebo ne,
 *    a podle toho vrátí true/false
 *    Přidej třídě Rectangle konstruktor, který bude přijímat dva parametry - šířku a výšku, a při jeho zavolání je správně nastaví
 *
 * 1) BONUS - Až vytvoříš Rectangle, zkus vytvořit obdobnou třídu se stejnou funkcionalitou pro kruh nebo třeba trojúhelník. 
 */

namespace ClassPlayground
{
    internal class Rectangle
    {
        public double width, height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double CalculateArea()
        {
            double area = width * height;
            return area;
        }
        public string CalculateAspectRatio()
        {
            double width2 = width;
            double height2 = height;
            string verdict = "";
            if (width % height == 0)
            {
                width2 = width / height;
                height2 = height / height;
            }
            
            else if (height % width == 0)
            {

                height2 = height / width;
                width2 = width / width;
            }   
            string ratio = $"{width2}:{height2}";
            if (width > height)
            {
                verdict = "široký ";
            }
            else if (width < height)
            {
                verdict = "vyskoý ";
            }
            else
            {
                verdict = "čtverec ";
            }
            verdict = verdict + "a poměr je: " + ratio;
            return verdict;
        }
        public bool ContainsPoint(double x, double y)
        {
            bool verdict = false;
            if (x <= width && y <= height)
            {
                verdict = true;
            }    
            return verdict;
        }
    }
}
