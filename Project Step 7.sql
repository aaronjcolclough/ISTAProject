use [Army Study Guide];

drop table if exists Subcategories;

create table Subcategories(
	subID int unique not null identity (1,1),
	subName varchar(50) not null,
	catID int not null
	constraint PK_Subcategories
		primary key(subID)
);

drop table if exists Categories;

create table Categories(
	catID int unique not null identity (1,1),
	catName varchar(50) not null
	constraint PK_Categories
		primary key(catID)		
);

drop table if exists QA_Details;

create table QA_Details(	
	Question varchar(1000) not null,
	Answer varchar(3000) not null,
	qaID int unique not null identity (1,1),
	subID int not null
	constraint PK_QA_Details
		primary key(qaID)
		foreign key(subID)
		references Subcategories(subID)	
);

alter table Subcategories
	add constraint FK_Subcategories_Categories
	foreign key(catID)
	references Categories(catID);

alter table QA_Details
	add constraint FK_QA_Details_Subcategories
	foreign key(subID)
	references Subcategories(subID);

drop table if exists PDFs;

create table PDFs(
	pdfID int unique not null identity (1,1),
	pdfName varchar(100) not null,
	subID int not null
	constraint PK_PDFs
		primary key(pdfID),
		foreign key(subID)
		references Subcategories
);


insert into Categories
	values ('All'), ('Weapons'), ('Wear and Appearance'), ('Drill and Ceremony'), ('Army History'), ('Basic Soldier Skills'),
		('Leadership'), ('Military Justice'), ('Customs and Courtesies'), ('Army Programs')

insert into Subcategories
	values ('Unknown', 1), ('First Aid', 6), ('PMCS', 6), ('General Orders', 6), ('Counseling', 7), ('PT and Body Composition', 7), 
		('NCOER', 7), ('Counseling', 7), ('M16/M4', 2), ('M240', 2), ('M203', 2), ('M320', 2), ('AT4', 2), ('LAW', 2), ('M18A1 Claymore', 2), 
		('Marksmanship', 2), ('Land Navigation', 6)

bulk insert QA_Details from 'c:\users\aaron\desktop\QandA3.csv'
	with
	(
		datafiletype	= 'char',
		format			= 'csv',
		fieldterminator	= ',',
		rowterminator	= '\n'
	);

select * from Categories
select * from Subcategories
select * from QA_Details
select * from PDFs
select  q.Question, q.Answer, s.subName, c.catName 
from QA_Details q
	join Subcategories s
		on q.subID = s.subID
	join Categories c
		on c.catID = s.catID
where s.subID = 13


