# CackoProjekt

ASP.NET Core MVC web projekt sa Razor view-ovima i ViewModel klasama.

## Najbrži način (Windows)

1. Otvori `CackoProjekt.sln` u Visual Studio.
2. Desni klik na solution -> **Restore NuGet Packages**.
3. Postavi `CackoProjekt` kao Startup Project i pokreni.

Alternativa iz terminala:

```bat
build.bat
```

## CLI pokretanje

```bash
dotnet restore CackoProjekt.sln
dotnet build CackoProjekt.sln
dotnet run --project CackoProjekt.csproj
```

Ako dobiješ `NETSDK1004`, to znači da restore nije odrađen.
