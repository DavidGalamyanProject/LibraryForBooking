## �������� ������� "" �� �������� �����������  
  
### �������:  
  
� ����������� ������� �������� ���� ����-��������. �������� ������� �������� ������� �� ����� ����.  
������ �������� ���������� ������������ �������. ���������� ����� �������������� ��� �� ����� 
��������, ��� � � ������� ���� ������ ��������.  
������������ ��������� ������, ��� �������� ������, �����... ����������� �� ������ ������� � ��������� 
� ������, ������� ������ �� ������ � �������� ������������.  
  
� ���� �������� ���� ����� ��������� ������� ������� - ���� ������ � ���������� ������������ �������� 
����� ����� ����� �������, �����:  
- [ ] ����� ���������� ������� ������������ � ������� ������������ ������ - ��� ������ ���������, 
���� � ��������� �����;  
- [ ] �� ���������� ���, ����� �������������� ����� ��� �������;  
- [ ] ����� �������������� ������� ����� ������������;  
- [ ] ����� ����������� ���������� � �����.  
  
  
��������� �������� ������������� ����������:  
  
```cs  
var shopStorage = new shopStorage();
shopStorage.Reserve("����� �����", 10);
```  
  
� �������������, ��������������������� ����� ��� ������ ������ �������������� ���������.  
  
�������� ����������� ������ ���� ������������� ���� (���, ��������, 10 ������������ �������, 
��� ������ ����� �������� ������������� ����� � ����� 1000 ���).  
��� ������ ������ �������� ���������� ��������� ������������ � �� ��� ���� �� ������ ��-�� ��������.  
��� ����� - ����� ����� ����� ���� ����� � ��� ������ ��������� ��� �� 1-3 ��. � ��������� ������� ������ 
��� �� 100��.  
  
���������� ������� �� C# ��� ��: Postgres ��� MS SQL Express ��� LocalDb.  
  
---  
  
### ��������� �� ���������� �������.  
  
� �������� 3 �������:  
  
- **ShopWebApi** - ���-������ ������� ��������� ������� �� ������������ ������, � ��������������� � �� (Postgres)..  
- **LibraryBookingGoods** - ���������� ������������ �� ������ ������� � ������������ ������.  
- **TestLibraryBookingGoods** - �������� ���������� ��� �������� ������ ���������� � ���-�������.  
  