
DROP TABLE IF EXISTS Ingredients ;
CREATE TABLE Ingredients (id_ingredient INT IDENTITY NOT NULL,
nom_ingredient VARCHAR(255),
quantite_ingredient_recette BIGINT,
type_ingredient VARCHAR(50) NOT NULL CHECK (type_ingredient IN('Frais', 'Surgelé', 'Longue date de conservation')), 
date_peremption_ingredient DATE,
PRIMARY KEY (id_ingredient));  

DROP TABLE IF EXISTS Materiel ;
CREATE TABLE Materiel (id_materiel INT IDENTITY NOT NULL,
nom_materiel VARCHAR,
type_materiel VARCHAR(50) NOT NULL CHECK (type_materiel IN('Matériel commun', 'Matériel de restauration', 'Matériel de cuisine')),
etat_materiel VARCHAR(50) NOT NULL CHECK (etat_materiel IN('Sale', 'Propre', 'En machine')),
quantite_materiel TINYINT,
PRIMARY KEY (id_materiel)); 

DROP TABLE IF EXISTS Machines ;
CREATE TABLE Machines (id_machine INT IDENTITY NOT NULL,
nom_machine TEXT,
etat_machine VARCHAR(50) NOT NULL CHECK (etat_machine IN('Vide', 'Plein', 'Allumé')),
PRIMARY KEY (id_machine)); 

DROP TABLE IF EXISTS Recettes ;
CREATE TABLE Recettes (id_recette INT IDENTITY NOT NULL,
nom_recette TEXT,
temps_cuisson_recette SMALLINT,
temps_repos_recette SMALLINT,
temps_preparation_recette SMALLINT,
PRIMARY KEY (id_recette)); 

DROP TABLE IF EXISTS LISTER ; 
CREATE TABLE LISTER (id_ingredient INT IDENTITY NOT NULL,
id_recette INT NOT NULL,
quantite_ingredient_recette BIGINT,
PRIMARY KEY (id_ingredient,  id_recette));

ALTER TABLE LISTER ADD CONSTRAINT FK_LISTER_id_ingredient FOREIGN KEY (id_ingredient) REFERENCES Ingredients (id_ingredient);
ALTER TABLE LISTER ADD CONSTRAINT FK_LISTER_id_recette FOREIGN KEY (id_recette) REFERENCES Recettes (id_recette); 