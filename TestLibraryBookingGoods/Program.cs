using LibraryBookingGoods;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestLibraryBookingGoods
{
    class Program
    {
        private const int _numberOfRequests = 300;
        static async Task Main(string[] args)
        {
            
            var myThread = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread.Start(); //запускаем поток
            var myThread2 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread2.Start(); //запускаем поток
            var myThread3 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread3.Start(); //запускаем поток
            var myThread4 = new Thread(new ThreadStart(Foo)); //Создаем новый объект потока (Thread)
            myThread4.Start(); //запускаем поток

            var shop = new ShopStorage();
            for (int i = 0; i < _numberOfRequests; i++)
            {
                var result = await shop.ReservProduct("lemon", 1);
                Console.WriteLine(result);

            }            

            static async void Foo()
            {
                var shop = new ShopStorage();
                for (int i = 0; i < _numberOfRequests; i++)
                {
                    var result = await shop.ReservProduct("lemon", 1);
                    Console.WriteLine(result);

                }
            }     
        }
    }
}
