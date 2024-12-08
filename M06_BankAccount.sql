use Master;

create database M06_BankAccount;

USE M06_BankAccount;
GO

CREATE TABLE CompteBancaire 
(
    CompteBancaireId UNIQUEIDENTIFIER PRIMARY KEY,
    TypeCompte VARCHAR(10) NOT NULL CHECK (TypeCompte = 'courant')
  
);
GO

CREATE TABLE Transactions 
(
    TransactionId UNIQUEIDENTIFIER PRIMARY KEY,
    TypeTransactions VARCHAR(10) NOT NULL CHECK (TypeTransactions IN ('debit', 'credit')),
    DateTransactions DATE NOT NULL,
    Montant MONEY NOT NULL,
	CompteBancaireId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (CompteBancaireId) REFERENCES CompteBancaire
);
GO


