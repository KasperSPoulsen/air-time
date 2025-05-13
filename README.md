# AirTime

**AirTime** er et full-stack system udviklet i C# med en trelagsarkitektur (GUI, Business Logic Layer og Data Access Layer). Systemet er designet til at administrere springere i en trampolinklub og blev udviklet som et studieprojekt af en gruppe datamatikerstuderende på Erhvervsakademi Aarhus.

## 🧩 Funktioner

- **Springeradministration**: Opret, rediger og slet springerprofiler.
- **Holdstyring**: Tildel springere til forskellige hold og trænere.
- **Konkurrenceplanlægning**: Organiser og planlæg konkurrencer.
- **Statistik og rapportering**: Generér rapporter over springeraktivitet og fremmøde.

## 🛠️ Teknologier anvendt

- **Frontend**: WPF (Windows Presentation Foundation)
- **Backend**: C# (.NET Framework)
- **Datatilgang**: Entity Framework
- **Dataoverførsel**: Data Transfer Object (DTO) mønster
- **Database**: SQL Server
- **Test**: Unit tests implementeret i `TestProjekt`
- **Arkitektur**: Tre-lags arkitektur (GUI, BLL, DAL)
- **Udviklingsmetodologi**: Scrum

## 📁 Projektstruktur

- `WpfApp1/`: GUI-applikationen udviklet i WPF.
- `BusinessLogicLayer/`: Indeholder forretningslogikken.
- `DataAccessLayer/`: Håndterer databaseadgang via Entity Framework.
- `DataTransferObject/`: Indeholder DTO-klasser til dataoverførsel mellem lagene.
- `TestProjekt/`: Indeholder unit tests for at sikre kodekvalitet.

## 🚀 Kom godt i gang

1. **Klon repository**:
   ```bash
   git clone https://github.com/KasperSPoulsen/air-time.git
   ```

2. **Åbn løsningen**:
   Åbn `AirTimeSolution.sln` i Visual Studio.

3. **Konfigurer database**:
   - Sørg for, at SQL Server er installeret og kører.
   - Opdater forbindelsesstrengen i `App.config` eller `appsettings.json` med dine databaseoplysninger.

4. **Kør applikationen**:
   Start projektet fra Visual Studio for at køre WPF-applikationen.



