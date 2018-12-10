CREATE TABLE Machines (id_machine INT IDENTITY NOT NULL,
nom_machine VARCHAR(255) NOT NULL,
etat_machine VARCHAR(50) NOT NULL CHECK (etat_machine IN('Allumé','Vide', 'Plein')),
PRIMARY KEY (id_machine));