using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;
using System.Collections;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class PlungerTests
    {
        Plunger plunger = new Plunger();
        
        SQLQuery query = SQLQuery.getInstance();

        [TestMethod]
        public void washTest()
        {
            plunger.Wash();
            ArrayList result = query.selectFromDB("quantite_materiel", "Materiel", "nom_materiel = 'Cuitochette' AND etat_materiel = 'Propre'");
            foreach (object[] i in result)
            {
                Assert.AreEqual(15, i[0]);
            }
            result = query.selectFromDB("quantite_materiel", "Materiel", "nom_materiel = 'Cuitochette' AND etat_materiel = 'Sale'");
            foreach (object[] i in result)
            {
                Assert.AreEqual(0, i[0]);
            }
            query.updateDB("Materiel", "quantite_Materiel", 0, "nom_materiel = 'Cuitochette' AND etat_materiel = 'Propre'");
            query.updateDB("Materiel", "quantite_Materiel", 15, "nom_materiel = 'Cuitochette' AND etat_materiel = 'Sale'");
        }
    }
}
