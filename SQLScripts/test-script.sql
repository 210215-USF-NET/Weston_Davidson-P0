drop table batch;
drop table trainers;
drop table associates;

create table associates
(
	id int identity primary key,
	/*you can start an identity at any key*/
	associateName nvarchar(100) not null,
	/*what's the difference between nvarchar and varchar? QC QUESTION ALERT	*/
	/* https://stackoverflow.com/questions/144283/what-is-the-difference-between-varchar-and-nvarchar */
	associateLocale varchar(2) not null,
	revaPoints int not null



);

create table trainers
(
	id int identity primary key,
	trainerName nvarchar(100) not null,
	campus varchar(3) not null,
	caffeineLevel int not null

);

create table batch
(
	id int identity primary key,
	associateID int references associates(id),
	trainerID int references trainers(id)
);