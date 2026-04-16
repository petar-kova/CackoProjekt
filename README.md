# CackoProjekt (ASP.NET Core MVC)

## Pokretanje projekta

Ako dobiješ grešku `NETSDK1004: project.assets.json not found`, to znači da **NuGet restore nije odrađen**.

### Brzi fix (terminal)

```bash
dotnet restore CackoProjekt.csproj
dotnet build CackoProjekt.csproj
dotnet run --project CackoProjekt.csproj
```

### Visual Studio fix

1. Desni klik na solution/projekt → **Restore NuGet Packages**.
2. Provjeri da je startup projekt: **CackoProjekt**.
3. Buildaj ponovno.

Ako i dalje javlja isti problem:

```bash
rmdir /s /q bin obj
dotnet restore
dotnet build
```

## Startup profile

`launchSettings.json` već sadrži `http` i `https` profile.
Odaberi `CackoProjekt` kao Startup Project i pokreni aplikaciju.
