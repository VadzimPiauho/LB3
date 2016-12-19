using System;

namespace Bankomat
{
    namespace Bancspace
    {
        class Banc
        {
            public Bankomat.Clientspace.Client objClient;

            public string Print()
            {
                return
                    $"Клиент:  {objClient.firstName} {objClient.lastName}" +
                    $"\nНомер счета: {objClient.objAccount.accountNumber}" +
                    $"\nСумма на счете: {objClient.objAccount.amount}";
            }
            public void refillAmount(ref Banc obj, uint amountTemp)
            {
                obj.objClient.objAccount.amount += amountTemp;
                Console.WriteLine("Счет пополнен");
                Console.ReadKey();
            }
            public void takeAmount(ref Banc obj, uint amountTemp)
            {
                if (!(obj.objClient.objAccount.amount < amountTemp))
                {
                    obj.objClient.objAccount.amount -= amountTemp;
                    Console.WriteLine("Сумма со счета снята");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("На счете недостаточно средств");
                    Console.ReadKey();
                }
            }
        }
    }
}
