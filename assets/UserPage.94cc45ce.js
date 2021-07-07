import{d as e,r as l,M as a,m as t,n as o,e as s,K as u,o as r,c as n,a as d,w as c,L as i,F as v,f as p,I as m,J as h,t as g,b}from"./vendor.59486093.js";import{r as w,a as f}from"./index.a0ab63f0.js";import{s as U}from"./main.fc5c0ef5.js";const C=e({setup(){const e=l(null),s=l([]),u=l(null),r=l(!1),n=l(!1),d=l(!1),c=l("ADD"),i=l([]),v=l([]),p=l([]),m=l(0),h=l(""),g=l(""),b=l(""),C=l(""),x=l(""),y=l(""),k=l(""),I=l([]),P=l([]),D=l("");function A(){r.value=!0,w({url:f.getAllUser.url,method:f.getAllUser.method}).then((l=>{200===l.Code?e.value=l.Data:(null!=u.value&&u.value.close(),u.value=t({message:"数据获取失败",type:"error",showClose:!0})),r.value=!1})).catch((e=>{console.log(e),r.value=!1}))}function L(){w({url:f.getAllPower.url.replace("/{id}",""),method:f.getAllPower.method}).then((e=>{200===e.Code&&(i.value=e.Data)})).catch((e=>{console.log(e)}))}function R(){w({url:f.getAllDepartment.url,method:f.getAllDepartment.method}).then((e=>{200===e.Code&&(v.value=e.Data)})).catch((e=>{console.log(e)}))}function S(){w({url:f.getAllRole.url,method:f.getAllRole.method}).then((e=>{200===e.Code&&(p.value=e.Data)})).catch((e=>{console.log(e)}))}function V(e,l){w({url:f.getPowerToRole.url.replace("{id}",e),method:f.getPowerToRole.method}).then((e=>{200===e.Code&&(e.Data.forEach((e=>{I.value.push(e.PowerId)})),l.split(" ").forEach((e=>{P.value.push(e)})),I.value=U(I.value),P.value=P.value.concat(I.value),P.value=P.value.filter((e=>e&&e.trim())))})).catch((e=>{console.log(e)}))}function T(){d.value=!1,h.value="",g.value="",b.value="",C.value="",x.value="",y.value="",k.value="",I.value.length=0,P.value.length=0}return a(P,((e,l)=>{var a=[];e.forEach((e=>{I.value.forEach((l=>{e!=l&&a.push(e)}))}));var t="";a.forEach((e=>{t+=e,t+=" "})),D.value=t.substring(0,t.length-1)})),{userList:e,multipleSelection:s,tipBox:u,dialogVisible:d,dialogType:c,powerAllList:i,departmentList:v,roleList:p,userId:m,roleId:h,departmentId:g,userAccount:b,userPwd:C,userRealName:x,userSex:y,userPhone:k,userPowerList:D,userPowerListArray:P,rolePowerListArray:I,loading:r,selectLoading:n,getData:A,getPower:L,getDepartmentList:R,getRoleList:S,getUserPower:V,setSelected:function(e){n.value=!0,i.value.forEach((e=>{I.value.forEach((l=>{e.PowerId===l&&(e.disabled=!0)}))})),n.value=!1},selectedChange:function(e){s.value.length=0,e.forEach((e=>{s.value.push(e.UserId)}))},handleClose:function(e){T(),e()},dialogClose:T,addUser:function(){w({url:f.createUser.url,method:f.createUser.method,data:{RoleId:h.value,DepartmentId:g.value,UserId:m.value,UserAccount:b.value,UserPwd:C.value,UserRealName:x.value,UserSex:y.value,UserPhone:k.value,UserPowerList:D.value}}).then((e=>{null!=u.value&&u.value.close(),200===e.Code&&!0===e.Data?u.value=t({message:"添加成功",type:"success",showClose:!0}):u.value=t({message:"添加失败",type:"error",showClose:!0}),A()})).catch((e=>{null!=u.value&&u.value.close(),u.value=t({message:"添加失败",type:"error",showClose:!0}),console.log(e)})),T()},addClick:function(){R(),S(),L(),c.value="ADD",d.value=!0},editUser:function(){w({url:f.updateUser.url.replace("{id}",h.value),method:f.updateUser.method,data:{RoleId:h.value,DepartmentId:g.value,UserId:m.value,UserAccount:b.value,UserRealName:x.value,UserSex:y.value,UserPhone:k.value,UserPowerList:D.value}}).then((e=>{null!=u.value&&u.value.close(),200===e.Code?u.value=t({message:"修改成功",type:"success",showClose:!0}):u.value=t({message:"修改失败",type:"error",showClose:!0}),A()})).catch((e=>{null!=u.value&&u.value.close(),u.value=t({message:"修改失败",type:"error",showClose:!0}),console.log(e)})),T()},editClick:function(e){R(),S(),V(e.RoleId,e.UserPowerList),L(),h.value=e.RoleId,g.value=e.DepartmentId,b.value=e.UserAccount,x.value=e.UserRealName,y.value=e.UserSex,k.value=e.UserPhone,c.value="EDIT",d.value=!0},toggleState:function(e){w({url:f.updateUserToStatus.url.replace("{id}",e.UserId).replace("{status}",!e.UserStatus),method:f.updateUserToStatus.method}).then((e=>{200===e.Code?A():(null!=u.value&&u.value.close(),u.value=t({message:"修改失败",type:"error",showClose:!0}))})).catch((e=>{console.log(e)}))},removeClick:function(e){o.confirm("确定删除该用户？","提示",{confirmButtonText:"确定",cancelButtonText:"取消",type:"warning"}).then((()=>{w({url:f.deleteUser.url.replace("{id}",e.UserId),method:f.deleteUser.method}).then((e=>{null!=u.value&&u.value.close(),200===e.Code?u.value=t({message:"删除成功",type:"success",showClose:!0}):u.value=t({message:"删除失败",type:"error",showClose:!0}),A()})).catch((e=>{console.log(e)}))})).catch((()=>{}))},removeAll:function(){o.confirm("确定删除所选用户？","提示",{confirmButtonText:"确定",cancelButtonText:"取消",type:"warning"}).then((()=>{var e=[];s.value.forEach((l=>{e.push(l)})),w({url:f.deleteMultipleUser.url,method:f.deleteMultipleUser.method,data:{RoleId:e}}).then((e=>{null!=u.value&&u.value.close(),u.value=t({message:"成功删除"+e.Data.count+"条记录",type:"success",showClose:!0}),A()})).catch((e=>{console.log(e),null!=u.value&&u.value.close(),u.value=t({message:"删除失败",type:"error",showClose:!0})}))})).catch((()=>{}))}}},beforeMount(){this.getData()}}),x={class:"px-20 py-10"},y={class:"grid grid-cols-1 md:grid-cols-3 pb-10 mr-1 grid-rows-1 justify-items-center"},k=d("div",null,null,-1),I=d("h1",{class:"text-2xl "},"用户管理",-1),P={class:"md:space-x-8 justify-self-end"},D=d("i",{class:"el-icon-plus"},null,-1),A=b(" 添 加 "),L=d("i",{class:"el-icon-refresh-left"},null,-1),R=b(" 刷 新 "),S={class:"mx-20 flex w-4/6"},V={class:"w-2/5"},T={class:"w-2/5 ml-10"},N={class:"mx-20 mt-2"},E={class:"float-left"},_={class:"float-right text-blue-400"},j={class:" space-x-5"},B={class:""},M={class:"mt-5"};C.render=function(e,l,a,t,o,b){const w=s("el-option"),f=s("el-select"),U=s("el-dialog"),C=s("el-table-column"),F=s("el-table"),J=u("loading");return r(),n("div",x,[d("div",y,[k,I,d("div",P,[d("button",{class:"btn bg-green-400 ring-green-400",onClick:l[1]||(l[1]=(...l)=>e.addClick&&e.addClick(...l))},[D,A]),d("button",{class:"btn bg-blue-400 ring-blue-400",onClick:l[2]||(l[2]=(...l)=>e.getData&&e.getData(...l))},[L,R])]),d(U,{"model-value":e.dialogVisible,title:"用户信息",width:"30%","before-close":e.handleClose,top:"20vh"},{footer:c((()=>[d("span",j,[d("button",{class:"btn-online hover:text-blue-400 hover:bg-blue-100 hover:border-blue-300",onClick:l[12]||(l[12]=(...l)=>e.dialogClose&&e.dialogClose(...l))},"取 消"),"ADD"===e.dialogType?(r(),n("button",{key:0,class:"btn bg-blue-400 ring-blue-400",onClick:l[13]||(l[13]=(...l)=>e.addUser&&e.addUser(...l))},"确 定")):i("",!0),"EDIT"===e.dialogType?(r(),n("button",{key:1,class:"btn bg-blue-400 ring-blue-400",onClick:l[14]||(l[14]=(...l)=>e.editUser&&e.editUser(...l))},"确 定")):i("",!0)])])),default:c((()=>[d("div",null,[d("div",S,[d("div",V,[d(f,{modelValue:e.departmentId,"onUpdate:modelValue":l[3]||(l[3]=l=>e.departmentId=l),placeholder:"请选择部门"},{default:c((()=>[(r(!0),n(v,null,p(e.departmentList,(e=>(r(),n(w,{key:e.DepartmentId,label:e.DepartmentName,value:e.DepartmentId},null,8,["label","value"])))),128))])),_:1},8,["modelValue"])]),d("div",T,[d(f,{modelValue:e.roleId,"onUpdate:modelValue":l[4]||(l[4]=l=>e.roleId=l),placeholder:"请选择角色"},{default:c((()=>[(r(!0),n(v,null,p(e.roleList,(e=>(r(),n(w,{key:e.RoleId,label:e.RoleName,value:e.RoleId},null,8,["label","value"])))),128))])),_:1},8,["modelValue"])])]),m(d("input",{type:"text",class:"input-box mx-20 w-4/6","onUpdate:modelValue":l[5]||(l[5]=l=>e.userAccount=l),placeholder:"用户名"},null,512),[[h,e.userAccount]]),"ADD"===e.dialogType?m((r(),n("input",{key:0,type:"password",class:"input-box mx-20 w-4/6","onUpdate:modelValue":l[6]||(l[6]=l=>e.userPwd=l),placeholder:"密 码"},null,512)),[[h,e.userPwd]]):i("",!0),m(d("input",{type:"text",class:"input-box mx-20 w-4/6","onUpdate:modelValue":l[7]||(l[7]=l=>e.userRealName=l),placeholder:"真实姓名"},null,512),[[h,e.userRealName]]),m(d("input",{type:"text",class:"input-box mx-20 w-4/6","onUpdate:modelValue":l[8]||(l[8]=l=>e.userSex=l),placeholder:"性 别"},null,512),[[h,e.userSex]]),m(d("input",{type:"number",class:"input-box mx-20 w-4/6","onUpdate:modelValue":l[9]||(l[9]=l=>e.userPhone=l),placeholder:"电 话"},null,512),[[h,e.userPhone]]),d("div",N,[d(f,{modelValue:e.userPowerListArray,"onUpdate:modelValue":l[10]||(l[10]=l=>e.userPowerListArray=l),multiple:"",onFocus:l[11]||(l[11]=l=>e.setSelected(e.event)),loading:e.selectLoading,placeholder:"请选择权限"},{default:c((()=>[(r(!0),n(v,null,p(e.powerAllList,(e=>(r(),n(w,{key:e.PowerId,label:e.PowerName,value:e.PowerId,disabled:e.disabled},{default:c((()=>[d("span",E,g(e.PowerName),1),d("span",_,g(e.PowerId),1)])),_:2},1032,["label","value","disabled"])))),128))])),_:1},8,["modelValue","loading"])])])])),_:1},8,["model-value","before-close"])]),d("div",B,[m(d(F,{data:e.userList,border:"","empty-text":"暂无数据",onSelectionChange:e.selectedChange,style:{margin:"0 auto",width:"100%"}},{default:c((()=>[d(C,{type:"selection",width:"50"}),d(C,{prop:"UserId",label:"用户编号",width:"100"}),d(C,{prop:"DepartmentName",label:"所属部门"}),d(C,{prop:"RoleName",label:"角 色"}),d(C,{prop:"UserAccount",label:"用户名"}),d(C,{prop:"UserRealName",label:"真实姓名"}),d(C,{prop:"UserSex",label:"性 别"}),d(C,{prop:"UserPhone",label:"电 话"}),d(C,{prop:"UserStatus",label:"状 态",width:"200"},{default:c((l=>[l.row.UserStatus?(r(),n("span",{key:0,class:"text-green-400 link select-none",onClick:a=>e.toggleState(l.row)},"正常",8,["onClick"])):(r(),n("span",{key:1,class:"text-red-400 link select-none",onClick:a=>e.toggleState(l.row)},"禁用",8,["onClick"]))])),_:1}),d(C,{label:"操作",width:"150"},{default:c((l=>[d("span",{class:"text-indigo-400 link select-none",onClick:a=>e.editClick(l.row)},"编辑",8,["onClick"]),d("span",{class:"text-red-400 link select-none",onClick:a=>e.removeClick(l.row)},"删除",8,["onClick"])])),_:1})])),_:1},8,["data","onSelectionChange"]),[[J,e.loading]]),d("div",M,[d("button",{class:"btn-online hover:bg-red-100 hover:border-red-300 hover:text-red-400",onClick:l[15]||(l[15]=(...l)=>e.removeAll&&e.removeAll(...l))}," 删除所有选择项 ")])])])};export default C;