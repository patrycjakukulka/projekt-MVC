1. Instalacje:
-  Visual Studio 2022
- .NET SDK
- SQL Server Management Studio
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFramWaorkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

2. Połączenie z bazą:
"ConnectionStrings": {
    "PlatformaDbConnectionString": "Server=DESKTOP-P9M5G9O; Database=platformDb;Trusted_Connection=True;TrustServerCertificate=Yes",
    "PlatformaAuthDbConnectionString": "Server=DESKTOP-P9M5G9O; Database=platformDb;Trusted_Connection=True;TrustServerCertificate=Yes"

3. Opis działania i hasła
Użytkownik (anonimowy):
Użytkownik bez konieczności logowania ma dostęp do listy postów, co pozwala mu zapoznać się z treściami i informacjami publikowanymi na platformie. Jednak aby uzyskać pełen zakres funkcji, takich jak przeglądanie listy dostępnych zwierząt, musi utworzyć konto i zalogować się.

a) Użytkownik Zalogowany:
    Po pomyślnym zalogowaniu się na platformę przy użyciu poniższych danych:
    Login: user24
    Hasło: !QAZ2wsx
    Użytkownik ma dostęp do pełnej funkcjonalności platformy, w tym przeglądania listy dostępnych zwierząt oraz listy postów. 
    Administrator:
    Po zalogowaniu się na konto administratora przy użyciu poniższych danych:
    Login: admin@platforma.com
    Hasło: admin@123


b) Administrator posiada uprawnienia umożliwiające zarządzanie treściami na platformie. Ma możliwość:

    •Zarządzania Zwierzętami:
   - Dodawania nowych zwierząt do bazy danych.
   - Przeglądania listy istniejących zwierząt.
   - Edytowania danych zwierząt, w tym zmiany opisu, itp.
   - Usuwania zwierząt z bazy danych.

    •Zarządzania Postami:
    -Dodawania nowych postów na platformę.
    - Przeglądania listy istniejących postów.
    -  Edytowania treści, tytułu w postach.
     - Usuwania postów z platformy.

    •Podglądu Strony z Perspektywy Użytkownika:
     - Przeglądania treści dostępnych dla użytkowników anonimowych.
     - Sprawdzania, jak platforma wygląda dla standardowego użytkownika.

 
