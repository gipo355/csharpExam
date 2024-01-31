# TOC

<!--toc:start-->

- [todo](#todo)
- [test](#test)
- [how to run](#how-to-run)
<!--toc:end-->

# todo

- [ ] how to make fields required, unique, other props on db?
- [ ] don't show empty fields in response ( null, etc )
- [ ] add query params for Filtering - sorting etc
- [ ] set unique fields for email in DB
- [ ] use some variables for status codes
- [ ] convert all strings to lowercase on insert
- [ ] updating FK townID not working
- [ ] add hooks for Fiscal Code
- [ ] test all endpoints
- [ ] clean up code - refactor and DRY

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

codice fiscale:

3 consonanti cognome, nome , ultime 2 anno nascita, lettera mese nascita,2 cifre giorno nascita, codice catastale, carattere di controllo

# how to run

**requirements**

- [make](https://www.gnu.org/software/make/)
- [docker-compose](https://docs.docker.com/compose/install/)

0. clone the repo

   ```
   git clone https://github.com/gipo355/csharpExam/
   cd csharpExam
   ```

1. restore dependencies

   ```
   make restore
   ```

2. add env variables

   ```
   cp .env.default -> .env
   ```

3. start Docker

   ```
   make docker
   ```

4. Prepare the db

   ```
    make db-update
   ```

5. start the server:

   ```
   make dev
   ```
