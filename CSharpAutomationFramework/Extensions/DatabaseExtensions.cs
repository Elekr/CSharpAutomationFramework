using Microsoft.Data.SqlClient;
using System.Data;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.Extensions
{
    public static class DatabaseExtensions
    {
        public static Table GetData(this string connectionString,string query, int timeOutSeconds = 30)
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
    }
}
