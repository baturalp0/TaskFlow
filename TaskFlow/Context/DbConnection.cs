using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace TaskFlow.Context
{
    public class DbConnection
    {
        private readonly string _connectionString;
        NpgsqlConnection connection = new NpgsqlConnection("server=localhost; port=5432; Database=taskflow;user Id=postgres; password=antalya");


        public DbConnection()
        {

        }

        public DataTable GetNpgsql(string query)
        {
            connection.Open(); //PostgreSQL veritabanı bağlantısını açar.
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);  //NpgsqlDataAdapter sınıfı veritabanından verileri çekmek için kullanılır.
            DataSet ds = new DataSet();  //burada boş bir DataSet oluşturuyoruz.
            da.Fill(ds, "temp_table"); //Veritabanından çekilen verileri DataSet içine dolduruyoruz. "table_name" kısmı verilerin doldurulacağı tablo ismini belirtiyor.
            connection.Close(); //PostgreSQL veritabanının bağlantısını kapatır.
            DataTable dt = ds.Tables[0]; //Doldurulan DataSet içindeki tabloyu alıyoruz. temp_table tablosunu kullanmak için dt yi kullanmalıyız. Tabloyu alıp dt ye atarız

            return dt; //en son elimizdeki tabloyu döndürürüz.
        }

        public int AddNpgsql(string query)
        {
            connection.Open(); //PostgreSQL veritabanı bağlantısını açar.
            NpgsqlCommand command = new NpgsqlCommand(query, connection);  //NpgsqlCommand sınıfı, PostgreSQL veritabanında bir sorgu çalıştırmak için kullanılır. query parametresi, çalıştırılacak sorguyu belirtir. connection ise önceden oluşturulan PostgreSQL bağlantısını temsil eder.
            int i = command.ExecuteNonQuery(); //NpgsqlCommand ile sorguyu veritabanında çalıştırır ve etkilenen satır sayısını alırız. ExecuteNonQuery() metodu, sorguların sonucunda etkilenen satır sayısını döndürür (INSERT, UPDATE veya DELETE gibi değişiklik işlemlerinde etkilenen satır sayısı döner). Değer, int i değişkenine atanır.
            connection.Close(); //PostgreSQL veritabanı bağlantısını kapatır.
            return i; //Sorgu sonucu etkilenen satır sayısını döndürdük.
        }
    }
}
