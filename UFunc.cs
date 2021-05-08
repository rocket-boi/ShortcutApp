using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Shortcut_App
{
    static class UFunc
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        public static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static bool FileOrDirectoryExists(string path)
        {
            return (Directory.Exists(path) || File.Exists(path));
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static void OpenSomething(string path)
        {
            try { System.Diagnostics.Process.Start(path); }
            catch { }
        }
    }

    static class SQLUFunc
    {
        public static bool ResultsExist(string query, SqlConnection con)
        {
            bool exist = false;
            DataTable temptable = new DataTable();
            SqlCommand com = new SqlCommand(query, con);
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            temptable.Load(dr);
            con.Close();
            if (temptable.Rows.Count > 0) exist = true;

            return exist;
        }

        public static int RunSQLWriteQuery(string query, SqlConnection con)
        {
            SqlCommand com = new SqlCommand(query, con);
            int AffectedRows = 0;
            SqlCommand command = new SqlCommand(query, con);
            con.Open();

            AffectedRows = command.ExecuteNonQuery();

            con.Close();

            return AffectedRows;
        }

        public static DataTable RunSQLReadQuery(string query, SqlConnection con)
        {
            DataTable temptable = new DataTable();
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            temptable.Load(dr);
            con.Close();

            return temptable;
        }

        public static DataTable RunSQLReadQuery(bool Procedure, string ProcedureName, SqlConnection con)
        {
            DataTable temptable = new DataTable();
            SqlCommand command = new SqlCommand(ProcedureName, con);
            command.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            temptable.Load(dr);
            con.Close();

            return temptable;
        }

        public static int InsertSQLEntry(string TableName, string[] Parameters, string[] Values, SqlConnection con)
        {
            if (Parameters.Count() != Values.Count()) return -1;

            con.Open();

            string query = "INSERT INTO [" + TableName + "] (";

            for (int i = 0; i < Parameters.Count(); i++)
            {
                query += Parameters[i];
                if (i < Parameters.Count() - 1) query += ",";
            }

            query += ") VALUES (";

            for (int i = 0; i < Parameters.Count(); i++)
            {
                query += "@" + Parameters[i];
                if (i < Parameters.Count() - 1) query += ",";
            }

            query += ") ;SELECT CAST(scope_identity() AS int)";

            SqlCommand command = new SqlCommand(query, con);
            
            for (int i = 0; i < Parameters.Count(); i++)
            {
                command.Parameters.AddWithValue("@" + Parameters[i], Values[i]);
            }

            int newID = (int)command.ExecuteScalar();

            con.Close();

            return newID;
        }

        public static void UpdateSQLEntry(string TableName, string[] Parameters, string[] Values, string WhereClause, SqlConnection con)
        {
            if (Parameters.Count() != Values.Count()) return;

            con.Open();

            string query = "UPDATE [" + TableName + "] SET ";

            for (int i = 0; i < Parameters.Count(); i++)
            {
                if (Parameters[i] == null) continue;
                query += Parameters[i] + " = " + "@" + Parameters[i];
                if (i < Parameters.Count() - 1) query += ", ";
            }

            query += " WHERE " + WhereClause;

            SqlCommand command = new SqlCommand(query, con);

            for (int i = 0; i < Parameters.Count(); i++)
            {
                command.Parameters.AddWithValue("@" + Parameters[i], Values[i]);
            }

            command.ExecuteScalar();

            con.Close();

            return;
        }

        public static DataTable RunSQLReadQuery(bool Procedure, string ProcedureName, SqlConnection con, string[] Parameters, int[] Values)
        {
            DataTable temptable = new DataTable();
            SqlCommand command = new SqlCommand(ProcedureName, con);
            command.CommandType = CommandType.StoredProcedure;
            if (Parameters.Count() != Values.Count() && Parameters.Count() < 0) return null;
            for(int i = 0; i < Parameters.Count(); i++) command.Parameters.Add("@" + Parameters[i], SqlDbType.Int).Value = Values[i];
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            temptable.Load(dr);
            con.Close();

            return temptable;
        }

        public static DataTable RunSQLReadQuery(bool Procedure, string ProcedureName, SqlConnection con, string[] Parameters, string[] Values)
        {
            DataTable temptable = new DataTable();
            SqlCommand command = new SqlCommand(ProcedureName, con);
            command.CommandType = CommandType.StoredProcedure;
            if (Parameters.Count() != Values.Count() && Parameters.Count() < 0) return null;
            for (int i = 0; i < Parameters.Count(); i++) command.Parameters.Add("@" + Parameters[i], SqlDbType.NVarChar).Value = Values[i];
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            temptable.Load(dr);
            con.Close();

            return temptable;
        }

        public static DataTable GetData(string selectCommand, SqlConnection con)
        {
            SqlDataAdapter dataAdapter;
            SqlCommandBuilder commandBuilder;
            DataTable table = new DataTable();

            con.Open();

            dataAdapter = new SqlDataAdapter(selectCommand, con);
            dataAdapter.SelectCommand = new SqlCommand(selectCommand, con);
            commandBuilder = new SqlCommandBuilder(dataAdapter);

            dataAdapter.Fill(table);

            con.Close();
            return table;
        }

        public static int UpdateDataBindToDataBase(string TargetTable, BindingSource bs, SqlConnection con)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder;
            string selectCommand = "SELECT * FROM [" + TargetTable + "]";
            dataAdapter.SelectCommand = new SqlCommand(selectCommand, con);
            commandBuilder = new SqlCommandBuilder(dataAdapter);

            con.Open();
            int rowsreturned = dataAdapter.Update((DataTable)bs.DataSource);
            con.Close();
            return rowsreturned;
        }
    }

    public static class SerializeFunctions
    {
        public static T Deserialize<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        public static string Serialize<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }

}
