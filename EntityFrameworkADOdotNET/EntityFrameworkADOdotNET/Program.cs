using System;
using System.Data;
using System.Data.SqlClient;

namespace EntityFrameworkADOdotNET
{
    class Program
    {


        static void Main(string[] args)
        {
            //tworzenie aplikacji bazodanowej
            string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=Database1; Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True";
            //Zapytanie SQL(read)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Próba połączenia z bazą
                SqlCommand command = new SqlCommand("SELECT * FROM bands", connection);
                Console.WriteLine("Id, \n\tBand, \n\t\tGuitarist, \n\t\t\tGreatest Hit");

                //połączeniowy
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Console.WriteLine("{0}, \n\t{1}, \n\t\t{2}, \n\t\t\t{3}", reader[0], reader[1], reader[2], reader[3]);
                        //foreach (var r in reader) { Console.Write("{}", r); }
                    }
                    reader.Close();
                    Console.WriteLine("reader closed");
                    connection.Close();
                    Console.WriteLine("connection closed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); connection.Close(); Console.WriteLine("connection closed with error");
                }

                //Próba połączenia z bazą
                command = new SqlCommand("SELECT * FROM albums", connection);
                Console.WriteLine("Albums:\n" +
                    "Id, \n\tTitle, \n\t\tBand, \n\t\t\tYear, \n\t\t\t\tNumOfTracks, \n\t\t\t\t\tBandId");

                //połączeniowy
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Console.WriteLine("{0}, \n\t{1}, \n\t\t{2}, \n\t\t\t{3}, \n\t\t\t\t{4}, \n\t\t\t\t\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                        //foreach (var r in reader) { Console.Write("{}", r); }
                    }
                    reader.Close();
                    Console.WriteLine("reader closed");
                    connection.Close();
                    Console.WriteLine("connection closed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); connection.Close(); Console.WriteLine("connection closed with error");
                }


                Console.WriteLine("\n\n");

                //bezpołączeniowy
                Console.WriteLine("\nBands: \n\n");
                try
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Bands", connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                            Console.WriteLine(row[col]);
                        Console.WriteLine("".PadLeft(20, '='));
                    }
                    connection.Close();
                    Console.WriteLine("Connection closed");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); connection.Close(); Console.WriteLine("connection closed with error");
                }

                Console.WriteLine("\n\n\nAlbums: \n\n");
                try
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Albums", connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                            Console.WriteLine(row[col]);
                        Console.WriteLine("".PadLeft(20, '='));
                    }
                    connection.Close();
                    Console.WriteLine("Connection closed");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); connection.Close(); Console.WriteLine("connection closed with error");
                }




                //ad.Fill(data);

            }
            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
