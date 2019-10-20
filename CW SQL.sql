create table Coursework.[User]
(
	user_id int identity
		constraint User_pk
			primary key nonclustered,
	first_name nvarchar not null,
	last_name nvarchar not null,
	email nvarchar not null,
	password nvarchar not null,
	admin tinyint default 0 not null
)
go


