using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat.Accountspace;
using Bankomat.Bancspace;
using Bankomat.Clientspace;

namespace Bankomat
{
    namespace Bancspace
    {
        class Banc
        {
            public Bankomat.Clientspace.Client objClient;

            public object firstName { get; private set; }

            public string Print()
            {
                return
                    $"Клиент:  {objClient.firstName} {objClient.lastName}\nНомер счета: {objClient.objAccount.accountNumber}\nСумма на счете: {objClient.objAccount.amount}";
            }



        }  
    }

    namespace Clientspace
    {
        class Client
        {
            public Bankomat.Accountspace.Account objAccount;
            public string firstName { get; set; } = "default";
            public string lastName { get; set; } = "default";

        }
    }

    namespace Accountspace
    {
        class Account
        {
            public uint accountNumber { get; set; } = 0;
            public uint pass { get; set; } = 0;
            public int amount { get; set; } = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            var clientBanc = new Banc();
            clientBanc.objClient = new Client();
            clientBanc.objClient.objAccount = new Account();

            bool go_on = true;
            while (go_on)
            {
                Console.Clear();
                Console.WriteLine("\tВыберите пункт меню");
                Console.WriteLine("*******************************");
                Console.WriteLine("1 - Вывод баланса на экран");
                Console.WriteLine("2 - Пополнить счет");
                Console.WriteLine("3 - Снять деньги со счета");
                Console.WriteLine("4 - Выход");
                Console.WriteLine("*******************************"); 
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':   
                        Console.WriteLine();
                        Console.WriteLine(clientBanc.Print());
                        Console.ReadKey();
                        break;
                    case '2':
                        //AddRecord();
                        break;
                    case '3':
                        //RemoveRecord();
                        break;
                    case '4':
                        go_on = false;
                        break;
                    default:
                        Console.WriteLine("\nНеверный выбор");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
