# M06_APICompteBancaire

## Description

Le projet **M06_APICompteBancaire** est une application de gestion de comptes bancaires. Il est conçu pour permettre la création, la mise à jour et la gestion des comptes bancaires et des transactions associées. Le projet utilise une architecture modulaire avec plusieurs couches, notamment une couche d'accès aux données (DAL), une couche métier (BL), et une API Web pour l'interaction avec les utilisateurs ou d'autres systèmes.

## Architecture du Projet

Le projet est organisé en plusieurs modules :

- **M06_Entite** : Contient les entités principales du domaine, telles que `CompteBancaire`, qui représentent les objets métiers.
- **M06_MessageBancaire** : Définit les messages échangés entre les différentes couches ou systèmes, comme `MessageCompteBancaire`.
- **M06_DAL_SQLServeur** : Implémente la couche d'accès aux données, avec des classes comme `DepotCompteBancaire` pour interagir avec la base de données SQL Server.
- **M06_BLCompteBancaire** : Contient la logique métier, avec des classes comme `ManipulationCompteBancaire` pour gérer les opérations sur les comptes bancaires.
- **TraitementCreationsModfifcations** : Module pour le traitement des messages RabbitMQ liés à la création et à la modification des comptes bancaires et des transactions.
- **Web_API_compteBancaire** : Fournit une API REST pour interagir avec le système.

## Fonctionnalités

- **Gestion des comptes bancaires** :
  - Création de comptes bancaires.
  - Mise à jour des comptes bancaires.
  - Récupération des informations des comptes bancaires.

- **Gestion des transactions** :
  - Création de transactions.
  - Mise à jour des transactions.

- **Communication via RabbitMQ** :
  - Utilisation de RabbitMQ pour la gestion des messages entre les différents modules.

## Prérequis

- **.NET 8.0** : Le projet est développé avec .NET 8.0.
- **SQL Server** : Base de données utilisée pour stocker les informations des comptes bancaires.
- **RabbitMQ** : Utilisé pour la communication entre les modules.
- **Visual Studio 2022** ou supérieur : Recommandé pour le développement.

## Installation

1. Clonez le dépôt :
   ```bash
   git clone <url-du-repo>
   cd M06_APICompteBancaire
