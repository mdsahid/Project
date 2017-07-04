
go
create database UniversityDB

go 
use UniversityDB

go


create table Department
(

depCode nvarchar(250) primary key,
depName varchar(250) unique

)

go

create table Semester
(
SemesterID int primary key identity(1,1),

SemesterName varchar(250)

)

go
create table Course
(
courseId int identity(100,1) primary key,
CourseCode varchar(250) unique,
CourseName varchar(250) unique,
CourseCredit float,
CourseDescription varchar(500),
depCode nvarchar(250) foreign key references Department,
SemesterID int foreign key references Semester
)

go

 create table Designation
 (
 designationID int primary key identity,
 designationName varchar(250)

 )
 go
 create table Teacher
 (
 teacherID int identity primary key,
 teacherName varchar(250),
 teacherAddress varchar(250),
 teacherEmail varchar(250),
 teacherContactNo bigint,
 CreditToBeTaken float,
 depCode nvarchar(250) foreign key references Department,
 DesignationID int foreign key references Designation

 )
 go 
 
 create table CourseAssign
 (
 cAssign int identity primary key,
depCode nvarchar(250) foreign key references Department,
TeacherID int foreign key references Teacher,
CourseID int foreign key references Course,
Assign bit not null default 1
 )

 go


  create table Student
  (
  studentID int identity(1000,1) primary key,
  studentName varchar(250),
  studentEmail varchar(250),
  studentContactNo bigint,
  regDate datetime ,
  studentAddress varchar(250),
  depCode nvarchar(250) foreign key references Department,
  CurrentYear varchar(250) not null default  cast(Datepart(year,getdate()) as varchar(250)),
  RegistrationNo as (depCode+'-'+CAST(CurrentYear as nvarchar(10))+'-'+CAST(studentID as nvarchar(20)))PERSISTED
  )

  go
   

   create table Room
   (
 roomID int primary key identity,
 roomName varchar(250)

   )

   go

   create table AllotedDays
   (
 dayID int primary key identity,
 daysName varchar(250)

   )

   go

   create table AllotedRoom
   (
   allotedRoomID int primary key identity,
   depCode nvarchar(250) foreign key references Department,
   CourseID int foreign key references Course,
   roomID int foreign key references Room,
   dayID int foreign key references AllotedDays,
   fromTime varchar(250) ,
   toTime varchar(250),
   Assign bit not null default 1
   )

   go

   create table StudentEnrolledCourse

   (
   enrolledID int identity primary key,
   StudentID int foreign key references Student,
   CourseID int foreign key references Course,
   enrolledDate datetime
   )

   go


   create table Grades
   (
  gradeID int primary key identity,
  gradeLetter varchar(250)

   )

   go

   create table Results
   (
   resultID int identity primary key,
   StudentID int foreign key references Student,
  CourseID int foreign key references Course,
   gradeID int foreign key references Grades

   )
 
   go
  insert Grades(gradeLetter) Values('A+'),('A'),('A-'),('B+'),('B'),('B-'),('C+'),('C'),('D'),('F')
go
insert AllotedDays(daysName) values ('Saturday'),('Sunday'),('Monday'),('Tuesday'),('Wednesday'),('Thursday'),('Friday')
go
insert Room(roomName) values ('A-101'),('A-102'),('B-101'),('B-102'),('C-101')
go
insert Semester(SemesterName) Values ('First'), ('Second'), ('Third'), ('Fourth'), ('Fifth'), ('Sixth'), ('Seventh'), ('Eighth')
go
insert Designation(designationName) values ('Professor'),('Associate Professor'),('Assistant Professor'),('Lecturer')


select * from Department

select * from Course

select * from [dbo].[CourseAssign]

 select * from Student

 select * from StudentEnrolledCourse

  select * from AllotedRoom

  select * from Results

    select * from Designation

  