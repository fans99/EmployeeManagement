create database EmployeeDB
go

use EmployeeDB

--����
CREATE TABLE EmDepartment
(
	DepartmentId varchar(50) primary key not null,--Id ���ű��
	MotherId varchar(50) null, --�������
	DepartmentName nvarchar(50) NULL,--��������
 )

--ϵͳ��ɫ
create table EmRole
(
	RoleId int primary key identity(1,1), --����
	RoleName nvarchar(100),  --��ɫ����
	RoleRemark text, --ϵͳ��ɫ����
	RolePowerList text,  -- ��ɫȨ���б�
	ReleaseTime smalldatetime default(getdate()) --��Ϣ���ʱ��
)

--ϵͳ�û�
create table EmUser
(
	UserId int primary key identity(1,1), --����
	DepartmentId varchar(50), --���ű�ţ�������벿�ű������
	RoleId int,  --��ɫ��ţ���������ɫ�������	
	UserAccount varchar(50) unique,  --�û���
	UserPwd varchar(50),   --����
	UserRealName nvarchar(50), --��ʵ����
	UserSex nvarchar(1), --�Ա�
	UserPhone nvarchar(50), --�û���ϵ�绰
	UserPowerList text, --�û�Ȩ���б�
	UserStatus bit default(1), --�û��Ƿ���ã�0Ϊ������,1Ϊ���ã�
	ReleaseTime smalldatetime default(getdate()) --��Ϣ���ʱ��
)

--ϵͳȨ��
create table EmPower
(
	PowerId varchar(50) primary key not null, --����
	MotherId varchar(50) null, --ĸ��Ȩ��
	PowerName nvarchar(50), --Ȩ������
	MenuName nvarchar(50), --�˵�����
	PowerPage nvarchar(100), --�˵������ӵ�ַ��*������ת�����幦��ҳ�棬������ת���¼��˵�չʾ��Ϣҳ�棩
	PowerOrder int null, --�˵�����
	PowerRemark text,  --Ȩ�ޱ�ע
)

--�쳣��Ϣ��
create table EmException
(
	ExceptionId int primary key identity(1,1), --����
	UserId int null,      --�û����
	ExceptionContent text null,  --�쳣����
	ExceptionTime smalldatetime null, --�쳣ʱ��
	ExceptionIp varchar(30) null,  --�쳣�ͻ���Ip
)

--��¼��־
create table EmLoginLog
(
	LoginLogId int primary key identity(1,1), --����
	Account nvarchar(100),  --�û���
	Pwd nvarchar(100), --����
	LoginIp varchar(30),--��¼IP
	LoginTime smalldatetime, --��¼ʱ��
	Result nvarchar(100), -- ��¼������ɹ���ʧ�ܣ�
)

--��ʼ����������Ա�Ľ�ɫ
insert into EmRole(RoleName,RoleRemark,RolePowerList)
values('��������Ա','���Ȩ�޵Ľ�ɫ','999')
--��ʼ����������Ա���ڵĲ���
insert into EmDepartment(DepartmentId,MotherId,DepartmentName)
values('001','','��Ϣ��')
--��ʼ����������Ա�˻�
insert into EmUser(DepartmentId,RoleId,UserAccount,UserPwd,UserRealName,UserSex,UserPhone,UserPowerList)
values('001',1,'admin','admin','����','��','15327304460','')

select * from EmRole
select * from EmDepartment
select * from EmUser