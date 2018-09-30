#### Aaron Colclough
#### Sep 30, 2018


# ISTA Project

## Step 8

###### Requirements
1. Database to hold questions and answers.
2. User interface to access and present the data in the database.

###### Analysis
The user interface must have access to the database storing the questions and answers intended for study. The user will be able to choose from multiple Categories and Subcategories of questions in order to refine their type of studying. The interface must be able to present the user with the question and, following a user action, present the corresponding answer.

###### Design
**Categories**

| Column | Type | Null | Identity | Key |
| --- | --- | --- | --- | --- |
| catID | int | No | Unique (1,1) | PK |
| catName | varchar (50) | No | | | |

||

||

||

V

**Subcategories**

| Column | Type | Null | Identity | Key |
| --- | --- | --- | --- | --- |
| subID | int | No | Unique (1,1) | PK |
| subName | varchar (50) | No | | |
| catID | int | No | | FK (Categories) |

||

||

||

V

**QA_Details**

| Column | Type | Null | Identity | Key |
| --- | --- | --- | --- | --- |
| Question | varchar (1000) | No | | |
| Answer | varchar (3000) | No | | |
| qaID | int | No | Unique (1,1) | PK |
| subID | int | No | | FK (Subcategories) |


###### Implementation
Implementation was fairly simple and straightforward. Creation of the tables was done like this:
```
create table Subcategories(
	subID int unique not null identity (1,1),
	subName varchar(50) not null,
	catID int not null
	constraint PK_Subcategories
		primary key(subID)
);
```
```
create table Categories(
	catID int unique not null identity (1,1),
	catName varchar(50) not null
	constraint PK_Categories
		primary key(catID)		
);
```
```
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
```
```
alter table Subcategories
	add constraint FK_Subcategories_Categories
	foreign key(catID)
	references Categories(catID);

alter table QA_Details
	add constraint FK_QA_Details_Subcategories
	foreign key(subID)
	references Subcategories(subID);
```

Filling the tables with data was done both by INSERT INTO and BULK INSERT. For the questions and answers, it was obviously simpler to put them and their corresponding ID numbers into a comma separated value file and then upload it to the database.

```
insert into Categories
	values ('All'), ('Weapons'), ('Wear and Appearance'), ('Drill and Ceremony'), ('Army History'), ('Basic Soldier Skills'),
		('Leadership'), ('Military Justice'), ('Customs and Courtesies'), ('Army Programs')

insert into Subcategories
	values ('Unknown', 1), ('First Aid', 6), ('PMCS', 6), ('General Orders', 6), ('Counseling', 7), ('PT and Body Composition', 7),
		('NCOER', 7), ('Counseling', 7), ('M16/M4', 2), ('M240', 2), ('M203', 2), ('M320', 2), ('AT4', 2), ('LAW', 2), ('M18A1 Claymore', 2),
		('Marksmanship', 2), ('Land Navigation', 6)
```
```
bulk insert QA_Details from 'c:\users\aaron\desktop\QandA3.csv'
	with
	(
		datafiletype	= 'char',
		format			= 'csv',
		fieldterminator	= ',',
		rowterminator	= '\n'
	);
```
###### Testing
Because my database is so limited, I found it more efficient to just query each table to verify that the data filled correctly.

```
select * from Categories
select * from Subcategories
select * from QA_Details
```
To then test that my tables connected correctly, I began querying joins.
```
select  q.Question, q.Answer, s.subName, c.catName
from QA_Details q
	join Subcategories s
		on q.subID = s.subID
	join Categories c
		on c.catID = s.catID
where s.subID = 13
```
