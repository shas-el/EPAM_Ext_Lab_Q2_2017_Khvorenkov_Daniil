--13.1
If OBJECT_ID('Northwind.GreatestOrders', 'p') is not null
    Drop procedure Northwind.GreatestOrders;
Go

Create procedure Northwind.GreatestOrders @year int, @amount int
AS
Begin
Select top(@amount) r1.Seller
,r1.[Order Number]
,r1.Cost
From
(
	(Select e1.FirstName + ' ' + e1.LastName as 'Seller'
	,o1.OrderID as 'Order Number'
	,SUM(UnitPrice * (1 - Discount) * Quantity) as Cost
	From Northwind.Orders o1
	inner join Northwind.[Order Details] od1
		on o1.OrderID = od1.OrderID
	inner join Northwind.Employees e1
		on o1.EmployeeID = e1.EmployeeID
	Where YEAR(o1.OrderDate) = @year
	Group by e1.FirstName, e1.LastName, o1.OrderID) r1
	inner join
		(Select Seller
		,MAX(Cost) as 'Max Order'
		From
			(Select e2.FirstName + ' ' + e2.LastName as 'Seller'
			,SUM(UnitPrice * (1 - Discount) * Quantity) as Cost
			From Northwind.Orders o2
			inner join Northwind.[Order Details] od2
				on o2.OrderID = od2.OrderID
			inner join Northwind.Employees e2
				on o2.EmployeeID = e2.EmployeeID
			Where YEAR(o2.OrderDate) = @year
			Group by e2.FirstName, e2.LastName, o2.OrderID) r2
		Group by Seller) r3
		on r1.Cost = r3.[Max Order] AND r1.Seller = r3.Seller
)
Order by Cost desc
End
Go


--13.2
If OBJECT_ID('Northwind.ShippedOrdersDiff', 'p') is not null
    Drop procedure Northwind.ShippedOrdersDiff;
Go

Create procedure Northwind.ShippedOrdersDiff @delay int = 35
AS
Begin
Select OrderID
,OrderDate
,ShippedDate
,DAY(ShippedDate - OrderDate) as 'Shipped Delay'
,@delay as 'Specified Delay'
From Northwind.Orders
Where DAY(ShippedDate - OrderDate) > @delay
	OR ShippedDate is null
End
Go


--13.3
If OBJECT_ID('Northwind.SubordinationInfo', 'p') is not null
    Drop procedure Northwind.SubordinationInfo;
Go

Create procedure Northwind.SubordinationInfo @empID int -- посмотри по этим ссылкам https://docs.microsoft.com/ru-ru/sql/relational-databases/hierarchical-data-sql-server
																				-- https://stackoverflow.com/questions/18106947/cte-recursion-to-get-tree-hierarchy
																--задача сгенерировать запрос, который будет возвращать древовидную структуру иерархии, а в конце его распечатать
AS
Begin
With Reports (ManagerID, SubordinateID, Level, Indent)
AS
(
	Select ReportsTo as ManagerID
	,EmployeeID as SubordinateID
	,0 as Level
	,CONVERT(nvarchar, '') as Indent
	From Northwind.Employees e
	Where EmployeeID = @empID
	UNION ALL
	Select ReportsTo as ManagerID
	,EmployeeID as SubordinateID
	,Level + 1
	,CONVERT(nvarchar, CONCAT(Indent, '  ')) as Indent
	From Northwind.Employees e
	inner join Reports r
		on e.ReportsTo = r.SubordinateID
)
Select e2.FirstName + ' ' + e2.LastName as Manager
,Indent + e1.FirstName + ' ' + e1.LastName as Subordinate
,Level
From Reports r
inner join Northwind.Employees e1
	on r.SubordinateID = e1.EmployeeID
inner join Northwind.Employees e2
	on r.ManagerID = e2.EmployeeID
End
Go


--13.4
If OBJECT_ID('Northwind.IsBoss', 'fn') is not null
    Drop function Northwind.IsBoss;
Go

Create function Northwind.IsBoss(@empID int)
Returns bit
Begin
Declare @result bit
If exists 
	(Select *
	From Northwind.Employees
	Where ReportsTo = @empID)
	set @result = 1;
Else
    set @result = 0;
Return @result
End
Go