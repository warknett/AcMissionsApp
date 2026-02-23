# AcMissionsApp

Ce projet a été réalisé dans le cadre d’un exercice portant sur le développement d’une application ASP.NET MVC.  
L’objectif était de mettre en place un CRUD complet autour de missions inspirées de l’univers Assassin’s Creed, tout en respectant l’architecture MVC et en utilisant une base de données MySQL.

---

## 1. Objectifs du projet

- Manipuler l’architecture **ASP.NET MVC**
- Utiliser **Entity Framework Core** pour gérer les données
- Mettre en place un **CRUD complet**
- Gérer une base de données **MySQL**
- Structurer le code avec **Controllers**, **Services**, **Repository**, **Models**, **Views**
- Ajouter un champ supplémentaire (**Location**) et mettre à jour les différentes couches de l’application

---

## 2. Fonctionnalités développées

- Affichage de la liste des missions  
- Création d’une mission  
- Modification d’une mission  
- Suppression d’une mission  
- Consultation des détails d’une mission  
- Ajout du champ **Location** (lieu de la mission)  
- Gestion des données via Entity Framework Core  
- Migrations pour la création et la mise à jour de la base  

---

## 3. Technologies utilisées

- **ASP.NET Core MVC**
- **C#**
- **Entity Framework Core**
- **MySQL**
- **Bootstrap / Razor**
- **Visual Studio 2022**
- **Git / GitHub**

---

## 4. Installation et exécution

### a) Configuration de la base de données

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=acmissions;user=root;password=;"
}


Appliquer les migrations

dotnet ef database update

Lancer l’application
dotnet run

5. Structure du projet

Controllers/
Models/
Views/
Services/
Repository/
Data/
Migrations/
wwwroot/

6. Dernière modification importante
Ajout du champ Location

Mise à jour du Model, du Controller, du Service et des Views

Commit associé : “Fix: ajout du champ Location (Controller + Service)”

7. Auteur
Projet réalisé par Tom 
Dans le cadre d’un exercice ASP.NET MVC.


