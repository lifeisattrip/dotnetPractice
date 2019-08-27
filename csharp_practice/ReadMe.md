add-migration  init
script-migration
update-database

unique constrains on multiple columns
modelBuilder.Entity<Person>().HasIndex(p => new { p.FirstName, p.LastName }).IsUnique(true);

m-m
https://docs.microsoft.com/zh-cn/ef/core/modeling/relationships


