
Create DataBase HumanResourceDB

use HumanResourceDB

Create Table Employ(
id bigint identity(1,1) primary key not null,
[name] nvarchar(50) null,
dateOfBirth datetime not null,
salary int default(0) not null,
address nvarchar(100) null,
removed bit not null
)

truncate table Employ

insert into Employ values(N'�ª���','1991-08-17',15000,N'�s�_�������',0)