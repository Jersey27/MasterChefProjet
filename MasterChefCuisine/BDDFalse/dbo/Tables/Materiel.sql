CREATE TABLE Materiel (id_materiel INT IDENTITY NOT NULL,
nom_materiel VARCHAR(255),
type_materiel VARCHAR(50) NOT NULL CHECK (type_materiel IN('Matériel commun','Matériel de restauration', 'Matériel de cuisine')),
etat_materiel VARCHAR(50) NOT NULL CHECK (etat_materiel IN('Propre','Sale', 'En machine')),
quantite_materiel TINYINT,
PRIMARY KEY (id_materiel));