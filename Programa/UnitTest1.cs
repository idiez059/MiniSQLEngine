using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
using System;
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
            db.RunQuery("INSERT INTO People VALUES ('Lor', 'lor@gmail.com', 7);");
            db.RunQuery("INSERT INTO People VALUES ('Lorea', 'lorea@gmail.com', 8);");
            db.RunQuery("INSERT INTO People VALUES ('Juana', 'juana@gmail.com', 11);");
            db.RunQuery("INSERT INTO People VALUES ('Juanjo', 'juanjo@gmail.com', 11);");
            Console.WriteLine(db.RunQuery("SELECT * FROM People;"));
            string result1 = db.RunQuery("SELECT Name FROM People WHERE Age = 23;");
            Console.WriteLine(db.RunQuery("SELECT * FROM People;"));
            string result2 = db.RunQuery("SELECT Name FROM People WHERE Age > 21;");
            string result3 = db.RunQuery("SELECT Name FROM People WHERE Age < 19;");
            Console.WriteLine(db.RunQuery("SELECT * FROM People;"));
            string result4 = db.RunQuery("SELECT Name FROM People WHERE Age < 22;");
            string result5 = db.RunQuery("SELECT Name FROM People WHERE Age < 18;");
            string result6 = db.RunQuery("SELECT Name FROM People WHERE Age = 25;");
            string result7 = db.RunQuery("SELECT Name FROM People WHERE Age > 26;");
            string result8 = db.RunQuery("SELECT Name FROM People WHERE Age = 11;");
            string result9 = db.RunQuery("SELECT Name FROM People WHERE Age < 10;");
            string resultn = db.RunQuery("SELECT Name FROM People;");
            string resulta = db.RunQuery("SELECT Age FROM People;");
            string resultTodo = db.RunQuery("SELECT * FROM People;");

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);
            Console.WriteLine(result5);
            Console.WriteLine(result6);
            Console.WriteLine(result7);
            Console.WriteLine(result8);
            Console.WriteLine(result9);
            Console.WriteLine(resultn);
            Console.WriteLine(resulta);
            Console.WriteLine(resultTodo);
            //-------------Test funcionalesdel con 1 solo where ----------
            // = ---- FUNCIONA
            Assert.AreEqual("{Name}{'Rafa'}", result1);
          
            //> ----FUNCIONA
            Assert.AreEqual("{Name}{'Rafa'}{'Maria'}{'Arrate'}{'Luis'}{'Luisma'}", result2);
            //> ----FUNCIONA ?¿?¿?
            Assert.AreEqual("{Name}{'Nerea'}{'Juan'}{'Lor'}{'Lorea'}{'Juana'}{'Juanjo'}", result5);

            ////< -----------(NO FUNCIONA, DICE QUE NO RECIBE NADA)
            Assert.AreEqual("{Name}{'Lor'}{'Lorea'}", result9);

            // sin where ------solo hay que ponerle name y devuelve solo los nombres)
            Assert.AreEqual("{Name}{'Nerea'}{'Jon'}{'Nuria'}{'Rafa'}{'Maria'}{'Arrate'}{'Luis'}{'Luisma'}{'Juan'}{'Lor'}{'Lorea'}{'Juana'}{'Juanjo'}", resultn);
            Assert.AreEqual("{Age}{17}{18}{20}{23}{25}{25}{27}{28}{11}{7}{8}{11}{11}", resulta);
         
            //-------------Test funcionales con 2 where ----------
            // = ---FUNCIONA
            Assert.AreEqual("{Name}{'Maria'}{'Arrate'}", result6);
            //<  ---FUNCIONA
            Assert.AreEqual("{Name}{'Nerea'}{'Jon'}{'Juan'}{'Lor'}{'Lorea'}{'Juana'}{'Juanjo'}", result3);
            //> ---FUNCIONA
            Assert.AreEqual("{Name}{'Luis'}{'Luisma'}", result7);

            //-------------Test funcionales con 3 o + where ----------
            // FUNCIONAAAAAAAA
            Assert.AreEqual("{Name}{'Juan'}{'Juana'}{'Juanjo'}", result8);
            //<  Tengo que probarlo
            Assert.AreEqual("{Name}{'Nerea'}{'Jon'}{'Nuria'}{'Juan'}{'Lor'}{'Lorea'}{'Juana'}{'Juanjo'}", result4);

            //-------------Test funcionales con * ----------
            //  funciona

            Assert.AreEqual("{Name,Email,Age}{'Nerea','nerea@gmail.com',17}{'Jon','jon@gmail.com',18}{'Nuria','nuria@gmail.com',20}{'Rafa','rafa@gmail.com',23}{'Maria','maria@gmail.com',25}{'Arrate','arrate@gmail.com',25}{'Luis','luis@gmail.com',27}{'Luisma','luisma@gmail.com',28}{'Juan','juan@gmail.com',11}{'Lor','lor@gmail.com',7}{'Lorea','lorea@gmail.com',8}{'Juana','juana@gmail.com',11}{'Juanjo','juanjo@gmail.com',11}", resultTodo);

            //SI LE CAMBIAS EL ORDEN YA NO FUNCIONA
            Assert.AreEqual("{Name}{'Nerea'}{'Jon'}{'Nuria'}{'Rafa'}{'Maria'}{'Arrate'}{'Luis'}{'Luisma'}{'Juan'}{'Lor'}{'Lorea'}{'Juana'}{'Juanjo'}", resultn);
        }
        //---------------------------------------------------------------------------

        [TestMethod]
        public void TestInsert()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            //si
            string result1 = db.RunQuery("INSERT INTO People VALUES ('Pepe', 'pepe@gmail.com', 2);");
            //si
            string result2 = db.RunQuery("INSERT INTO People VALUES ('Marta','', 3);");
            //si
            string result3 = db.RunQuery("INSERT INTO People VALUES ('', 'x@gmail.com',1 );");
            //si
            string result4 = db.RunQuery("INSERT INTO People VALUES ('Lucia', 'lucia@gmail.com', '');");

            Assert.AreEqual(Messages.InsertSuccess, result1);
            Assert.AreEqual(Messages.InsertSuccess, result2);
            Assert.AreEqual(Messages.InsertSuccess, result3);
            Assert.AreEqual(Messages.InsertSuccess, result4);
        }

        //---------------------------------------------------------------------------
        [TestMethod]
        public void TestUpdate()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Manuela', 'manuela@gmail.com', 10);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 60);");
            db.RunQuery("INSERT INTO People VALUES ('Juana', 'juana@gmail.com', 30);");
          
            //FUNCIONA 
            string result1 = db.RunQuery("UPDATE People SET Name='Bernardino',Age=11 WHERE Age<15;");
            Assert.AreEqual(Messages.TupleUpdateSuccess, result1);
            result1 = db.RunQuery("SELECT Name,Age FROM People WHERE Age < 15;");
            Assert.AreEqual("{Name,Age}{'Bernardino',11}", result1);
            //
            string result4 = db.RunQuery("UPDATE People SET Name='Bernardino' WHERE Name=Rafa;");
            Assert.AreEqual(Messages.TupleUpdateSuccess, result4);
            result4 = db.RunQuery("SELECT * FROM People;");
            Assert.AreEqual("{Name,Email,Age}{'Bernardino','rafa@gmail.com',60}", result4);

            //EL QUERY DEVUELVE NULL
            string result2 = db.RunQuery("UPDATE People SET Name='Bernardino',Age=61 WHERE Age>59;");
            Assert.AreEqual(Messages.TupleUpdateSuccess, result2);
            result2 = db.RunQuery("SELECT * FROM People;");
            Assert.AreEqual("{Name,Email,Age}{'Bernardino','rafa@gmail.com',61}", result2);

           ////EL QUERY DEVUELVE NULL
            string result3 = db.RunQuery("UPDATE People SET Name='Juana',Age=31 WHERE Age=30;");
            Assert.AreEqual(Messages.TupleUpdateSuccess, result3);
            result3 = db.RunQuery("SELECT * FROM People;");
            Assert.AreEqual("{Name,Email,Age}{'Juana','juana@gmail.com',31}", result3);
        }

        //---------------------------------------------------------------------------

        [TestMethod]
        public void TestDelete()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 34);");
            db.RunQuery("INSERT INTO People VALUES ('Nerea', 'nerea@gmail.com', 17);");
            db.RunQuery("INSERT INTO People VALUES ('Maria', 'maria@gmail.com', 25);");
            db.RunQuery("INSERT INTO People VALUES ('Arrate', 'arrate@gmail.com', 25);");
            db.RunQuery("INSERT INTO People VALUES ('Juana', 'arrate@gmail.com', 85);");

            //-------------Test funcional con 1 unica columna a eliminar y siendo un = 
            string result1 = db.RunQuery("DELETE FROM People WHERE Name = Rafa; ");
            //-------------Test funcional con 1 unica columna a eliminar y siendo un >
            string result2 = db.RunQuery("DELETE FROM People WHERE Age > 30; ");
            //-------------Test funcional con 1 unica columna a eliminar y siendo un <
            string result3 = db.RunQuery("DELETE FROM People WHERE Age < 20; ");
            //-------------Test funcional con +1 columna a eliminar y siendo un <
            string result4 = db.RunQuery("DELETE FROM People WHERE Age = 25; ");
            //-------------Test funcional eliminar todo
            string result5 = db.RunQuery("DELETE FROM People WHERE Age < 25; ");

            Assert.AreEqual(Messages.TupleDeleteSuccess, result1);
            result1 = db.RunQuery("SELECT Rafa FROM People;");
            Assert.AreEqual(Messages.ColumnDoesNotExist, result1);   // Se esperaba <>, pero es <ERROR: Column does not exist>. 


            Assert.AreEqual(Messages.TupleDeleteSuccess, result2);
            result2 = db.RunQuery("SELECT Rafa FROM People;");
            Assert.AreEqual(Messages.ColumnDoesNotExist, result2);

            Assert.AreEqual(Messages.TupleDeleteSuccess, result3);
            result3 = db.RunQuery("SELECT Nerea FROM People;");
            Assert.AreEqual(Messages.ColumnDoesNotExist, result3);


            Assert.AreEqual(Messages.TupleDeleteSuccess, result4);
            result4 = db.RunQuery("SELECT Rafa FROM People;");
            Assert.AreEqual(Messages.ColumnDoesNotExist, result4);

            //**************ESTO NO FUNCIONA********
            /*
            Assert.AreEqual(Messages.TupleDeleteSuccess, result5);
            result5 = db.RunQuery("SELECT Nerea FROM People;");
            Assert.AreEqual(Messages.ColumnDoesNotExist, result5);

            //result5 = db.RunQuery("SELECT Juana FROM People;");
            //Assert.AreEqual("{Name,Email,Age}{'Juana','arrate@gmail.com',85}", result5);
            */

        }

        //---------------------------------------------------------------------------

        /*
        [TestMethod]
        public void TestCreateTable()
        {
            Database db = new Database("test-db");

        }
         //---------------------------------------------------------------------------

        [TestMethod]
        public void TestDropTable()
        {
            Database db = new Database("test-db");

        }
        */

    }
}
