Do projektu użyto następujące NuGet-y:
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.UI
- Microsoft.AspNetCore.Session - dodatkowo zainstalowany
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Newtonsoft.Json - dodatkowo zainstalowny 

Aby uruchomić projekt należy:
- sprawdzić, czy podane wyżej NuGet-y są zainstalowane w projekcie (Projekt -> Zarządzaj pakietami NuGet..). 
  Jeżeli jakiegoś brakuje, należy go zainstalować
- W konsoli menadżera pakietów użyć "Update-Database", aby zaimplementować strukturę bazy danych

Projekt został wykonany na trybie uwierzytelniania "Pojedyńcze konta".
