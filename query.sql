use WeblogDB
create   table Users(
	username varchar(255) unique,
	fullname varchar(255) not null,
	email varchar(255) not null unique,
	pass varchar(255) not null,
	totalposts int,
	primary key (email, pass)
	


);
alter table Users add constraint pk primary key(userID)
select * from Users
insert into Users values('shaha', 'shah@shah.shah', 'shahshah')
exec sp_help Users

create  table FollowingMap(
	fid int primary key identity(1,1),
	followedby varchar(255) foreign key references Users(username),
	following varchar(255) foreign key references Users(username),

	
);

create  table Articles(
	artID int identity(1,1),
	createdAt datetime,
	writer varchar(255) foreign key references Users(username)
	constraint artPK primary key (artID, writer) 
);
alter table Articles
add title varchar(255)

insert into Articles values('2008-11-11 13:23:44', 'asdf', 'big article small')