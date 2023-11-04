Create Procedure spGetProductsByName

@ProductName nvarchar(Max)
as
Begin
 Select * from Product
 where Name like @ProductName + '%'
End