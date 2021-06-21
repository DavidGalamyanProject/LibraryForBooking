## Тестовое задание на вакансию разработчик  
  
### Задание:  
  
Вs программист крупной компании типа Вали-Экспресс. Компания продает миллионы товаров по всему миру.  
Задача написать библиотеку бронирования товаров. Библиотека будет использоваться КАК НА САЙТЕ 
компании, ТАК И С РАБОЧИХ мест внутри компании.  
Разработайте структуру таблиц, где хранятся товары, бронь... Обязательно вы должны хранить и нформацию 
о товаре, остатке товара на складе и процессу бронирования.  
  
В день открытия мега Акции ожидается бешеный ажиотаж - ваша задача в библиотеке бронирования написать 
метод брони таким образом, чтобы:  
- [X] Товар доставался первому бронирующему в честной конкурентной борьбе - кто первый бронирует, 
тому и достается товар;  
- [X] Не получилось так, чтобы забронировался товар без остатка;  
- [X] Верно подстчитывался остаток после бронирования;  
- [X] Верно сохранялась информация о брони.  
  
  
Примерный алгоритм использования библиотеки:  
  
```cs  
var shopStorage = new shopStorage();
shopStorage.Reserve("некий товар", 10);
```  
  
В МНОГОПОТОЧНОЙ, МНОГОПОЛЬЗОВАТЕЛЬСКОЙ среде код должен всегда отрабатываться корректно.  
  
Итоговым результатом должен быть многопоточный тест (где, например, 10 параллельных потоков, 
где каждый поток пытается забронировать товар в цикле 1000 раз).  
Все потоки должны получить корректный результат бронирования и БД при этом не встала из-за дэдлоков.  
Для теста - пусть будет всего один товар и все потоки бронируют его по 1-3 шт. А начальный остаток товара 
был бы 100шт.  
  
Желательно решение на C# для БД: Postgres или MS SQL Express или LocalDb.  
  
---  
  
### Пояснения по выполнению задания.  
  
В солюшене 3 проекта:  
  
- **[ShopWebApi](./Docs/ShopWebApi.md)** - веб-сервер который принимает запросы на бронирование товара, и взаимодействует с БД (Postgres)..  
- **LibraryBookingGoods** - библиотека отправляющая на сервер запросы о бронировании товара.  
- **TestLibraryBookingGoods** - тестовое приложение для проверки работы библиотеки и веб-сервера.  
  
