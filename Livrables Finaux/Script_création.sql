use masterchef;
DROP TABLE IF EXISTS Ingredients ;
CREATE TABLE Ingredients (id_ingredient INT IDENTITY NOT NULL,
nom_ingredient VARCHAR(255),
type_ingredient VARCHAR(50) NOT NULL CHECK (type_ingredient IN('Frais','Surgel�', 'Longue conserv')),
quantite_ingredient TINYINT,
date_peremption_ingredient DATE,
PRIMARY KEY (id_ingredient));

DROP TABLE IF EXISTS Materiel ;
CREATE TABLE Materiel (id_materiel INT IDENTITY NOT NULL,
nom_materiel VARCHAR(255),
type_materiel VARCHAR(50) NOT NULL CHECK (type_materiel IN('Mat�riel commun','Mat�riel de restauration', 'Mat�riel de cuisine')),
etat_materiel VARCHAR(50) NOT NULL CHECK (etat_materiel IN('Propre','Sale', 'En machine')),
quantite_materiel TINYINT,
PRIMARY KEY (id_materiel));

DROP TABLE IF EXISTS Machines ;
CREATE TABLE Machines (id_machine INT IDENTITY NOT NULL,
nom_machine VARCHAR(255),
etat_machine VARCHAR(50) NOT NULL CHECK (etat_machine IN('Allum�','Vide', 'Plein')),
PRIMARY KEY (id_machine));

DROP TABLE IF EXISTS Recettes ;
CREATE TABLE Recettes (id_recette INT IDENTITY NOT NULL,
nom_recette VARCHAR(255),
temps_cuisson_recette SMALLINT,
temps_repos_recette SMALLINT,
temps_preparation_recette SMALLINT,
PRIMARY KEY (id_recette));

DROP TABLE IF EXISTS Composition_Recette ;
CREATE TABLE Composition_Recette (id_composition_recette INT IDENTITY NOT NULL,
quantite_ingredient_recette INT,
id_ingredient INT,
id_recette INT,
PRIMARY KEY (id_composition_recette));

ALTER TABLE Composition_Recette ADD CONSTRAINT FK_Composition_Recette_id_ingredient FOREIGN KEY (id_ingredient) REFERENCES Ingredients (id_ingredient);

ALTER TABLE Composition_Recette ADD CONSTRAINT FK_Composition_Recette_id_recette FOREIGN KEY (id_recette) REFERENCES Recettes (id_recette);