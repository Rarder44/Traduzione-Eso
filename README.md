# Traduzione Eso
Questo progetto è pensato per cercare di tradurre un minimo di UI di ESO.

Basandoci sull'addon Portoghese, si possono modificare i file lua ( br_pregame.lua , br_client.lua  ) per ottenere una prima traduzione Italiana


Per installare l'addon portoghese occorre:

- scaricare il file zip dalla seguente pagina http://www.esoui.com/downloads/info1031-TraduoPortugusBR.html
- estrarre tutto il contenuto nella cartella C:\Users\NOME_UTENTE\Documents\Elder Scrolls Online\liveeu\AddOns\
- (avere cosi i seguenti percorsi:
      ...\Documents\Elder Scrolls Online\liveeu\AddOns\Cervanteso\
      ...\Documents\Elder Scrolls Online\liveeu\AddOns\EsoUI\
      ...\Documents\Elder Scrolls Online\liveeu\AddOns\gamedata\
  )
- modificare il file C:\Users\NOME_UTENTE\Documents\Elder Scrolls Online\liveeu\UserSettings.txt la stringa:
	SET Language.2 "en"
	in
	SET Language.2 "br"
	
- Occorre avviare il gioco SENZA passare dal launcher! ( avviarlo dall'eseguibile: 
	CARTELLA_INSTALLAZIONE_ESO\The Elder Scrolls Online EU\game\client\eso.exe )
	questo perchè il launcher va a resettare la lingua "en" che abbiamo cambiato prima
	
- Controllare che la lingua sia cambiata.

- Se è tutto corretto ci possiamo spostare nella cartella 
	C:\Users\NOME_UTENTE\Documents\Elder Scrolls Online\liveeu\AddOns\EsoUI\lang\
  dove troviamo i due file lua ( l'oggetto di questo progetto ) contenente tutte le stringhe
  
  basterà modificarli ( o sovrascriverli con i "nostri" ) per avere una traduzione parziale dell'interfaccia
