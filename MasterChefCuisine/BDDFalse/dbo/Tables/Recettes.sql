CREATE TABLE Recettes (id_recette INT IDENTITY NOT NULL,
nom_recette VARCHAR(255) NOT NULL,
temps_cuisson_recette SMALLINT,
temps_repos_recette SMALLINT,
temps_preparation_recette SMALLINT,
nombre_parts SMALLINT NOT NULL,
PRIMARY KEY (id_recette));