create table dbo.[User]
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

create table [Order]
(
	order_Id int identity
		constraint Order_pk
			primary key nonclustered,
	user_id int not null
		constraint Order_User_user_id_fk
			references [User],
	table_number int not null,
	time_ordered datetime,
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
	in_use tinyint default 0 not null
)
go

create table Order_Details
(
	order_id int 
		constraint Order_Details_Order_order_Id_fk
			references [Order],
	product_id int
		constraint Order_Details_Product_product_id_fk
			references Product,
	quantity int not null,
	constraint Order_Details_pk
		primary key nonclustered (order_id, product_id)
)
go


