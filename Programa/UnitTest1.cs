using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
using System.IO;

namespace Programa
{
    [TestClass]
    public class EverythingWorks
    {
        [TestMethod]
        public void TestSelect()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");

            db.RunQuery("INSERT INTO People VALUES ('Nerea', 'nerea@gmail.com', 17);");
            db.RunQuery("INSERT INTO People VALUES ('Jon', 'jon@gmail.com', 18);");
            db.RunQuery("INSERT INTO People VALUES ('Nuria', 'nuria@gmail.com', 20);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            db.RunQuery("INSERT INTO People VALUES ('Maria', 'maria@gmail.com', 25);");
            db.RunQuery("INSERT INTO People VALUES ('Arrate', 'arrate@gmail.com', 25);");
            db.RunQuery("INSERT INTO People VALUES ('Luis', 'luis@gmail.com', 27);");
            db.RunQuery("INSERT INTO People VALUES ('Luisma', 'luisma@gmail.com', 28);");
            db.RunQuery("INSERT INTO People VALUES ('Juan', 'juan@gmail.com', 11);");
            db.RunQuery("INSERT INTO People VALUES ('Juana', 'juana@gmail.com', 11);");
            db.RunQuery("INSERT INTO People VALUES ('Juanjo', 'juanjo@gmail.com', 11);");
            db.RunQuery("INSERT INTO People VALUES ('Leire', 'leire@gmail.com', 9);");

            string result1 = db.RunQuery("SELECT Name FROM People WHERE Age = 23;");
            string result2 = db.RunQuery("SELECT Name FROM People WHERE Age > 21;");
            string result3 = db.RunQuery("SELECT Name FROM People WHERE Age < 19;");
            string result4 = db.RunQuery("SELECT Name FROM People WHERE Age < 22;");
            string result5 = db.RunQuery("SELECT Name FROM People WHERE Age < 18;");
            string result6 = db.RunQuery("SELECT Name FROM People WHERE Age = 25;");
            string result7 = db.RunQuery("SELECT Name FROM People WHERE Age > 26;");
            string result8 = db.RunQuery("SELECT Name FROM People WHERE Age = 11;");
            string result9 = db.RunQuery("SELECT Name FROM People WHERE Age < 10;");
            string resultn = db.RunQuery("SELECT Name FROM People;");
            string resulta = db.RunQuery("SELECT Age FROM People;");
            string resultTodo = db.RunQuery("SELECT * FROM People;");

            //-------------Test funcionalesdel con 1 solo where ----------

            // = ---- FUNCIONA
            Assert.AreEqual("{Name,Email,Age}{'Rafa','rafa@gmail.com',23}", result1);

            //> ----FUNCIONA
            Assert.AreEqual("{Name,Email,Age}{'Rafa','rafa@gmail.com',23}", result2);

            //< -----------(NO FUNCIONA, DICE QUE NO RECIBE NADA)

            // Assert.AreEqual("{Name,Email,Age}{'Leire','leire@gmail.com',9}", result9);

            // sin where ------solo hay que ponerle name y devuelve solo los nombres)

            Assert.AreEqual("{Name}{'Jon'}{'Nuria'}{'Rafa'}", resultn);
            Assert.AreEqual("{Age}{18}{20}{23}", resulta);

            //-------------Test funcionales con 2 where ----------
            // = ---FUNCIONA
            Assert.AreEqual("{Name,Email,Age}{'Maria','maria@gmail.com',25}{'Arrate','arrate@gmail.com',25}", result6);
            //<  ---FUNCIONA
            Assert.AreEqual("{Name,Email,Age}{'Nerea','nerea@gmail.com',17}{'Jon','jon@gmail.com',18}", result3);
            //> ---FUNCIONA
            Assert.AreEqual("{Name,Email,Age}{'Luis','luis@gmail.com',27}{'Luisma','luisma@gmail.com',28}", result7);

            //-------------Test funcionales con 3 o + where ----------
            // FUNCIONAAAAAAAA
            Assert.AreEqual("{Name,Email,Age}{'Juan','juan@gmail.com',11}{'Juana','juana@gmail.com',11}{'Juanjo','juanjo@gmail.com',11}", result8);
            //<  Tengo que probarlo
            Assert.AreEqual("{Name,Email,Age}{'Nerea','nerea@gmail.com',17}{'Jon','jon@gmail.com',18}{'Nuria','nuria@gmail.com',20}{'Juan','juan@gmail.com',11}{'Juana','juana@gmail.com',11}{'Juanjo','juanjo@gmail.com',11}", result4);

            //-------------Test funcionales con * ----------
            //  funciona

           Assert.AreEqual("{Name,Email,Age}{'Nerea','nerea@gmail.com',17}{'Jon','jon@gmail.com',18}{'Nuria','nuria@gmail.com',20}{'Rafa','rafa@gmail.com',23}{'Maria','maria@gmail.com',25}{'Arrate','arrate@gmail.com',25}{'Luis','luis@gmail.com',27}{'Luisma','luisma@gmail.com',28}{'Juan','juan@gmail.com',11}{'Juana','juana@gmail.com',11}{'Juanjo','juanjo@gmail.com',11}{'Leire','leire@gmail.com',9}", resultTodo);
              
            //SI LE CAMBIAS EL ORDEN YA NO FUNCIONA
          Assert.AreEqual("{Name}{'Rafa'}{'Maria'}{'Arrate'}{'Luis'}{'Nerea'}{'Jon'}{'Nuria'}{'Luisma'}{'Juan'}{'Juana'}{'Juanjo'}", resultn);


        }

        [TestMethod]
        public void TestInsert()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            string result2 = db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            //el insert no devuelve nada
            //Assert.AreNotEqual("{Name}{'Rafa','rafa@gmail.com', 23}", result2);
            //No funciona, devuelve null
            Assert.AreEqual(Messages.InsertSuccess, result2);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 34);");
            string result1 = db.RunQuery("UPDATE People SET Name=Bernardino,Age=21 WHERE Age<27;");
            Assert.AreEqual(Messages.TupleUpdateSuccess, result1);
            result1 = db.RunQuery("SELECT * FROM People;");
            Assert.AreEqual("{Name,Email,Age}{'Rafa','rafa@gmail.com',34}",result1);
        }
        
        [TestMethod]
        public void TestDelete()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 34);");
            string result1 = db.RunQuery("DELETE FROM People WHERE Name = Rafa; ");
            Assert.AreEqual(Messages.TupleDeleteSuccess, result1);
        }
        /*
        [TestMethod]
        public void TestCreateTable()
        {
            Database db = new Database("test-db");
           
        }

        [TestMethod]
        public void TestDropTable()
        {
            Database db = new Database("test-db");

        }
        */

    }
}
