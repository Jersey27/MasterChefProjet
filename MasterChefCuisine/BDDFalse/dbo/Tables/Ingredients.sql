CREATE TABLE Ingredients (id_ingredient INT IDENTITY NOT NULL,
nom_ingredient VARCHAR(255) NOT NULL,
type_ingredient VARCHAR(50) NOT NULL CHECK (type_ingredient IN('Frais','Surgelé', 'Longue conserv')),
quantite_ingredient TINYINT NOT NULL,
date_peremption_ingredient DATE,
ingredient_preparable BOOLEAN NOT NULL,
PRIMARY KEY (id_ingredient));