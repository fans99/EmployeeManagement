--初始化之前需要清空的表数据
truncate table EmPower
--一级权限
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('001','','测试权限','测试权限','/test',2,'测试权限')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999','','系统管理','系统管理','/system',1,'系统管理')
--二级权限--系统管理
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999001','999','部门管理','部门管理','/system/department',1,'部门管理')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999002','999','角色管理','角色管理','/system/role',2,'角色管理')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999003','999','用户管理','用户管理','/system/user',3,'用户管理')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999004','999','日志管理','日志管理','/system/log',4,'日志管理')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999005','999','个人中心','个人中心','/space',5,'个人中心')

--三级权限--日志管理
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999004001','999004','登录日志','登录日志','/system/log/action',1,'登录日志')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999004002','999004','异常日志','异常日志','/system/log/exception',2,'异常日志')

--三级权限--个人中心
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999005001','999005','基本信息维护','基本信息维护','/space/profile',1,'基本信息维护')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999005002','999005','密码维护','密码维护','/space/password',2,'密码维护')

select * from EmPower