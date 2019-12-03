create table User
(
	user_id int identity
		constraint User_pk
			primary key nonclustered,
	first_name nvarchar(MAX) not null,
	last_name nvarchar(MAX) not null,
	email nvarchar(MAX) not null,
	password nvarchar(MAX) not null,
	admin tinyint default 0 not null
)
go

create table Order
(
	order_Id int identity
		constraint Order_pk
			primary key nonclustered,
	user_id int not null
		constraint Order_User_user_id_fk
			references User,
	table_number int not null,
	time_ordered datetime,
	preparing tinyint default 0 not null,
	completed tinyint default 0 not null,
	time_completed datetime
)
go

create table Product
(
	product_id int identity
		constraint Product_pk
			primary key nonclustered,
	prod_name nvarchar(max) not null,
	prod_desc nvarchar(max),
	prod_category nvarchar(max) not null,
	prod_price decimal(13,2) not null,
	in_use tinyint default 0 not null,
	stock int default 0
)
go

create table Order_Details
(
	order_id int 
		constraint Order_Details_Order_order_Id_fk
			references Order,
	product_id int
		constraint Order_Details_Product_product_id_fk
			references Product,
	quantity int not null,
	constraint Order_Details_pk
		primary key nonclustered (order_id, product_id)
)
go

--Views, Triggers and Procedures

--Creates a sales view
CREATE VIEW Sales AS
SELECT sum(Order_Details.quantity * Product.prod_price) as TotalCost,
 [Order].order_id as OrderID, dbo.[User].user_id as UserId
 FROM Order_Details, Product, [Order], dbo.[User]
 WHERE [Order].order_id = Order_Details.order_id
 AND Order_Details.product_id = Product.product_id
 AND [Order].user_id = dbo.[User].user_id
 GROUP BY [Order].order_id, dbo.[User].user_id;
 
 --Monthly sales view
CREATE VIEW MonthlySales AS
SELECT sum(Order_Details.quantity * Product.prod_price) as TotalCost,
 [Order].order_id as OrderID, dbo.[User].user_id as UserId
 FROM Order_Details, Product, [Order], dbo.[User]
 WHERE [Order].time_ordered > DATEADD(month, -1, GETDATE())
 AND [Order].order_id = Order_Details.order_id
 AND Order_Details.product_id = Product.product_id
 AND [Order].user_id = dbo.[User].user_id
 GROUP BY [Order].order_id, dbo.[User].user_id;
go

 
--Change stock trigger
CREATE TRIGGER ChangeStock ON Order_Details
AFTER INSERT
AS
BEGIN
    UPDATE Product
    SET Product.stock = Product.stock - inserted.Quantity
    FROM inserted
    WHERE Product.product_id = inserted.product_id
END
go

--A trigger to turn items off or on sale
CREATE TRIGGER OnSale ON Product
    AFTER UPDATE, INSERT
    AS
    BEGIN
        UPDATE Product
        SET Product.in_use = 1
        WHERE Product.stock >= 1;

        UPDATE Product
        SET Product.in_use = 0
        WHERE Product.stock = 0;
    END
GO

--Set datetime after completed
CREATE TRIGGER CompletedTime ON [Order]
    AFTER UPDATE
    AS
    BEGIN
        UPDATE [Order]
        SET Order.time_completed = GETDATE()
        FROM inserted
        WHERE Order.completed = 1
        AND [Order].order_id = inserted.order_id
    END
GO
 
 -- Find details of a product
CREATE PROCEDURE FindProduct(@ProductID as INT) AS
BEGIN
    SELECT prod_desc, prod_price, stock
    FROM Product
    WHERE product_id = @ProductID
END;
GO 
 
 --In Stock procedure returning boolean
CREATE PROCEDURE InStock(@ProductID as INT, @StockWanted as INT) AS
    BEGIN
        DECLARE @currentStock INT;

            SELECT @currentStock = Product.stock
            FROM Product
            WHERE Product.product_id = @ProductID

        IF @currentStock < @StockWanted
        BEGIN
            RETURN 0;
        END
        ELSE IF @currentStock >= @StockWanted
        BEGIN
            RETURN 1;
        END
    END






