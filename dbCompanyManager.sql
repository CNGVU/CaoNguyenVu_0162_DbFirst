create database dbCompanyManagerDBFirst
go
use  dbCompanyManagerDBFirst;
go 
create table Company
(
	CompanyId numeric(10,1) primary key,
	CompanyName nvarchar(250),
	CompanyDescription nvarchar(max),
	CompanyPhone varchar(13),
)
create table Department
(
	DepartmentId numeric(10,1) primary key,
	Departmentname nvarchar(250),
	QuantityStaff int ,
	CompanyId numeric(10,1) foreign key references Company(CompanyId)
)
create table Staff
(
	StaffId numeric(10,1) primary key,
	Staffname nvarchar(250),
	Gender nvarchar(5),
	Age int,
	Salary numeric(10,1),
	DepartmentId numeric(10,1) foreign key references Department(DepartmentId)
)