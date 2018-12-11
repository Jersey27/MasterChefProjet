using System;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class SQLQueryTests
    {
     
        [TestMethod]
        public void selectFromDB(string selection, string table, string condition, SqlConnection connection)
        {
            Assert.Fail();
        }

        [TestMethod]
        public void getRecipe(string recipeName, SqlConnection connection)
        {
            Assert.Fail();
        }

        [TestMethod]
        public void getIngredient(string name, SqlConnection connection)
        {
            Assert.Fail();
        }

        [TestMethod]
        public void getIngredient(int id, SqlConnection connection)
        {
            Assert.Fail();
        }
    }

}
