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
            public void refillAmount(ref Banc obj, uint amountTemp)
            {   
                obj.objClient.objAccount.amount += amountTemp;
                Console.WriteLine("Счет пополнен");
                Console.ReadKey();
            }
            public void takeAmount(ref Banc obj, uint amountTemp)
            {
                obj.objClient.objAccount.amount -= amountTemp;
                Console.WriteLine("Сумма со счета снята");
                Console.ReadKey();
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

            public Client(string firstName, string lastName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }
        }
        
    }

    namespace Accountspace
    {
        class Account
        {
            public uint accountNumber { get; set; } = 0;
            public uint pass { get; set; } = 0;
            public uint amount { get; set; } = 0;
            public Account(uint accountNumber, uint pass/*, uint amount*/)
            {
                this.accountNumber = accountNumber;
                this.pass = pass;
               // this.amount = amount;
            }  
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            uint temp;
            uint _pass =(uint) new Random().Next(999);
            uint _accountNumber = (uint) new Random().Next(999999999);
            Console.WriteLine("\tВведите данные для создания счета \nВведите Имя");
            string _firstName = Console.ReadLine();
            Console.WriteLine("\nВведите Фамилию");
            string _lastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Ваш пинкод {_pass} \nНомер Вашего лицевого счета {_accountNumber}");
            Console.ReadKey();
            var clientBanc = new Banc();
            clientBanc.objClient = new Client(_firstName, _lastName);
            clientBanc.objClient.objAccount = new Account(_accountNumber, _pass);

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
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(clientBanc.Print());
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Введите сумму которую хотите внести на счет");
                        temp = Convert.ToUInt32(Console.ReadLine()); 
                        clientBanc.refillAmount(ref clientBanc, temp); 
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Введите сумму которую хотите снять со счета");
                        temp = Convert.ToUInt32(Console.ReadLine());
                        clientBanc.takeAmount(ref clientBanc, temp);
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
