use masterchef;
DROP TABLE IF EXISTS Composition_Recette ;
DROP TABLE IF EXISTS Ingredients ;
CREATE TABLE Ingredients (id_ingredient INT IDENTITY NOT NULL,
nom_ingredient VARCHAR(255) NOT NULL,
type_ingredient VARCHAR(20) NOT NULL CHECK (type_ingredient IN('Frais','Surgelé', 'Longue conserv')),
quantite_ingredient INT NOT NULL,
date_peremption_ingredient DATE,
ingredient_preparable BIT,
PRIMARY KEY (id_ingredient));

DROP TABLE IF EXISTS Materiel ;
CREATE TABLE Materiel (id_materiel INT IDENTITY NOT NULL,
nom_materiel VARCHAR(255) NOT NULL,
type_materiel VARCHAR(30) NOT NULL CHECK (type_materiel IN('Matériel commun','Matériel de restauration', 'Matériel de cuisine')),
etat_materiel VARCHAR(15) NOT NULL CHECK (etat_materiel IN('Propre','Sale', 'En machine')),
quantite_materiel INT NOT NULL,
PRIMARY KEY (id_materiel));

DROP TABLE IF EXISTS Machines ;
CREATE TABLE Machines (id_machine INT IDENTITY NOT NULL,
nom_machine VARCHAR(255) NOT NULL,
etat_machine VARCHAR(50) NOT NULL CHECK (etat_machine IN('Allumé','Vide', 'Plein')),
PRIMARY KEY (id_machine));

DROP TABLE IF EXISTS Recettes ;
CREATE TABLE Recettes (id_recette INT IDENTITY NOT NULL,
nom_recette VARCHAR(255) NOT NULL,
temps_cuisson_recette SMALLINT,
temps_repos_recette SMALLINT,
temps_preparation_recette SMALLINT,
nombre_parts SMALLINT NOT NULL,
type_recette VARCHAR(10) NOT NULL CHECK (type_recette IN('Entrée','Plat', 'Dessert')),
PRIMARY KEY (id_recette));


CREATE TABLE Composition_Recette (id_composition_recette INT IDENTITY NOT NULL,
quantite_ingredient_recette INT NOT NULL,
id_ingredient INT NOT NULL,
id_recette INT NOT NULL,
PRIMARY KEY (id_composition_recette));

ALTER TABLE Composition_Recette ADD CONSTRAINT FK_Composition_Recette_id_ingredient FOREIGN KEY (id_ingredient) REFERENCES Ingredients (id_ingredient);

ALTER TABLE Composition_Recette ADD CONSTRAINT FK_Composition_Recette_id_recette FOREIGN KEY (id_recette) REFERENCES Recettes (id_recette);