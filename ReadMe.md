## EFCore

### 命令

﻿add-migration  init
script-migration
update-database

### 非PM环境下命令
dotnet ef migrations add 
dotnet ef database update


### 多表关联配置

unique constrains on multiple columns
modelBuilder.Entity<Person>().HasIndex(p => new { p.FirstName, p.LastName }).IsUnique(true);

m-m
https://docs.microsoft.com/zh-cn/ef/core/modeling/relationships

### 数据分页

page
https://www.codingame.com/playgrounds/5363/paging-with-entity-framework-core

## Authorization

### 实现多权限点控制的认证

how to do Authorization
https://github.com/derekgreer/authorize-example/tree/master/src/Examples.Authorization
https://stackoverflow.com/questions/31464359/how-do-you-create-a-custom-authorizeattribute-in-asp-net-core

### 如何添加Identity到mvc项目

how to add identity to  mvc-project
https://timmydinheing.com/2018/04/11/adding-asp-net-identity-2-0-into-existing-mvc-project/

https://docs.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-2.2

## asp .net

