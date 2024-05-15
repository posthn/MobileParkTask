Для теста:
dotnet ef database update -c RecordsDbContext -p Records/Records.Data/Records.Data.csproj --connection "User ID=postgres;Password=*password*;Host=*host*;Port=*port*;Pooling=true;Database=MobileParkTask.Records;Minimum Pool Size=0;Maximum Pool Size=100;Connection Lifetime=0;"
