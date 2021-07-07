create database EmployeeDB
go

use EmployeeDB

--部门
CREATE TABLE EmDepartment
(
	DepartmentId varchar(50) primary key not null,--Id 部门编号
	MotherId varchar(50) null, --父级编号
	DepartmentName nvarchar(50) NULL,--部门名称
 )

--系统角色
create table EmRole
(
	RoleId int primary key identity(1,1), --主键
	RoleName nvarchar(100),  --角色名称
	RoleRemark text, --系统角色描述
	RolePowerList text,  -- 角色权限列表
	ReleaseTime smalldatetime default(getdate()) --信息添加时间
)

--系统用户
create table EmUser
(
	UserId int primary key identity(1,1), --主键
	DepartmentId varchar(50), --部门编号，外键（与部门表关联）
	RoleId int,  --角色编号，外键（与角色表关联）	
	UserAccount varchar(50) unique,  --用户名
	UserPwd varchar(50),   --密码
	UserRealName nvarchar(50), --真实姓名
	UserSex nvarchar(1), --性别
	UserPhone nvarchar(50), --用户联系电话
	UserPowerList text, --用户权限列表
	UserStatus bit default(1), --用户是否可用（0为不可用,1为可用）
	ReleaseTime smalldatetime default(getdate()) --信息添加时间
)

--系统权限
create table EmPower
(
	PowerId varchar(50) primary key not null, --主键
	MotherId varchar(50) null, --母级权限
	PowerName nvarchar(50), --权限名称
	MenuName nvarchar(50), --菜单名称
	PowerPage nvarchar(100), --菜单打开链接地址（*代表不跳转到具体功能页面，而是跳转到下级菜单展示信息页面）
	PowerOrder int null, --菜单排序
	PowerRemark text,  --权限备注
)

--异常信息表
create table EmException
(
	ExceptionId int primary key identity(1,1), --主键
	UserId int null,      --用户编号
	ExceptionContent text null,  --异常内容
	ExceptionTime smalldatetime null, --异常时间
	ExceptionIp varchar(30) null,  --异常客户端Ip
)

--登录日志
create table EmLoginLog
(
	LoginLogId int primary key identity(1,1), --主键
	Account nvarchar(100),  --用户名
	Pwd nvarchar(100), --密码
	LoginIp varchar(30),--登录IP
	LoginTime smalldatetime, --登录时间
	Result nvarchar(100), -- 登录结果（成功，失败）
)

--初始化超级管理员的角色
insert into EmRole(RoleName,RoleRemark,RolePowerList)
values('超级管理员','最高权限的角色','999')
--初始化超级管理员所在的部门
insert into EmDepartment(DepartmentId,MotherId,DepartmentName)
values('001','','信息科')
--初始化超级管理员账户
insert into EmUser(DepartmentId,RoleId,UserAccount,UserPwd,UserRealName,UserSex,UserPhone,UserPowerList)
values('001',1,'admin','admin','刘备','男','15327304460','')

select * from EmRole
select * from EmDepartment
select * from EmUser