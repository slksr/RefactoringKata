# RefactoringKata

## Introductie

Deze oefening is deel van de DEA Course aan de Hogeschool Arnhem/Nijmegen. 
Onderwerp is ervaring opdoen met het herkennen van _bad smells_ en het kunnen
toepassen van _refactoring_.

## Oefening

In deze oefening zal je een bestaande codebase moeten refactoren. De oefening is gebaseerd
op [https://github.com/stanlylau/refactoring-kata](https://github.com/stanlylau/refactoring-kata) en betreft een code base vol _bad smells_.

De belangrijkste klasse is de `OrdersWriter`, die gebruikt kan worden om [JSON](https://www.json.org/) te genereren. Dit is een veel gebruikt formaat om data uit te wisselen. Ook binnen de .Net Gemeenschap wordt hier veelvuldig gebruik van gemaakt en er bestaan dan ook veel Libraries om automatisch [JSON](https://www.json.org/) te maken van C# Objecten. Voor deze oefening mogen
deze Libraries / Packages **niet** worden gebruikt.

Deze oefeningen kent geen expliciete stappen. Het is de bedoeling om __alle__ _bad smells_ te verwijderen. Gebruik hierbij zoveel mogelijk de short-cuts die de IDE (Visual Studio of Rider) biedt.

