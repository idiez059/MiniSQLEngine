using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace Programa
{
    [TestClass]
    public class EverythingWorks
    {
        [TestMethod]
        public void Select()
        {


        }

        [TestMethod]
        public void Update()
        { Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            db.RunQuery("UPDATE People SET Name=Bernardino,Age=21 WHERE Age<27;");
            //db.RunQuery(@"UPDATE People SET Name=Bernardino,Email=delvalle@gmail.com WHERE Age<27;");
            //db.RunQuery("UPDATE People SET Name=Bernado WHERE Name=Rafa;");
            //db.RunQuery("UPDATE People SET Name=Bernardino,Age=21;");
            //db.RunQuery("UPDATE People SET Name=Bernado WHERE Name=Rafa;");


            //string[] value = {"Rafa", "rafa@gmail.com", "23"};
            
            //foreach (string data in value)
            //{
            //    Column column = table.ColumnByName(ColumnNames[j]);

            //    column.SetValueAsString(i, Values[j]);

            //    //ColumnNames.Add(parts[0]);
            //    //Values.Add(parts[1]);
            //}
            //foreach ()
            //{

            //}
              
            //for (int i = 0; i <= numValues; i++)
            //{  
            //        for (int j = 0; j < Values.Count; j++)
            //        {
            //            //por qué lo cambia al final
            //            Column column = table.ColumnByName(ColumnNames[j]);

            //            column.SetValueAsString(i, Values[j]);


            //        }
                
            //}
            //Assert.IsNotNull();
            
           


            
            
        }


    }
}
