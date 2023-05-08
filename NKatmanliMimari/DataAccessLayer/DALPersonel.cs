using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler=new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("SELECT * FROM TblBilgi", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr=komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent=new EntityPersonel();
                ent.Id = int.Parse(dr["Id"].ToString());
                ent.Ad = dr["Ad"].ToString();
                ent.Soyad = dr["Soyad"].ToString();
                ent.Sehir = dr["Sehir"].ToString();
                ent.Gorev = dr["Gorev"].ToString();
                ent.Maas = short.Parse(dr["Maas"].ToString());  
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut2 = new SqlCommand("Insert Into TblBilgi (Ad,Soyad,Sehir,Gorev,Maas)  Values (@p1,@p2,@p3,@p4,@p5)",Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1",p.Ad);
            komut2.Parameters.AddWithValue("@p2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Sehir);
            komut2.Parameters.AddWithValue("@p4", p.Gorev);
            komut2.Parameters.AddWithValue("@p5", p.Maas);
            return komut2.ExecuteNonQuery();
        }
        
        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("DELETE FROM TblBilgi WHERE Id=@p1",Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p);
            return komut3.ExecuteNonQuery()>0;
        }

        public static bool PersonelGuncelle(EntityPersonel p)
        {
            SqlCommand komut4 = new SqlCommand("Update TblBilgi Set Ad=@p1,Soyad=@p2,Sehir=@p3,Gorev=@p4,Maas=@p5 WHERE Id=@p6",Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1",p.Ad);
            komut4.Parameters.AddWithValue("@p2", p.Soyad);
            komut4.Parameters.AddWithValue("@p3", p.Sehir);
            komut4.Parameters.AddWithValue("@p4", p.Gorev);
            komut4.Parameters.AddWithValue("@p5", p.Maas);
            komut4.Parameters.AddWithValue("@p6", p.Id);
            return komut4.ExecuteNonQuery() > 0;
        }

    }
}
