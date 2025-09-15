# WpfSolarSystem

## Beskrivelse
Dette project er lavet af Louise og Allan.

Du kan se hvordan projektet ser ud med threading_timer i branchen Threading_Timer, dette er lavet af Allan.

Du kan se også se hvordan det er lavet med DispatchTimer i branchen DispatchTimer som er lavet af Louise.

## Threading_Timer
### Fordele
- Kan have have flere workers kørende sammentidigt som kan lave hver deres opgave
- Rigtig godt til at udregne ting som ikke nødvendigvis skal opdatere UI
### Ulemper
- Workers skal fortælle UI thread at den kan opdatere UI
- Skal splitte koden ud i flere metoder for at workers kan køre dem og UI køre noget andet

## DispatchTimer
### Fordele
- Køre direkte på UI thread så kan hele tiden opdatere UI
### Ulemper
- Kan ikke køre flere ting af gangen
- UI thread har egen prioriterings rækkefølge, DispatchTimer opdateres først, når andet vigtigere er udført, dermed kan opdateringen af hvornår DispatchTimer kan få lov at opdatere udskydes, hvilket vil føre til lack i UI.
