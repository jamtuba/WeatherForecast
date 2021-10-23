[![.NET](https://github.com/jamtuba/WeatherForecast/actions/workflows/weatherFlow.yml/badge.svg)](https://github.com/jamtuba/WeatherForecast/actions/workflows/weatherFlow.yml)
# Vejrudsigten
Test - Uge 7 - Skab overskrifter ud fra vejrudsigten

### Opgave

1. En tekstuel specifikation af hvordan dit program opfører sig. Din specifikation skal dække, hvordan ændringer i vejret påvirker overskrifterne. Specifikationen skal skrives som prosa og være præcis nok til, at en anden vil kunne lave testcases ud fra det.

2. Et testdesign af hvordan du har testet din service. Dit testdesign skal som minimum indeholde en grænseværdianalyse og en beslutningstabel.

3. Din kode til løsning af opgaven samt unit-test som tester din løsning baseret på dit testdesign.

## Testcase:

For at kunne forudse hvilken påklædning man skal have på er det praktisk at kunne frekventere en vejrudsigt. 
I vejrudsigten har man mulighed for at få et hint om hvordan vejret er ved at udvikle sig fra igår til idag og videre frem.
Vejrudsigten bliver fundet ved hjælp af vejrdata fra et vejr-API som sender en temperatur og en vejrtype retur.
Ved at teste temperaturen og vejrtypen mod mine grænseværdier kommer programmet frem til nogle dynamiske overskrifter. 
Overskriften vil indeholde info om vejret skifter, samt hvordan det bliver i dag i Århus.

## Testdesign:

For at få koden til at virke har jeg tilføjet nogle metoder der opdeler API´ets informationer og beslutter hvad overskriften skal stykkes sammen af. Jeg har opdelt dette i flere metoder for nemmere at kunne teste det. For at kunne køre automatiserede tests med Github Actions er de danske æ, ø og å skiftet ud med ae, oe og aa.

Jeg har ikke testet nogen af de eksisterende metoder.

### Grænseværdianalyse:

Da der er mange forskellige temperaturer at tage udgangspunkt i er det de følgende jeg har brugt.
Jeg er nået frem til 5 ækvivalensklasser.

### Ækvivalensklasser:
  
![Vejrudsigt](https://user-images.githubusercontent.com/38835602/138444769-dc8b47db-50bc-47c0-ae42-a7a926676aa4.jpg)

Under det absolutte nulpunkt er en ugyldig klasse og over 100 grader celsius kan heller ikke anses relevant i denne sammenhæng.

### Beslutningstabel:

Det antal test der skal til for at fuld klassedækning er 5 x 5 x 2 = 50 testcases.
Dernæst er der et par scenarier der er temmelig usansynlige f. eks 30 grader og sne eller under -10 grader og regn. Så dem udelukker jeg også.
For at minimere antallet og sørge for at alle betingelser bliver berørt én gang i hver sektion kan vi nøjes med 5 testscenarier.

| Temperatur i grader celsius  | Vejrtype | Vejrændring siden i går? | Skal testes! |
| ------------- | ------------- | :---: | :---:|
| < -10  | Klart vejr  | + | + |
| < -10  | Regn | + | - |
| < -10  | Sne  | + | - |
| < -10  | Skyet  | + | - |
| < -10  | Andet  | + | - |
| < -10  | Klart vejr  | - | - |
| < -10  | Regn | - | - |
| < -10  | Sne  | - | - |
| < -10  | Skyet  | - | - |
| < -10  | Andet  | - | - |
| >= -10 < 0  | Klart vejr  | + | - |
| >= -10 < 0  | Regn  | + | - |
| >= -10 < 0  | Sne  | + | - |
| >= -10 < 0  | Skyet  | + | - |
| >= -10 < 0  | Andet  | + | - |
| >= -10 < 0  | Klart vejr  | - | - |
| >= -10 < 0  | Regn  | - | - |
| >= -10 < 0  | Sne  | - | + |
| >= -10 < 0  | Skyet  | - | - |
| >= -10 < 0  | Andet  | - | - |
| >= 0 < 15  | Klart vejr  | + | - |
| >= 0 < 15  | Regn  | + | + |
| >= 0 < 15  | Sne  | + | - |
| >= 0 < 15  | Skyet  | + | - |
| >= 0 < 15  | Andet  | + | - |
| >= 0 < 15  | Klart vejr  | - | - |
| >= 0 < 15  | Regn  | - | - |
| >= 0 < 15  | Sne  | - | - |
| >= 0 < 15  | Skyet  | - | - |
| >= 0 < 15  | Andet  | - | - |
| >= 15 < 30  | Klart vejr  | + | - |
| >= 15 < 30  | Regn  | + | - |
| >= 15 < 30  | Sne  | + | - |
| >= 15 < 30  | Skyet  | + | - |
| >= 15 < 30  | Andet  | + | - |
| >= 15 < 30  | Klart vejr  | - | - |
| >= 15 < 30  | Regn  | - | - |
| >= 15 < 30  | Sne  | - | - |
| >= 15 < 30  | Skyet  | - | + |
| >= 15 < 30  | Andet  | - | - |
| >= 30 < 100  | Klart vejr  | + | - |
| >= 30 < 100  | Regn  | + | - |
| >= 30 < 100  | Sne  | + | - |
| >= 30 < 100  | Skyet  | + | - |
| >= 30 < 100  | Andet  | + | + |
| >= 30 < 100  | Klart vejr  | - | - |
| >= 30 < 100  | Regn  | - | - |
| >= 30 < 100  | Sne  | - | - |
| >= 30 < 100  | Skyet  | - | - |
| >= 30 < 100  | Andet  | - | - |

For at dække mere kode har jeg desuden lavet tests der tjekker for null og "", samt invalidt input f.eks. "Sol". 
Er lidt i tvivl om de egentlig er nødvendige ud fra de givne kriterier, mere 'nice to have'.
