using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
/*  2) Vytvoř třídu BankAccount, kterou budeme reprezentovat bankovní účet
 * Přidej třídě BankAccount čtyři proměnné - accountNumber jako číslo účtu
 *                                            - holderName jako jméno osoby, které účet patří
 *                                            - currency jako měna, ve které je účet vedený
 *                                            - balance jako zůstatek na účtu
 * Přidej třídě BankAccount čtyři funkce - Deposit, která jako vstupní parametr přijme množství peněz a vloží je na účet
 *                                          - Withdraw, která jako vstupní parametr přijme množství peněz a z účtu "vybere" peníze, tedy sníží zůstatek a navrátí požadované množství
 * Pokud na účtu není dostatek peněz, uživatele upozorní a vrátí nulu.
 *                                          - Transfer, která jako vstupní parametry přijme množství peněz a číslo účtu, na které se budou peníze posílat, a převede peníze
 * z jednoho účtu na druhý(opět pouze pokud je na účtu, ze kterého převod jde, dostatek peněz)
 * Přidej třídě BankAccount konstruktor, který bude přijímat dva parametry - jméno majitele účtu a měnu, ve které bude účet vedený
 *                                                                            - Při jeho zavolání nastav jméno a měnu podle vstupních parametrů, accountNumber nastav jako náhodně
 * vygenerované číslo velké alespoň 100 000 000 a menší, než 10 000 000 000 a balance nastav na nulu
 */
    internal class BankAccount
    {
        public int accountNumber;
        public string HolderName;
        public string currency;
        public int balance;
        public BankAccount(int accountNumber, string currency, string HolderName, int balance)
        {
            this.accountNumber = accountNumber;
            this.HolderName = HolderName;
            this.currency = currency;
            this.balance = balance;
        }
        public BankAccount() 
        {
            
        }
        public int Deposit(int amount)
        {
            return balance+ amount;
        }
        public int withdraw(int amount)
        {
            if (balance < amount)
            {
                Console.WriteLine($"jsi broked a vybral jsi jen {balance}");
                return 0;
            }
            return balance;
        }
        public int Transfer(int amount, int number)
        {

            BankAccount acc2 = new BankAccount();
            acc2.balance = acc2.balance + amount;
            return balance; 
        }
    }
}
