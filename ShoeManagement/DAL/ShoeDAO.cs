using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoeManagement.DTO;
using System.Data.SqlClient;

namespace ShoeManagement.DAL
{
    class ShoeDAO
    {
        public List<Shoe> SelectAll()
        {
            List<Shoe> shoes = new List<Shoe>();
            String strCon = "SERVER=den1.mssql8.gear.host;DATABASE=hungnguyen;USER=hungnguyen;PASSWORD=hungnguyen@571999!";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Shoe";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Shoe shoe = new Shoe()
                {
                    Code = (int)dr["Code"],
                    Name = (String)dr["Name"],
                    Type = (String)dr["Type"],
                    Size = (int)dr["Size"],
                    Price = (int)dr["Price"],
                };
                shoes.Add(shoe);
            }
            return shoes;
        }
        public bool Insert(Shoe newShoe)
        {
            String strCon = "SERVER=den1.mssql8.gear.host;DATABASE=hungnguyen;USER=hungnguyen;PASSWORD=hungnguyen@571999!";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "INSERT INTO Shoe VALUES(@Name,@Type,@Size,@Price)";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Name", newShoe.Name));
            com.Parameters.Add(new SqlParameter("@Type", newShoe.Type));
            com.Parameters.Add(new SqlParameter("@Size", newShoe.Size));
            com.Parameters.Add(new SqlParameter("@Price", newShoe.Price));
            try { return com.ExecuteNonQuery() > 0; }
            catch { return false; }
        }
        public bool Update(Shoe newShoe) 
        {
            String strCon = "SERVER=den1.mssql8.gear.host;DATABASE=hungnguyen;USER=hungnguyen;PASSWORD=hungnguyen@571999!";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "UPDATE Shoe SET Name=@Name,Type=@Type,Size=@Size,Price=@Price WHERE Code=@Code";
            SqlCommand com = new SqlCommand(strCom, con);           
            com.Parameters.Add(new SqlParameter("@Name", newShoe.Name));
            com.Parameters.Add(new SqlParameter("@Type", newShoe.Type));
            com.Parameters.Add(new SqlParameter("@Size", newShoe.Size));
            com.Parameters.Add(new SqlParameter("@Price", newShoe.Price));
            com.Parameters.Add(new SqlParameter("@Code", newShoe.Code));
            try { return com.ExecuteNonQuery() > 0; }
            catch { return false; }
        }
        public bool Delete(int code)
        {
            String strCon = "SERVER=den1.mssql8.gear.host;DATABASE=hungnguyen;USER=hungnguyen;PASSWORD=hungnguyen@571999!";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "DELETE FROM Shoe WHERE Code=@Code";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", code));
            try { return com.ExecuteNonQuery() > 0; }
            catch { return false; }
        }
        public List<Shoe> SelectByName(String keyword)
        {
            List<Shoe> shoes = new List<Shoe>();
            String strCon = "SERVER=den1.mssql8.gear.host;DATABASE=hungnguyen;USER=hungnguyen;PASSWORD=hungnguyen@571999!";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Shoe WHERE Name LIKE '%"+keyword+"%'";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Shoe shoe = new Shoe()
                {
                    Code = (int)dr["Code"],
                    Name = (String)dr["Name"],
                    Type = (String)dr["Type"],
                    Size = (int)dr["Size"],
                    Price = (int)dr["Price"],
                };
                shoes.Add(shoe);
            }
            return shoes;
        }
        public Shoe SelectByCode(int code)
        {
            String strCon = "SERVER=den1.mssql8.gear.host;DATABASE=hungnguyen;USER=hungnguyen;PASSWORD=hungnguyen@571999!";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Shoe WHERE Code="+ code;
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                Shoe shoe = new Shoe()
                {
                    Code = (int)dr["Code"],
                    Name = (String)dr["Name"],
                    Type = (String)dr["Type"],
                    Size = (int)dr["Size"],
                    Price = (int)dr["Price"],
                };
                return shoe;
            }
            return null;
        }
    }
}
