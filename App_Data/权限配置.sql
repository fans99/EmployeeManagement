--��ʼ��֮ǰ��Ҫ��յı�����
truncate table EmPower
--һ��Ȩ��
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('001','','����Ȩ��','����Ȩ��','/test',2,'����Ȩ��')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999','','ϵͳ����','ϵͳ����','/system',1,'ϵͳ����')
--����Ȩ��--ϵͳ����
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999001','999','���Ź���','���Ź���','/system/department',1,'���Ź���')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999002','999','��ɫ����','��ɫ����','/system/role',2,'��ɫ����')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999003','999','�û�����','�û�����','/system/user',3,'�û�����')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999004','999','��־����','��־����','/system/log',4,'��־����')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999005','999','��������','��������','/space',5,'��������')

--����Ȩ��--��־����
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999004001','999004','��¼��־','��¼��־','/system/log/action',1,'��¼��־')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999004002','999004','�쳣��־','�쳣��־','/system/log/exception',2,'�쳣��־')

--����Ȩ��--��������
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999005001','999005','������Ϣά��','������Ϣά��','/space/profile',1,'������Ϣά��')
insert into EmPower(PowerId,MotherId,PowerName,MenuName,PowerPage,PowerOrder,PowerRemark)
values('999005002','999005','����ά��','����ά��','/space/password',2,'����ά��')

select * from EmPower