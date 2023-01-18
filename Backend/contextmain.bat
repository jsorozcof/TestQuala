cd src\Data\TestQuala.Data
dotnet ef dbcontext scaffold "Server=tcp:ins-dllo-test-01.public.33e082952ab4.database.windows.net,3342;Initial Catalog=TestDB;Persist Security Info=False;User ID=prueba;Password=pruebaconcepto;" Microsoft.EntityFrameworkCore.SqlServer -t dbo.Moneda -t dbo.Moneda_Sucursal -f -o Models -c ContextMain
cd..

:: Exec ./contextmain.bat