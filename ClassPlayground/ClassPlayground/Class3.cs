using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/*3) Vytvoř třídu Student, kterou budeme reprezentovat studenta
 *    Přidej třídě Student proměnné - year pro aktuální ročník studenta
 *                                  - id pro identifikační číslo studenta
 *                                  - subjects pro seznam předmětů studenta (bude to slovník (https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/), který bude mít jako klíč string a jako hodnotu List (https://www.geeksforgeeks.org/c-sharp-list-class/) známek)
 *                                  - name pro jméno studenta
 *    Přidej třídě Student čtyři funkce - AddSubject, která jako vstupní parametr přijme název předmětu a přidá nový klíč do subjects
 *                                      - AddGrade, která jako vstupní parametr přijme název předmětu a známku a přidá podle názvu předmětu další známku danému předmětu
 *                                      - CalculateSubjectGrade, která jako stupní parametr přijme název předmětu a spočítá průměrnou známku na vysvědčení z daného předmětu
 *                                      - CaculateTotalGrade, která spočítá studijní průměr (průměr všech známek)
 *Přidej třídě Student konstruktor, který bude přijímat dva parametry - jméno a ročník studenta
 *                                      - Při jeho zavolání nastav jméno a ročník podle vstupních parametrů, id vygeneruj podobně, jako accountNumber
                                                                ve tříde BankAccount, a subjects nastav na nový prázdný List */
namespace ClassPlayground
{
    internal class Student
    {
        public int year;
        public int id;
        public string name;
        public Dictionary<string, List<int>> subjects;

    }
}
