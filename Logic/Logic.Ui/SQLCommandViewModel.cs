using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Videothek.Logic.Ui.ViewModel
{
	public class SQLCommandViewModel : MainViewModel
	{
		private static readonly SqlConnection con = new SqlConnection(@"Data Source = WINDOWS\SQLEXPRESS; Initial Catalog = Videothek; Integrated Security = True");


		#region Add Or Edit Kunde Table
		/// <summary>
		/// It Add's or Edit a Customer in SQL
		/// </summary>
		/// <param name="WhichCommand"></param>
		/// <param name="ID"></param>
		/// <param name="Name"></param>
		/// <param name="Vorname"></param>
		/// <param name="Strasse"></param>
		/// <param name="Hausnummer"></param>
		/// <param name="PLZ"></param>
		/// <param name="Ort"></param>
		/// <returns></returns>
		public bool AddOrEditKunde(string WhichCommand,int ID, string Name, string Vorname, string Strasse, string Hausnummer, int PLZ, string Ort)
		{
			if (WhichCommand == "Hinzufügen")
			{
				SqlCommand com = new SqlCommand("", con);
				try
				{
					con.Open();
					com.CommandText = "INSERT INTO Kunde (Name,Vorname,Strasse,Hausnummer,PLZ,Ort)" +
						" VALUES(@Name,@Vorname,@Strasse,@Hausnummer,@PLZ,@Ort)";
					com.Parameters.AddWithValue("@Name", Name);
					com.Parameters.AddWithValue("@Vorname", Vorname);
					com.Parameters.AddWithValue("@Strasse", Strasse);
					com.Parameters.AddWithValue("@Hausnummer", Hausnummer);
					com.Parameters.AddWithValue("@PLZ", PLZ);
					com.Parameters.AddWithValue("@Ort", Ort);
					com.ExecuteNonQuery();
					return true;
					
				}
				catch (System.Exception)
				{
					con.Close();
					return false;
				}
				finally
				{

					con.Close();
				}

			}
			else if(WhichCommand=="Bearbeiten")
			{
				SqlCommand com = new SqlCommand("", con);

				try
				{
					con.Open();
					com.CommandText = "UPDATE Kunde SET  Name = @Name, Vorname = @Vorname, Strasse = @Strasse, Hausnummer = @Hausnummer, PLZ = @PLZ, Ort = @Ort" +
						" WHERE ID = @ID";
					com.Parameters.AddWithValue("@ID", ID);
					com.Parameters.AddWithValue("@Name", Name);
					com.Parameters.AddWithValue("@Vorname", Vorname);
					com.Parameters.AddWithValue("@Strasse", Strasse);
					com.Parameters.AddWithValue("@Hausnummer", Hausnummer);
					com.Parameters.AddWithValue("@PLZ", PLZ);
					com.Parameters.AddWithValue("@Ort", Ort);
					com.ExecuteNonQuery();
					return true;
				}
				catch (System.Exception)
				{
					con.Close();
					return false;
				}
				finally
				{
					con.Close();
				}
			}
			return false;
		}
		#endregion

		#region Add Or Edit Artikel Table
		/// <summary>
		/// It Adds or Edit a Item in SQL
		/// </summary>
		/// <param name="WhichCommand"></param>
		/// <param name="ID"></param>
		/// <param name="Bezeichnung"></param>
		/// <param name="Menge"></param>
		/// <param name="Leihpreis"></param>
		/// <param name="KategorieID"></param>
		/// <returns></returns>
		public bool AddOrEditArtikel(string WhichCommand,int ID,string Bezeichnung,int Menge,double Leihpreis,int KategorieID)
		{
			if (WhichCommand == "Hinzufügen"&& KategorieID != 0)
			{
				SqlCommand com = new SqlCommand("", con);
				try
				{
					con.Open();
					com.CommandText = "INSERT INTO Artikel(Bezeichnung,Menge,Leihpreis,KategorieID)" +
						" VALUES(@Bezeichnung,@Menge,@Leihpreis,@KategorieID)";
					com.Parameters.AddWithValue("@Bezeichnung", Bezeichnung);
					com.Parameters.AddWithValue("@Menge", Menge);
					com.Parameters.AddWithValue("@Leihpreis", Leihpreis);
					com.Parameters.AddWithValue("@KategorieID", KategorieID);

					com.ExecuteNonQuery();
					return true;
				}
				catch (System.Exception)
				{
					con.Close();
					return false;

				}
				finally
				{
					con.Close();
				}
			}
			else if(WhichCommand == "Bearbeiten" && KategorieID != 0)
			{
				SqlCommand com = new SqlCommand("", con);

				try
				{
					con.Open();
					com.CommandText = "UPDATE Artikel SET Bezeichnung = @Bezeichnung, Menge = @Menge, Leihpreis = @Leihpreis, KategorieID = @KategorieID)" +
						" WHERE ID = @ID";
					com.Parameters.AddWithValue("@ID", ID);
					com.Parameters.AddWithValue("@Bezeichnung", Bezeichnung);
					com.Parameters.AddWithValue("@Menge", Menge);
					com.Parameters.AddWithValue("@Leihpreis", Leihpreis);
					com.Parameters.AddWithValue("@KategorieID", KategorieID);

					com.ExecuteNonQuery();
					return true;
				}
				catch (System.Exception)
				{
					con.Close();
					return false;
				}
				finally
				{
					con.Close();
				}
			}
			return false;
		}
		#endregion

		#region Add Or Edit Kategorie Table
		/// <summary>
		/// It Adds or Edit a Category in SQL
		/// </summary>
		/// <param name="WhichCommand"></param>
		/// <param name="ID"></param>
		/// <param name="Bezeichnung"></param>
		/// <returns></returns>
		public bool AddOrEditKategorie(string WhichCommand,int ID,string Bezeichnung)
		{
			if (WhichCommand == "Hinzufügen")
			{
				SqlCommand com = new SqlCommand("", con);
				try
				{
					con.Open();
					com.CommandText = "INSERT INTO Kategorie(Bezeichnung)" +
						" VALUES(@Bezeichnung)";
					com.Parameters.AddWithValue("@Bezeichnung", Bezeichnung);

					com.ExecuteNonQuery();
					return true;
				}
				catch (System.Exception)
				{
					con.Close();
					return false;
				}
				finally
				{
					con.Close();
				}
			}
			else if (WhichCommand == "Bearbeiten")
			{
				SqlCommand com = new SqlCommand("", con);

				try
				{
					con.Open();
					com.CommandText = "UPDATE Kategorie SET Bezeichnung = @Bezeichnung WHERE ID = @ID";
					com.Parameters.AddWithValue("@ID", ID);
					com.Parameters.AddWithValue("@Bezeichnung", Bezeichnung);

					com.ExecuteNonQuery();
					return true;
				}
				catch (System.Exception)
				{
					con.Close();
					return false;
				}
				finally
				{
					con.Close();
				}
			}
			return false;
		}
		#endregion

		#region Add Or Edit Art_Ausgeliehen Table
		/// <summary>
		/// It Adds or Edit a Item Borrowed in SQL
		/// </summary>
		/// <param name="WhichCommand"></param>
		/// <param name="ID"></param>
		/// <param name="KundeID"></param>
		/// <param name="ArtikelID"></param>
		/// <param name="Abgabedatum"></param>
		/// <param name="Leihdatum"></param>
		/// <returns></returns>
		public bool AddOrEditArt_Ausgeliehen(string WhichCommand, int ID, int KundeID,int ArtikelID,string Abgabedatum,string Leihdatum)
		{
			if (WhichCommand == "Hinzufügen" && KundeID!=0 && ArtikelID!=0 && Abgabedatum!="" && Leihdatum!="")
			{
				SqlCommand com = new SqlCommand("", con);
				try
				{
					con.Open();
					com.CommandText = "INSERT INTO Art_Ausgeliehen(KundeID,ArtikelID,Abgabedatum,Leihdatum)" +
						" VALUES(@KundeID,@ArtikelID,@Abgabedatum,@Leihdatum)";
					com.Parameters.AddWithValue("@KundeID", KundeID);
					com.Parameters.AddWithValue("@ArtikelID", ArtikelID);
					com.Parameters.AddWithValue("@Abgabedatum", Abgabedatum);
					com.Parameters.AddWithValue("@Leihdatum", Leihdatum);

					com.ExecuteNonQuery();

					return true;
				}
				catch (System.Exception)
				{
					con.Close();
					return false;
				}
				finally
				{
					con.Close();
				}


			}
			else if (WhichCommand == "Bearbeiten"&& ID!=0 && KundeID != 0 && ArtikelID != 0 && Abgabedatum != "" && Leihdatum != "")
			{
				SqlCommand com = new SqlCommand("", con);

				try
				{
					con.Open();
					com.CommandText = "UPDATE Art_Ausgeliehen SET KundeID = @KundeID, ArtikelID = @ArtikelID, Abgabedatum = @Abgabedatum, Leihdatum = @Leihdatum" +
						" WHERE ID = @ID";
					com.Parameters.AddWithValue("@ID", ID);
					com.Parameters.AddWithValue("@KundeID", KundeID);
					com.Parameters.AddWithValue("@ArtikelID", ArtikelID);
					com.Parameters.AddWithValue("@Abgabedatum", Abgabedatum);
					com.Parameters.AddWithValue("@Leihdatum", Leihdatum);

					com.ExecuteNonQuery();
					return true;
				}
				catch (System.Exception)
				{
					con.Close();
					return false;
				}
				finally
				{
					con.Close();
				}
			}
			return false;
		}
		#endregion

		#region Get SQL Table
		/// <summary>
		/// Get SQL Table Customer
		/// </summary>
		/// <returns></returns>
		public static List<CustomerTable> GetCustomerTable()
		{
			using (SqlCommand com = new SqlCommand("SELECT * FROM Kunde", con))
			{
				List<CustomerTable> ct = new List<CustomerTable>();
				com.CommandType = CommandType.Text;
				con.Open();
				using (SqlDataReader rd = com.ExecuteReader())
				{
					while (rd.Read())
					{
						ct.Add(new CustomerTable
						{
							ID = Convert.ToInt32(rd["ID"]),
							Name = rd["Name"].ToString(),
							Vorname = rd["Vorname"].ToString(),
							Strasse = rd["Strasse"].ToString(),
							Hausnummer = rd["Hausnummer"].ToString(),
							PLZ = Convert.ToInt32(rd["PLZ"]),
							Ort = rd["Ort"].ToString()
						});
					}
				}
				con.Close();
				return ct;
			}

		}

		/// <summary>
		/// Get SQL Table Item
		/// </summary>
		/// <returns></returns>
		public static List<ItemTable> GetItemTable()
		{
			using (SqlCommand com = new SqlCommand("SELECT * FROM Artikel", con))
			{
				List<ItemTable> it = new List<ItemTable>();
				com.CommandType = CommandType.Text;
				con.Open();
				using (SqlDataReader rd = com.ExecuteReader())
				{
					while (rd.Read())
					{
						it.Add(new ItemTable
						{
							ID = Convert.ToInt32(rd["ID"]),
							Bezeichnung = rd["Bezeichnung"].ToString(),
							Menge = Convert.ToInt32(rd["Menge"]),
							Leihpreis = Convert.ToDouble(rd["Leihpreis"]),
							KategorieID = Convert.ToInt32(rd["KategorieID"])

						});
					}

					con.Close();
					return it;
				}
			}
		}

		/// <summary>
		/// Get SQL Table Category
		/// </summary>
		/// <returns></returns>
		public static List<CategoryTable> GetCategoryTable()
		{
			using (SqlCommand com = new SqlCommand("SELECT * FROM Kategorie", con))
			{
				List<CategoryTable> ct = new List<CategoryTable>();
				com.CommandType = CommandType.Text;
				con.Open();
				using (SqlDataReader rd = com.ExecuteReader())
				{
					while (rd.Read())
					{
						ct.Add(new CategoryTable
						{
							ID = Convert.ToInt32(rd["ID"]),
							Bezeichnung = rd["Bezeichnung"].ToString(),
						});
					}
				}
				con.Close();
				return ct;
			}
		}

		/// <summary>
		/// Get SQL Table Item Borrowed
		/// </summary>
		/// <returns></returns>
		public static List<ItemBorrowedTable> GetItemBorrowedTable()
		{
			using (SqlCommand com = new SqlCommand("SELECT * FROM Art_Ausgeliehen", con))
			{
				List<ItemBorrowedTable> ibt = new List<ItemBorrowedTable>();
				com.CommandType = CommandType.Text;
				con.Open();
				using (SqlDataReader rd = com.ExecuteReader())
				{
					while (rd.Read())
					{
						ibt.Add(new ItemBorrowedTable
						{
							ID = Convert.ToInt32(rd["ID"]),
							KundeID = Convert.ToInt32(rd["KundeID"]),
							ArtikelID = Convert.ToInt32(rd["ArtikelID"]),
							Abgabedatum =Convert.ToDateTime(rd["Abgabedatum"]).ToString("dd/MM/yyyy"),
							Leihdatum = Convert.ToDateTime(rd["Leihdatum"]).ToString("dd/MM/yyyy")
						});
					}
				}
				con.Close();
				return ibt;
			}
		}
		#endregion

		#region DeleteRow
		/// <summary>
		/// Delete SQL ROW
		/// </summary>
		/// <param name="table"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public bool DeleteRow(string table,int ID)
		{

			SqlCommand com = new SqlCommand("", con);
			try
			{
				con.Open();
				com.CommandText = "DELETE FROM "+table+" WHERE ID = @ID";
				com.Parameters.AddWithValue("@ID", ID);


				com.ExecuteNonQuery();
				return true;
			}
			catch (System.Exception)
			{
				con.Close();
				return false;
			}
			finally
			{
				con.Close();
			}
		}
		#endregion
	}
}
