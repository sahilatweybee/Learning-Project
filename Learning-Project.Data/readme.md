# Scaffold Command

```
Scaffold-DbContext <Connection-String>
  -Provider <ProviderName (Microsoft.EntityFrameworkCore.SqlServer)>
  -OutputDir <Output-Directory (Models)>
  -ContextDir <Output-Directory-For-DbContext (Contexts)>
  -Context <Name-Of-The-DbContext-Class/File (AppDbContext)>
  -DataAnnotations (To use attributes where possible)
Optionals:
  -Schemas <Array-Of-Schema-Names-Comma-Separated>
  -Tables <Array-Of-Table-Names-Comma-Separated>
  -UseDatabaseNames (Use table and column names exactly as they appear in the database and Not The Pascal Case)
-Force
```
