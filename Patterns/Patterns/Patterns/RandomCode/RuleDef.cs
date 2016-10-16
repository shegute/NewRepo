using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Patterns.RandomCode
{
    public class RuleDef
    {

        public static void Run()
        {

            RuleDef r = new RuleDef();
            r.ConnectAndGetAlarms();
        }

        public int Id;
        public string Title;

        public RuleDef(   )
        {
        }

        public RuleDef(DataRow dr)
        {
            this.Id =   (int) dr[1];
            this.Title = dr[2] as string;
        }


        public string connectionString =
            "Server=localhost;Database=AlarmProcessorStore;Trusted_Connection=True;Application Name=AlarmProcessor;MultipleActiveResultSets=True;Pooling=True;Connection Timeout=60;Max Pool Size=2000;Asynchronous Processing=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void ConnectAndGetAlarms()
        {
            SqlConnection objConn = new SqlConnection(connectionString);
            objConn.Open();
            SqlDataAdapter daAuthors = new SqlDataAdapter("Select top 10 * From RuleDefinition", objConn);
            DataSet ds = new DataSet("Rules");
            daAuthors.FillSchema(ds, SchemaType.Source, "Rules");
            daAuthors.Fill(ds, "Rules");
            //daAuthors.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //daAuthors.Fill(ds, "Rules");
            DataTable tblAuthors;
            tblAuthors = ds.Tables["Rules"];
            List<RuleDef> rulesDefs = (from DataRow r in tblAuthors.Rows
                select new RuleDef(r)).ToList();
            List<RuleDef> rd2 =  new List<RuleDef>();
            rd2.AddRange(from DataRow dr in ds.Tables[0].Rows select new RuleDef(dr));
        }
    }
}
