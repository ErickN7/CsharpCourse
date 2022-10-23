using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
    public class BeerDB : DB
    {
        public BeerDB(string server, string db, string user, string password): base(server, db, user, password)
        {
           
        }

        public List<Beer> GetAll()
        {
            Connect();
            List<Beer> beers = new List<Beer>();
            string query = @"select Id,Name,BrandId from beer";
            SqlCommand sqlCommand = new SqlCommand(query, _connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);
                beers.Add(new Beer(id, name, brandId));
            }

            Close();
            return beers;
        }

        public void Add(Beer beer)
        {
            Connect();
            string query = "INSERT INTO Beer(Name,BrandId)" +
                "VALUES(@name,@brandId)";
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@name", beer.Name);
            cmd.Parameters.AddWithValue("@brandId", beer.BrandId);
            cmd.ExecuteNonQuery();
            Close();
        }

        public Beer Get(int id)
        {
            Connect();
            Beer beer = null;
            string query = "SELECT Id,Name,BrandId FROM BEER " +
                "WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, _connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);
                beer = new Beer(id, name, brandId);
            }

            Close();
            return beer;
        }

        public void Edit(Beer beer)
        {
            Connect();
            string query = "UPDATE beer SET name=@name,brandId=@brandId " +
                "WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, _connection);
            sqlCommand.Parameters.AddWithValue("@name", beer.Name);
            sqlCommand.Parameters.AddWithValue("@brandId", beer.BrandId);
            sqlCommand.Parameters.AddWithValue("@id", beer.Id);
            sqlCommand.ExecuteNonQuery();
            Close();
        }

        public void Delete(int id)
        {
            Connect();
            string query = "DELETE FROM beer WHERE id=@id";
            SqlCommand sqlCommand = new SqlCommand(query, _connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();
            Close();
        }
    }
}
