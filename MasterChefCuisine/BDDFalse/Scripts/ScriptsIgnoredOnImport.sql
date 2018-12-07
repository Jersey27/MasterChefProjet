
use masterchef;
GO

DROP TABLE IF EXISTS Ingredients ;
GO

DROP TABLE IF EXISTS Materiel ;
GO

DROP TABLE IF EXISTS Machines ;
GO

DROP TABLE IF EXISTS Recettes ;
GO

DROP TABLE IF EXISTS Composition_Recette ;
GO

use masterchef;
GO

insert into Ingredients (nom_ingredient, type_ingredient, date_peremption_ingredient) values ('Tomate', 'Longue conserv', NULL);
GO

insert into Ingredients (nom_ingredient, type_ingredient, date_peremption_ingredient) values ('Pâte à pizza', 'Frais', '08/12/2018');
GO

insert into Ingredients (nom_ingredient, type_ingredient, date_peremption_ingredient) values ('Mozarella', 'Frais', '08/12/2018');
GO

insert into Ingredients (nom_ingredient, type_ingredient, date_peremption_ingredient) values ('Piment d''espelette', 'Longue conserv', NULL);
GO

insert into Recettes (nom_recette, temps_cuisson_recette, temps_preparation_recette) values ('Pizza', 10, 20, 8);
GO

insert into Composition_Recette (id_recette, id_ingredient, quantite_ingredient_recette) values (1, 2, 1);
GO

insert into Composition_Recette (id_recette, id_ingredient, quantite_ingredient_recette) values (1, 1, 5);
GO

insert into Composition_Recette (id_recette, id_ingredient, quantite_ingredient_recette) values (1, 3, 2);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Fourchette', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Couteau', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Cuillère', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Cuillère à café', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Cuillère à soupe', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Assiette plate', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Assiette creuse', 'Matériel commun', 'Propre', 30);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Petite Assiette', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Assiette à dessert', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Cuitochette', 'Matériel commun', 'Sale', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Verre à eau', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Verre à vin', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Flute de champagne', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Jeu tasse et assiette à café', 'Matériel commun', 'Propre', 50);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Serviette en tissu', 'Matériel commun', 'Propre', 150);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Nappe', 'Matériel commun', 'Propre', 40);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Caraffe', 'Matériel de restauration', 'Propre', 40);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Corbeille pain', 'Matériel de restauration', 'Propre', 40);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Casserole', 'Matériel de cuisine', 'Propre', 10);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Poêle', 'Matériel de cuisine', 'Propre', 10);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Cuillère en bois', 'Matériel de cuisine', 'Propre', 10);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Bol salade', 'Matériel de cuisine', 'Propre', 5);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Autocuiseur', 'Matériel de cuisine', 'Propre', 2);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Mixeur', 'Matériel de cuisine', 'Propre', 1);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Presse-agrumes', 'Matériel de cuisine', 'Propre', 1);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Tamis', 'Matériel de cuisine', 'Propre', 1);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Entonnoir', 'Matériel de cuisine', 'Propre', 1);
GO

insert into Materiel (nom_materiel, type_materiel, etat_materiel, quantite_materiel) values ('Couteau de cuisine', 'Matériel de cuisine', 'Propre', 5);
GO

insert into Machines (nom_machine, etat_machine) values ('Four', 'Vide');
GO

insert into Machines (nom_machine, etat_machine) values ('Lave-vaisselle', 'Vide');
GO

insert into Machines (nom_machine, etat_machine) values ('Machine à laver', 'Vide');
GO

insert into Machines (nom_machine, etat_machine) values ('Frigo', 'Plein');
GO
