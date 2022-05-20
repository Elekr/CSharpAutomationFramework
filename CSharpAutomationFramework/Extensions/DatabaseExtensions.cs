using Microsoft.Data.SqlClient;
using System.Data;
using TechTalk.SpecFlow;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CSharpAutomationFramework.Extensions
{
    public static class DatabaseExtensions
    {
        public static Table GetDataSQLServer(this string connectionString,string query, int timeOutSeconds = 30)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        var da = new SqlDataAdapter(cmd);
                        using (var cb = new SqlCommandBuilder(da))
                        {
                            var ds = new DataSet();
                            if (TimeSpan.FromSeconds(timeOutSeconds).RetryUntilSuccessOrTimeout(() => da.Fill(ds) > 0))
                            {
                                return ds.Tables[0].ToTable();
                            }

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Table GetDataMongoDB(this string mongoServer, string database, string collection, string filterColumn = null, string filterValue = null, int timeOutSeconds = 30)
        {
            try
            {
                var dbClient = new MongoClient(mongoServer);
                IMongoDatabase db = dbClient.GetDatabase(database);
                var data = db.GetCollection<BsonDocument>(collection);

                //var filter = Builders<BsonDocument>.Filter.Eq(filterColumn, filterValue);

                //var doc = data.Find(filter).FirstOrDefault();
                var doc = data.Find(new BsonDocument()).FirstOrDefault().GetDataTableFromBSonDoc().ToTable();


                return doc;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable GetDataTableFromBSonDoc(this BsonDocument doc)
        {
            
                DataTable dt = new DataTable();

                    foreach (BsonElement elm in doc.Elements)
                    {
                        if (!dt.Columns.Contains(elm.Name))
                        {
                            dt.Columns.Add(new DataColumn(elm.Name));
                        }

                    }
                    DataRow dr = dt.NewRow();
                    foreach (BsonElement elm in doc.Elements)
                    {
                        dr[elm.Name] = elm.Value;

                    }
                    dt.Rows.Add(dr);

                return dt;

            }
    }
}
