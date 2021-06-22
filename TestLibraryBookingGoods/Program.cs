using LibraryBookingGoods;
using System;
using System.Threading;

namespace TestLibraryBookingGoods
{
    class Program
    {
        private const int _numberOfRequests = 500;
        private static readonly ShopStorage _shop = new ShopStorage();
        static void Main(string[] args)
        {

            var myThread = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread.Start(); //запускаем поток
            var myThread2 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread2.Start(); //запускаем поток
            var myThread3 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread3.Start(); //запускаем поток
            var myThread4 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread4.Start(); //запускаем поток
            var myThread5 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread5.Start(); //запускаем поток
            var myThread6 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread6.Start(); //запускаем поток
            var myThread7 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread7.Start(); //запускаем поток
            var myThread8 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread8.Start(); //запускаем поток
            var myThread9 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread9.Start(); //запускаем поток
			Foo();

			static void Foo()
            {
                for (int i = 0; i < _numberOfRequests; i++)
                {                    
                    var result = _shop.ReservProduct("lemon", 1).Result;
                    Console.WriteLine(result);
                }                                               
            }     
        }
    }
}
