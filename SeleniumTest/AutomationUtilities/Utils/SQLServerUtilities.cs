using AutomationUtilities.PageObjects.NavigationPO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace AutomationUtilities.Utils
{
    public class SQLServerUtilities
    {
        public static void StoreResults()
        {
            using (var conn = new SqlConnection(Setings.Instance.ResultsDB.ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO Test_Results (Test_Results.UTI, "
                + "Test_Results.absolute_Filepath_To_ImportFile, "
                + "Test_Results.build, "
                + "Test_Results.import_FileName, "
                + "Test_Results.Verification_Errors, "
                + "Test_Results.test_date, "
                + "Test_Results.test_Instance, "
                + "Test_Results.test_Result, "
                + "Test_Results.id, "
                + "Test_Results.test_name, "
                + "Test_Results.browser_version, "
                + "Test_Results.is_used, "
                + "Test_Results.bug_id) " +
                " VALUES ('" +
                Test.tradeID + "','" +
                Test.absolutePathToImportFile + "','" +
                Test.build + "','" +
                Test.fileName + "','" +
                Test.verificationErrors.ToString().Replace("'", "^") + "','" +
                Test.testdate + "', '" +
                Test.instanceURL + "', '" +
                Test.result + "', '" +
                Test.testID + "', '" +
                Test.testName + "','" +
                Test.browserVersion + "','" +
                "n" + "','" +
                Test.bug_id + "');";
                var result = cmd.ExecuteNonQuery();
            }
        }

        public static void ClearTestData(string testType)
        {
            string TableName = testType.Substring(0, testType.IndexOf("_"));
            
            if (testType.StartsWith("MT"))
            {
                testType.Remove(0, 2);
            }

            using (var conn = new SqlConnection(Setings.Instance.IceDB.ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();

                switch(TableName)
                {
                    case "Counterparty":
                        cmd.CommandText = "DELETE EMIRCounterpartyDelegatedCollateralTenantLink WHERE CounterpartyID IN (SELECT ID FROM Counterparty WHERE Name  LIKE 'TA[0-9]%') "
                                        + "DELETE EMIRCounterpartyDelegatedReportingTenantLink WHERE CounterpartyID IN (SELECT ID FROM Counterparty WHERE Name  LIKE 'TA[0-9]%') "
                                        + "DELETE EMIRCounterpartyDelegatedValuationTenantLink WHERE CounterpartyID IN (SELECT ID FROM Counterparty WHERE Name  LIKE 'TA[0-9]%') "
                                        + "DELETE EMIRCounterpartyIntraGroupTenantLink WHERE CounterpartyID IN (SELECT ID FROM Counterparty WHERE Name  LIKE 'TA[0-9]%')"
                                        + "DELETE Counterparty WHERE Name LIKE 'TA[0-9]%'";
                        break;

                    case "Market":
                        cmd.CommandText = " DELETE MarketAuditEntry WHERE MarketID IN (SELECT ID FROM Market WHERE Name  LIKE 'TA[0-9]%') "
                                        + " DELETE " + TableName + " WHERE Name LIKE 'TA[0-9]%'";
                        break;

                    case "SourceSystem":
                        TableName = "EMIR" + TableName;
                        cmd.CommandText = " DELETE " + TableName + " WHERE Name LIKE 'TA[0-9]%'";
                        break;

                    case "Product":
                        TableName = "EMIR" + TableName;
                        cmd.CommandText = " DELETE " + TableName + " WHERE Name LIKE 'TA[0-9]%'";
                        break;

                    case "BICCode":
                        cmd.CommandText = " DELETE LegalEntity WHERE BICCodeID IN (SELECT ID FROM BICCode WHERE Name  LIKE 'TA[0-9]%') "
                                        + " DELETE CounterParty WHERE BICCodeID IN (SELECT ID FROM BICCode WHERE Name  LIKE 'TA[0-9]%') "
                                        + " DELETE " + TableName + " WHERE Name LIKE 'TA[0-9]%'";
                        break;
                    default:
                        cmd.CommandText = "DELETE " + TableName + " WHERE Name LIKE 'TA[0-9]%'";
                        break;
                }
                var result = cmd.ExecuteNonQuery();
            }
        }

        public static int GetCollateralId(string TestId)
        {
            int result = -1;

            while (result == -1)
            {
                Thread.Sleep(60000);
                PO_UTISearch.ClickSearchFor(TestId);
//                Browser.Browser.instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys(TestId);

                using (var conn = new SqlConnection(Setings.Instance.IceDB.ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT C.Id FROM EMIRTrade t INNER JOIN EMIRCollateral c on t.TradeId = c.SourceTradeID WHERE t.TradeId = '" + TestId + "'";
                    object tempId = cmd.ExecuteScalar();

                    if (tempId != null)
                    {
                        result = (Int32)tempId;
                    }
                }
            }
            
            return result;
        }

        public static List<TestResults> SelectPassedTestsByTestInstance(string p)
        {
            using (var conn = new SqlConnection(Setings.Instance.ResultsDB.ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                var list = new List<TestResults>();
                conn.Open();
                cmd.CommandText = "Select * from Test_Results where test_Result='Passed' and "
                + "test_name='" + Test.testName + "'and "
                + "test_Instance ='" + Test.instanceURL + "' and "
                + "is_used = 'n' order by test_date desc";
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        list.Add(new TestResults
                                   {
                                       tradeID = reader[0] != DBNull.Value ? reader.GetString(0) : string.Empty,
                                       result = reader.GetString(1),
                                       build = reader.GetString(2),
                                       testInstance = reader.GetString(3),
                                       fileName = reader.GetString(4),
                                       absolutePathToImportFile = reader.GetString(5),
                                       date = reader[7] != DBNull.Value ? reader.GetDateTime(7) : DateTime.MinValue,
                                       testName = reader[9] != DBNull.Value ? reader.GetString(9) : string.Empty,
                                       browserVersion = reader[10] != DBNull.Value ? reader.GetString(10) : string.Empty
                                   });
                    }

                }
                return list;
            }
        }

        public static void SetLastSuccessfullTradeImport()
        {
            using (var conn = new SqlConnection(Setings.Instance.ResultsDB.ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "select UTI from Test_Results where test_Result = 'Passed' and is_used = 'n' and test_Instance = '" + Test.instanceURL + "' order by test_date desc ";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Test.tradeID = reader[0] != DBNull.Value ? reader.GetString(0) : string.Empty;
                        break;
                    }
                }
            }
        }

        public static void MarkTestResultAsUsed(string tradeId)
        {
            using (var conn = new SqlConnection(Setings.Instance.ResultsDB.ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "UPDATE Test_Results " +
                "SET is_used='y' " +
                "WHERE id = '" + Test.testID + "';";
                var result = cmd.ExecuteNonQuery();
            }
        }

        public static void StoreScreenshot()
        {
            using (var conn = new SqlConnection(Setings.Instance.ResultsDB.ConnectionString))
            {
                conn.Open();
                
                string cmd = @"UPDATE Test_Results
                                 set screenshot= @Photo
                                 WHERE id = '" + Test.testID + "';";

                SqlCommand insertCommand = new SqlCommand(cmd, conn);
                SqlParameter sqlParam = insertCommand.Parameters.AddWithValue("@Photo", Test.screenshot.AsByteArray);
                sqlParam.DbType = DbType.Binary;
                insertCommand.ExecuteNonQuery();
            }
        }
    }
}
