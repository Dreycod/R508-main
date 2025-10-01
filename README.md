# 📦 Configuration de la Base de Données

Ce projet utilise **Entity Framework Core** avec une base de données **PostgreSQL**.  
Avant de lancer l'application, veuillez suivre les étapes ci-dessous pour configurer correctement la base de données.

---

## 🛠 Prérequis

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- PostgreSQL installé et configuré localement

---

## 🧱 Étapes pour configurer la base de données

### 1. 🔧 Installer l'outil Entity Framework

Avant d'utiliser les commandes `dotnet ef`, vous devez installer l'outil CLI :

dotnet tool install --global dotnet-ef --version 8.0.11


> ⚠️ Assurez-vous d’avoir la version 8.0.11 pour correspondre au projet.

---

### 2. 🐘 Créer une base de données PostgreSQL

Créez une base de données nommée `AppDB` dans votre instance PostgreSQL.

**Exemple avec `psql` :**

CREATE DATABASE "AppDB";

> Vous pouvez aussi utiliser pgAdmin ou un autre outil pour créer la base.

---

### 3. ⬆️ Appliquer les migrations EF Core

Une fois la base créée, appliquez les migrations Entity Framework à la base :

dotnet ef database update --project App

Cela va créer les tables dans `AppDB` selon les modèles définis dans le projet.

---

## 🔗 Exemple de chaîne de connexion (appsettings.json)

Assurez-vous que le fichier `appsettings.json` contient la bonne chaîne de connexion. Voici un exemple :

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=AppDB;Username=postgres;Password=VotreMotDePasse"
}

✅ C’est tout !

