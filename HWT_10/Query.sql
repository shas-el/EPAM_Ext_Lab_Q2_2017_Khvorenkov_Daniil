--1.1
--Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка 
--ShippedDate) включительно и которые доставлены с ShipVia>= 2. Формат указания даты должен быть 
--верным при любых региональных настройках, согласно требованиям статьи “Writing International 
--Transact-SQL Statements” в Books Online раздел “Accessing and Changing Relational Data Overview”.
--Этот метод использовать далее для всех заданий. 
--Запрос должен высвечивать только колонки OrderID, ShippedDate и ShipVia. 
--Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate. 
--A: Заказы с NULL не попали в результат, т.к. результат сравнения - unknown.

Select OrderID
,ShippedDate
,ShipVia
From Northwind.Orders
Where ShippedDate >= CONVERT(datetime, '19980506', 101)
	AND ShipVia >= 2


--1.2
--Написать запрос, который выводит только недоставленные заказы из  таблицы Orders.
--В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL
--строку ‘Not Shipped’ – использовать   системную   функцию CASЕ. 
--Запрос должен высвечивать только колонки OrderID и ShippedDate.

Select OrderID
,(case
      when ShippedDate is null then 'Not Shipped'
 end) as 'Shipped Date'
From Northwind.Orders
Where ShippedDate is null


--1.3
--Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate) не включая эту дату или которые еще не доставлены.
--В запросе  должны  высвечиваться  только колонки OrderID (переименовать в Order Number) и ShippedDate (переименовать в Shipped Date).
--В результатах запроса высвечивать для колонки ShippedDate вместо  значений NULL строку ‘Not Shipped’,
--для остальных значений высвечивать дату в формате по умолчанию.

Select OrderID as 'Order Number'
,(case
    when ShippedDate is null then 'Not Shipped'
   	else CONVERT(nvarchar, ShippedDate, 101)
 end) as 'Shipped Date'
From Northwind.Orders
Where ShippedDate is null
	OR ShippedDate > CONVERT(datetime, '19980506', 101)


--2.1
--Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada.
--Запрос сделать с только помощью оператора IN. 
--Высвечивать колонки с именем пользователя и названием страны в результатах запроса.
--Упорядочить результаты запроса по имени заказчиков и по месту проживания.

Select CompanyName
,Country
From Northwind.Customers
Where Country in ('USA', 'Canada')
Order by CompanyName, Country


--2.2
--Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada.
--Запрос сделать с помощью оператора IN. 
--Высвечивать колонки с именем пользователя и названием страны в результатах запроса.
--Упорядочить результаты запроса по имени заказчиков.

Select CompanyName
,Country
From Northwind.Customers
Where Country not in ('USA', 'Canada')
Order by CompanyName


--2.3
--Выбрать из таблицы Customers все страны, в которых проживают заказчики. 
--Страна должна быть упомянута только один раз и список отсортирован по убыванию.
--Не использовать предложение GROUP BY. Высвечивать только одну колонку в результатах запроса. 

Select distinct Country
From Northwind.Customers
Order by Country desc


--3.1
--Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться),
--где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity в таблице Order Details.
--Использовать  оператор BETWEEN. Запрос должен высвечивать только колонку OrderID.

Select distinct OrderID
From Northwind.[Order Details]
Where Quantity between 3 and 10


--3.2
--Выбрать всех заказчиков из таблицы Customers, у которых название страны
--начинается  на  буквы  из  диапазона b и g. 
--Использовать оператор BETWEEN. Проверить, что в результаты запроса попадает Germany.
--Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.

Select CustomerID
,Country
From Northwind.Customers
Where Country between 'b' and 'h'
Order by Country


--3.3
--Выбрать всех заказчиков из таблицы Customers, у которых название страны 
--начинается на буквы из диапазона b и g, не используя оператор BETWEEN.
--С помощью опции “Execution Plan” определить какой запрос предпочтительнее 3.2 или 3.3 –
--для этого надо ввести в скрипт выполнение текстового Execution Plan-a для двух этих запросов,
--результаты выполнения Execution Plan надо ввести в скрипт в виде комментария и по их результатам дать ответ
--на вопрос – по какому параметру было проведено сравнение. 
--Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
--A: Total Subtree Cost: с BETWEEN 0,01663704
--                     без BETWEEN 0,01663704

Select CustomerID
,Country
From Northwind.Customers
Where Country >= 'b' 
	AND Country < 'h'
Order by Country


--4.1
--В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'.
--Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине -
--найти все продукты, которые удовлетворяют этому условию.
--Подсказка: результаты запроса должны высвечивать 2 строки.

Select ProductName
From Northwind.Products
Where ProductName like '%cho_olade%'


--5.1
--Найти общую сумму всех заказов из таблицы OrderDetails с учетом количества закупленных товаров и скидок по ним.
--Результат округлить до сотых и высветить в стиле 1 для типа данных money.
--Скидка (колонка Discount)  составляет  процент  из  стоимости  для данного  товара.
--Для  определения  действительной  цены  на проданный продукт надо вычесть скидку из указанной в колонке UnitPrice цены.
--Результатом запроса должна быть одна запись с одной колонкой с названием колонки 'Totals'.

Select
CONVERT(money,
	ROUND(SUM(UnitPrice * (1 - Discount) * Quantity), 2),
	1) as 'Totals'
From Northwind.[Order Details]


--5.2
--По таблице Orders найти количество заказов, которые еще не были доставлены 
--(т.е. в колонке ShippedDate нет значения даты доставки).
--Использовать  при  этом  запросе  только  оператор COUNT.
--Не использовать предложения WHERE и GROUP.

Select COUNT(*) - COUNT(ShippedDate)
From Northwind.Orders


--5.3
--По таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы.
--Использовать функцию COUNT и не использовать предложения WHERE и GROUP.

Select COUNT(distinct CustomerID)
From Northwind.Orders


--6.1
--По таблице Orders найти количество заказов с группировкой по годам. 
--В результатах запроса надо высвечивать две колонки c названиями Year и Total.
--Написать проверочный запрос, который вычисляет количество всех заказов.

Select YEAR(OrderDate) as 'Year' -- не совсем корректно, поскольку ShippedDate проставлена не для всех заказов
,COUNT(*) as 'Total'
From Northwind.Orders
Group by YEAR(OrderDate)

--Проверочный запрос

Select COUNT(*)
From Northwind.Orders


--6.2
--По таблице Orders найти количество заказов, cделанных каждым продавцом.
--Заказ для указанного продавца – это любая запись в таблице Orders, где в колонке EmployeeID
--задано значение для данного продавца. В результатах запроса надо высвечивать колонку с именем продавца
--(Должно высвечиваться имя полученное конкатенацией LastName & FirstName. Эта строка LastName & FirstName
--должна быть получена отдельным запросом в  колонке  основного  запроса.
--Также основной запрос должен использовать группировку по EmployeeID.) 
--с  названием  колонки ‘Seller’ и колонку c количеством заказов высвечивать с названием 'Amount'.
--Результаты запроса должны быть упорядочены по убыванию количества заказов.

Select
(
	Select LastName + ' ' +  FirstName
	From Northwind.Employees
	Where Northwind.Employees.EmployeeID = Northwind.Orders.EmployeeID
) as 'Seller'
,COUNT(*) as 'Amount'
From Northwind.Orders
Group by EmployeeID
Order by Amount desc


--6.3
--По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя.
--Необходимо определить это только для заказов сделанных в 1998 году.
--В результатах запроса надо высвечивать колонку с именем продавца (название колонки ‘Seller’),
--колонку с именем покупателя (название  колонки ‘Customer’) и колонку cколичеством заказов высвечивать с названием 'Amount'.
--В запросе необходимо использовать специальный оператор языка T-SQL для работы с выражением GROUP
--(Этот же оператор поможет выводить строку “ALL” в результатах запроса).
--Группировки должны быть сделаны по ID продавца и покупателя.
--Результаты  запроса  должны  быть упорядочены по продавцу, покупателю и по убыванию количества продаж.
--В  результатах  должна  быть  сводная  информация  по продажам.

Select
(case
    when Northwind.Orders.EmployeeID is null then 'ALL'
	else
    	(Select LastName + ' ' +  FirstName
	    From Northwind.Employees
     	Where Northwind.Employees.EmployeeID = Northwind.Orders.EmployeeID)
end) as 'Seller'
,(case
    when Northwind.Orders.CustomerID is null then 'ALL'
	else
	    (Select CompanyName
    	From Northwind.Customers
	    Where Northwind.Customers.CustomerID = Northwind.Orders.CustomerID)
end) as 'Customer'
,COUNT(*) as 'Amount'
From Northwind.Orders
Where YEAR(OrderDate) = 1998
Group by grouping sets ((), (EmployeeID), (CustomerID), (EmployeeID, CustomerID))
Order by Seller, Customer, Amount desc


--6.4
--Найти покупателей и продавцов, которые живут в одном городе. 
--Если в городе живут только один или несколько  продавцов  или только один или несколько покупателей,
--то информация о таких покупателя и продавцах не должна попадать в результирующий набор.
--Не использовать конструкцию JOIN.
--В результатах запроса необходимо вывести следующие заголовки для результатов запроса:
--‘Person’, ‘Type’ (здесь  надо  выводить  строку  ‘Customer’ или ‘Seller’ в завимости от типа записи), ‘City’.
--Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.

Select Person
,Type
,City
From
    (Select LastName + ' ' +  FirstName as 'Person'
	,'Seller' as 'Type'
	,City
    From Northwind.Employees
    UNION
    Select CompanyName as 'Person'
    ,'Customer' as 'Type'
    ,City
    From Northwind.Customers) as Result
Where Result.City in 
    (Select City from Northwind.Employees
	 Intersect
	 Select City from Northwind.Customers)
Order by City, Person


--6.5
--Найти всех покупателей, которые живут в одном городе.
--В запросе использовать соединение таблицы Customers c собой - самосоединение.
--Высветить колонки CustomerID и City.
--Запрос не должен высвечивать дублируемые записи.
--Для проверки написать запрос, который высвечивает города,
--которые встречаются более одного  раза  в  таблице Customers.
--Это позволит проверить правильность запроса.

Select c1.CustomerID
,c1.City
From Northwind.Customers c1
    inner join Northwind.Customers c2
		on c1.City = c2.City 
	    AND c1.CustomerID <> c2.CustomerID
Group by c1.City, c1.CustomerID


--6.6
--По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты.
--Высветить колонки с именами 'User Name' (LastName) и 'Boss'.
--В колонках должны быть высвечены имена из колонки LastName.
--Высвечены  ли  все продавцы в этом запросе?
--A: Не высвечен Fuller, т.к. у него нет руководителя.

Select e1.LastName as 'User Name'
,e2.LastName as 'Boss'
From Northwind.Employees e1
    inner join Northwind.Employees e2
	    on e1.ReportsTo = e2.EmployeeID


--7.1
--Определить продавцов, которые обслуживают регион 'Western' (таблица Region).
--Результаты запроса должны высвечивать два поля: 'LastName' продавца
--и название обслуживаемой территории ('TerritoryDescription' из таблицы Territories).
--Запрос должен использовать JOIN в предложении FROM.
--Для определения связей между таблицами Employees и Territories 
--надо использовать графические диаграммы для базы Northwind.

Select e.LastName
,t.TerritoryDescription
From Northwind.EmployeeTerritories et
    inner join Northwind.Employees e
	    on et.EmployeeID = e.EmployeeID
	inner join Northwind.Territories t
	    on et.TerritoryID = t.TerritoryID


--8.1
--Высветить в результатах запроса имена всех заказчиков из таблицы Customers
--и суммарное количество их заказов из таблицы Orders.
--Принять во внимание, что у некоторых заказчиков нет заказов,
--но они также должны быть выведены в результатах запроса.
--Упорядочить результаты запроса по возрастанию количества заказов.

Select c.CompanyName
,COUNT(o.OrderID) as 'Amount'
From Northwind.Customers c
    left join Northwind.Orders o
	    on c.CustomerID = o.CustomerID
Group by c.CompanyName
Order by Amount


--9.1
--Высветить всех поставщиков колонка CompanyName в таблице Suppliers,
--у которых нет хотя бы одного продукта на складе (UnitsInStock в таблице Products равно 0).
--Использовать вложенный SELECT для этого запроса с использованием оператора IN.
--Можно ли использовать вместо оператора IN оператор '='?
--A: Только если с JOIN

Select CompanyName
From Northwind.Suppliers
Where SupplierID in
    (Select SupplierID
	From Northwind.Products
	Where UnitsInStock = 0)


--10.1
--Высветить всех продавцов, которые имеют более 150 заказов.
--Использовать вложенный коррелированный SELECT.

Select EmployeeID
,LastName + ' ' + FirstName
From Northwind.Employees e
Where 150 <
    (Select COUNT(*)
	From Northwind.Orders
	Where EmployeeID = e.EmployeeID)


--11.1
--Высветить всех заказчиков (таблица Customers), которые не имеют 
--ни одного заказа подзапрос по таблице Orders).
--Использовать коррелированный SELECT и оператор EXISTS.

Select CustomerID
,CompanyName
From Northwind.Customers c
Where not exists
    (Select OrderID
	From Northwind.Orders
	Where CustomerID = c.CustomerID)


--12.1
--Для формирования алфавитного указателя Employees высветить из таблицы Employees список только тех букв алфавита,
--с которых начинаются фамилии Employees (колонка LastName) из этой таблицы.
--Алфавитный список должен быть отсортирован по возрастанию.

Select distinct SUBSTRING(LastName, 1, 1)
From Northwind.Employees


--13.1
--Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за определенный год.
--В результатах не может быть несколько заказов одного продавца, должен быть только один и самый крупный.
--В результатах запроса должны быть выведены следующие колонки:
--колонка с именем и фамилией продавца (FirstName и LastName – пример: Nancy Davolio), номер заказа  и  его  стоимость.
--В запросе надо учитывать Discount при продаже  товаров. 
--Процедуре передается год, за который надо сделать отчет, и количество возвращаемых записей.
--Результаты запроса должны быть упорядочены по убыванию суммы заказа. 
--Процедура должна быть реализована с использованием оператора SELECT и БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ.
--Название функции соответственно GreatestOrders.
--Необходимо продемонстрировать использование этих  процедур. 
--Также помимо демонстрации вызовов процедур в скрипте Query.sql надо написать отдельный
--ДОПОЛНИТЕЛЬНЫЙ проверочный запрос для тестирования правильности работы процедуры GreatestOrders.
--Проверочный запрос должен выводить в удобном для сравнения с результатами работы процедур виде
--для определенного продавца для всех его заказов за определенный указанный год в результатах следующие колонки:
--имя продавца, номер заказа, сумму заказа.
--Проверочный запрос не должен повторять запрос, написанный в процедуре, - 
--он должен выполнять только то, что описано в требованиях по нему.
--ВСЕ  ЗАПРОСЫ  ПО  ВЫЗОВУ  ПРОЦЕДУР  ДОЛЖНЫ  БЫТЬ НАПИСАНЫ В ФАЙЛЕ Query.sql

Exec Northwind.GreatestOrders 1997, 100

--Проверочный запрос
Select Seller
,[Order Number]
,SUM(Cost) as 'Total'
From
(
    Select FirstName + ' ' + LastName as 'Seller'
    ,od.OrderID as 'Order Number'
    ,(UnitPrice * (1 - Discount) * Quantity) as 'Cost'
    From Northwind.Orders o
        inner join Northwind.[Order Details] od
	        on o.OrderID = od.OrderID
	    inner join Northwind.Employees e
	        on o.EmployeeID = e.EmployeeID
    Where YEAR(o.OrderDate) = 1997
	    And LastName = 'Davolio'
) as Result
Group by Seller, [Order Number]
Order by Total desc


--13.2
--Написать процедуру, которая возвращает заказы в таблице Orders, согласно указанному сроку доставки в днях
--(разница между OrderDate и ShippedDate). В результатах должны быть возвращены  заказы,
--срок которых превышает переданное значение  или  еще  недоставленные  заказы.
--Значению  по умолчанию  для  передаваемого  срока  35  дней.
--Название процедуры ShippedOrdersDiff. Процедура должна высвечивать следующие колонки:
--OrderID, OrderDate, ShippedDate, ShippedDelay (разность в днях между ShippedDate и OrderDate), SpecifiedDelay(переданное в процедуру значение).
--Необходимо продемонстрировать использование этой процедуры.

Exec Northwind.ShippedOrdersDiff 5
Exec Northwind.ShippedOrdersDiff 20
Exec Northwind.ShippedOrdersDiff


--13.3
--Написать процедуру, которая высвечивает всех подчиненных заданного продавца, как непосредственных, так и подчиненных его подчиненных.
--В качестве входного параметра функции используется EmployeeID. Необходимо распечатать имена подчиненных и выровнять их в тексте
--(использовать оператор PRINT) согласно иерархии подчинения. Продавец, для которого надо найти подчиненных также должен быть высвечен.
--Название процедуры SubordinationInfo. В качестве алгоритма для решения это задачи надо использовать пример, приведенный в Books Online
--и рекомендованный Microsoft для решения подобного типа задач. Продемонстрировать использование процедуры.

--Не получилось вывести c PRINT
Exec Northwind.SubordinationInfo 2 -- попробуй все-таки реализовать с PRINT


--13.4
--Написать функцию, которая определяет, есть ли у продавца подчиненные.
--Возвращает тип данных BIT. В качестве входного параметра функции используется EmployeeID.
--Название функции IsBoss. Продемонстрировать использование функции для всех продавцов из таблицы Employees.

Select FirstName + ' ' + LastName as 'Employee'
,EmployeeID
,ReportsTo
,Northwind.IsBoss(EmployeeID) as 'Is Boss'
From Northwind.Employees
Order by [Is Boss] desc, ReportsTo