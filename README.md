# test

Creare la TDipendenti con i seguenti campi (scegliere i tipi di dati adatti)
DipendenteID
Cognome
Nome
DataNascita
Sesso
ComuneNascita
ProvinciaNascita
Email

Caricare 3 Dipendenti (ComuneNascita e ProvinciaNascita devono essere presenti nella tabella successiva)

Creare la TComuni con i seguenti campi (scegliere i tipi di dati adatti):
ComuneID
Comune
Provincia
CodiceCatastale

Inserire 3 righe utili per i 3 dipendenti della TDipendenti.
ComuneID
COMUNE
PROVINCIA
CODICE CATASTALE
1
PADOVA
PD
G224
2
VICENZA
VI
L840
3
TREVISO
TV
L407

Creare un nuovo progetto Visual studio API web .net core
Creare Controller Dipendenti e le seguenti chiamate:
HttpGet: restituisce la lista di tutti i dipendenti
HttpGet: restituisce un solo dipendente tramite invio DipendenteID. Se il DipendenteID non esiste lo comunica
HttpPost: Inserimento di un nuovo dipendente inviato tramite post
HttpDelete: eliminazione dipendente tramite invio DipendenteID. Se il DipendenteID non esiste lo comunica
HttpPut: aggiornamento della Email del Dipendente tramite invio del DipendenteID e della nuova Email. Se il DipendenteID non esiste lo comunica
HttpGet: restituisce il CodiceFiscale del Dipendente inviato tramite DipendenteID. Se il DipendenteID non esiste lo comunica

Nelle chiamate che ricevono dati implementare i test di obbligatorietà dei dati (per esempio la numero 2.3 deve ricevere dati non vuoti altrimenti comunica un messaggio di errore nel Response)

Zippare la cartella della soluzione in un unico file CognomeNome.zip e inviarlo a <roberto.luongo@itsdigitalacademy.com> tramite wetransfer.com

# how to run

**requirement**
make
docker
docker-compose

env file

make dev (will dotnet restore, set db etc)
