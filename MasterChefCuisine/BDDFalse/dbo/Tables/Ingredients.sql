CREATE TABLE Ingredients (id_ingredient INT IDENTITY NOT NULL,
nom_ingredient VARCHAR(255),
type_ingredient VARCHAR(50) NOT NULL CHECK (type_ingredient IN('Frais','Surgelé', 'Longue conserv')),
quantite_ingredient TINYINT,
date_peremption_ingredient DATE,
PRIMARY KEY (id_ingredient));