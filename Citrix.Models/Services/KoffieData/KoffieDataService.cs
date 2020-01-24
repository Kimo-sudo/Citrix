using Citrix.Models.Models.Battle;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Citrix.Models.Services.KoffieData
{ 
    
    public class KoffieDataService
{
    private string _con;

    public KoffieDataService(string connectionString)
    {
        _con = connectionString;
    }

    // Laatste invoer per restaurant
    public List<KoffieBattle> LastInputPerRestaurant(string restaurant)
    {

        string sql = @"select top 1 * from Koffiebattle
                       where namerestaurant = @restaurantName
                       order by datum desc";
        using (var connection = new SqlConnection(_con))
        {

            connection.Open();
            var result = connection.QueryAsync<KoffieBattle>(sql, new { restaurantName = restaurant }).Result.ToList();
            connection.Close();
            return result;


        }
    }
    // Alle restaurants deze maand laatste cijfers
    public List<KoffieBattle> LiveKoffieBattle()
    {
        using (var connection = new SqlConnection(_con))
        {
            connection.Open();
            string sql = @"SELECT A.Groot, Medium, A.datum, A.NameManager, A.NameRestaurant FROM KoffieBattle A INNER JOIN(
				SELECT NameRestaurant, MAX(datum) as datum 
                FROM KoffieBattle 
				where MONTH(datum) = @huidigemaand
				GROUP BY NameRestaurant
				)AS B 
				ON A.NameRestaurant = B.NameRestaurant AND A.datum = B.datum";

            var BattleMaand = connection.Query<KoffieBattle>(sql, new { huidigemaand = DateTime.Now.Month }).ToList();
            connection.Close();
            return BattleMaand;
        }
    }
    // Specifiek 
    public List<KoffieBattle> MaandCijfer(string restaurant)
    {
        string sql = $"SELECT * FROM KoffieBattle WHERE NameRestaurant = @restaurantName";
        using (var connection = new SqlConnection(_con))
        {
            var result = connection.QueryAsync<KoffieBattle>(sql, new { restaurantName = restaurant }).Result.ToList();
            return result;
        }
    }
    // Jaarcijfers tot nu
    public List<KoffieBattle> JaarCijfer(string restaurant, int year)
    {
        using (var connection = new SqlConnection(_con))
        {
            var result = new List<KoffieBattle>();
            connection.Open();
            for (int i = 1; i <= 12; i++)
            {
                string sql = $@"select top 1 * from Koffiebattle
                                    where namerestaurant = '{restaurant}'
                                    and (MONTH(datum) = {i} AND YEAR(datum) = {year})
                                    order by datum desc";
                var resultQ = connection.Query<KoffieBattle>(sql).FirstOrDefault();
                if (resultQ != null)
                {
                    result.Add(resultQ);

                }
                else
                {
                    break;
                }
            }
            connection.Close();
            return result;

        }
    }
    // INSERT
    public bool InsertData(KoffieBattle koffieBattle)
    {

        string sql = @"INSERT KoffieBattle([Groot],[Medium],[NameRestaurant],[NameManager]) values (@Groot, @Medium, @NameRestaurant, @NameManager)";
        using (IDbConnection connection = new SqlConnection(_con))
        {
            int rowsAffected = connection.Execute
                (
                sql,
                new
                {
                    Groot = koffieBattle.Groot,
                    Medium = koffieBattle.Medium,
                    NameRestaurant = koffieBattle.NameRestaurant,
                    NameManager = koffieBattle.NameManager
                });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

    }
}
}
