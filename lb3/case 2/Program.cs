using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat.Accountspace;
//using Bankomat.Bancspace;
using Bankomat.Clientspace;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            uint temp = 3;
            char key;
            uint _passKey;
            bool go_on = true;
            uint _pass = (uint) new Random().Next(100, 999);
            uint _accountNumber = (uint) new Random().Next(100000000, 999999999);
            Console.WriteLine("\tВведите данные для создания счета \nВведите Имя");
            try
            {
                string _firstName = Console.ReadLine();
                Console.WriteLine("\nВведите Фамилию");
                string _lastName = Console.ReadLine();
                Console.Clear();
                if (!(_lastName.Length == 0 || _firstName.Length == 0))
                {
                    Console.WriteLine($"Ваш пинкод {_pass} \nНомер Вашего лицевого счета {_accountNumber}" +
                                      $"\n\nДля продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    var clientBanc = new Bankomat.Bancspace.Banc();
                    clientBanc.objClient = new Client(_firstName, _lastName);
                    clientBanc.objClient.objAccount = new Account(_accountNumber, _pass);

                    while (go_on)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите ПИН-КОД");
                        _passKey = Convert.ToUInt32(Console.ReadLine());
                        if (_passKey == _pass)
                        {
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
                                        Console.WriteLine("\nДля продолжения нажмите любую клавишу \t Для выхода нажмите 0");
                                        key = Console.ReadKey().KeyChar;
                                        if (key == '0')
                                        {
                                            go_on = false;
                                        }
                                        break;
                                    case '2':
                                        Console.Clear();
                                        Console.WriteLine("Введите сумму которую хотите внести на счет");
                                        temp = Convert.ToUInt32(Console.ReadLine());
                                        clientBanc.refillAmount(ref clientBanc, temp);
                                        Console.WriteLine("\nДля продолжения нажмите любую клавишу \t Для выхода нажмите 0");
                                        key = Console.ReadKey().KeyChar;
                                        if (key == '0')
                                        {
                                            go_on = false;
                                        }
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
                                        Console.Clear();
                                        Console.WriteLine("\nНеверный выбор");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            temp--;
                            if (temp == 0)
                            {
                                Console.WriteLine("Карта заблокирована");
                                go_on = false;
                            }
                            Console.Clear();
                            Console.WriteLine("Введенный ПИН-КОД не верный \n\nДля продолжения нажмите любую клавишу");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nНекорректно введены данные");
                }
                Console.Clear();
                Console.WriteLine("Завершение программы");
            }
            catch (Exception)
            {
                Console.WriteLine("Завершение программы");
            }
             
        }
    }
}
