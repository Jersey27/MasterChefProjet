﻿CREATE TABLE Composition_Recette (id_composition_recette INT IDENTITY NOT NULL,
quantite_ingredient_recette INT,
id_ingredient INT,
id_recette INT,
PRIMARY KEY (id_composition_recette));
GO
ALTER TABLE Composition_Recette ADD CONSTRAINT FK_Composition_Recette_id_ingredient FOREIGN KEY (id_ingredient) REFERENCES Ingredients (id_ingredient);
GO
ALTER TABLE Composition_Recette ADD CONSTRAINT FK_Composition_Recette_id_recette FOREIGN KEY (id_recette) REFERENCES Recettes (id_recette);