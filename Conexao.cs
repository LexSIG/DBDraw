using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace Random_Fun_Draw
{
	internal class Conexao
	{
		private static string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\asignori\\Documents\\Random Fun Draw\\Personagens.accdb";

		public Personagem BuscarPersonagem(int codigo)
		{
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand("Select Personagem.Nome, Raca, Serie from Personagem where Personagem.Codigo = @codigo");
			oleDbCommand.Connection = oleDbConnection;
			oleDbCommand.Parameters.Add(new OleDbParameter("@codigo", codigo));
			oleDbCommand.ExecuteNonQuery();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			Personagem personagem = new Personagem();
			if (oleDbDataReader.HasRows)
			{
				while (oleDbDataReader.Read())
				{
					personagem.Nome = ((DbDataReader)oleDbDataReader)["Nome"].ToString();
					personagem.Raca = ((DbDataReader)oleDbDataReader)["Raca"].ToString();
					personagem.Serie = Convert.ToInt32(((DbDataReader)oleDbDataReader)["Serie"].ToString());
				}
			}
			oleDbDataReader.Close();
			oleDbConnection.Close();
			return personagem;
		}

		public Personagem ListarPersonagem(int serie)
		{
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand obj = new OleDbCommand("Select Codigo, Nome, Raca, Codigo, Nome, Serie from Personagem where Serie = @serie Order by Codigo")
			{
				Connection = oleDbConnection,
				Parameters = 
				{
					new OleDbParameter("@serie", serie)
				}
			};
			DataTable dataTable = new DataTable();
			OleDbDataReader oleDbDataReader = obj.ExecuteReader();
			new Personagem();
			List<Personagem> list = new List<Personagem>();
			dataTable.Load(oleDbDataReader);
			foreach (DataRow row in dataTable.Rows)
			{
				list.Add(new Personagem
				{
					Codigo = Convert.ToInt32(row["Codigo"].ToString()),
					Nome = row["Nome"].ToString(),
					Raca = row["Raca"].ToString(),
					Serie = Convert.ToInt32(row["Serie"].ToString())
				});
			}
			oleDbDataReader.Close();
			oleDbConnection.Close();
			int num = new Random().Next(list.Count);
			if (num != 0)
			{
				return list[num];
			}
			return new Personagem
			{
				Nome = "erro"
			};
		}

		public IList<Personagem> ListarAllPersonagem()
		{
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand("Select Codigo, Nome from Personagem");
			oleDbCommand.Connection = oleDbConnection;
			oleDbCommand.ExecuteNonQuery();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			List<Personagem> list = new List<Personagem>();
			if (oleDbDataReader.HasRows)
			{
				while (oleDbDataReader.Read())
				{
					Personagem personagem = new Personagem();
					personagem.Codigo = Convert.ToInt32(((DbDataReader)oleDbDataReader)["codigo"].ToString());
					personagem.Nome = ((DbDataReader)oleDbDataReader)["Nome"].ToString();
					list.Add(personagem);
				}
			}
			oleDbDataReader.Close();
			oleDbConnection.Close();
			return list;
		}
		public int QuantidadePersonagem(int serie)
		{
			int result = 0;
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand("Select Count(Codigo) as Total from Personagem where Serie = @serie");
			oleDbCommand.Connection = oleDbConnection;
			oleDbCommand.Parameters.Add(new OleDbParameter("@serie", serie));
			oleDbCommand.ExecuteNonQuery();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.HasRows)
			{
				while (oleDbDataReader.Read())
				{
					result = Convert.ToInt32(((DbDataReader)oleDbDataReader)["Total"].ToString());
				}
			}
			oleDbDataReader.Close();
			oleDbConnection.Close();
			return result;
		}

		public int QuantidadeTotalPersonagem()
		{
			int result = 0;
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand("Select Count(Codigo) as Total from Personagem");
			oleDbCommand.Connection = oleDbConnection;
			oleDbCommand.ExecuteNonQuery();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.HasRows)
			{
				while (oleDbDataReader.Read())
				{
					result = Convert.ToInt32(((DbDataReader)oleDbDataReader)["Total"]);
				}
			}
			oleDbDataReader.Close();
			oleDbConnection.Close();
			return result;
		}

		public Roupa BuscarRoupa(int codigo)
		{
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand("Select Skin, Descricao from Roupa where Codigo = @codigo");
			oleDbCommand.Connection = oleDbConnection;
			oleDbCommand.Parameters.Add(new OleDbParameter("@codigo", codigo));
			oleDbCommand.ExecuteNonQuery();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			Roupa roupa = new Roupa();
			if (oleDbDataReader.HasRows)
			{
				while (oleDbDataReader.Read())
				{
					roupa.Skin = ((DbDataReader)oleDbDataReader)["Skin"].ToString();
					roupa.Descricao = ((DbDataReader)oleDbDataReader)["Descricao"].ToString();
				}
			}
			oleDbDataReader.Close();
			oleDbConnection.Close();
			return roupa;
		}

		public string BuscarSerie(int codigo)
		{
			string result = "";
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand("Select Nome from Serie where Codigo = @codigo");
			oleDbCommand.Connection = oleDbConnection;
			oleDbCommand.Parameters.Add(new OleDbParameter("@codigo", codigo));
			oleDbCommand.ExecuteNonQuery();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.HasRows)
			{
				while (oleDbDataReader.Read())
				{
					result = ((DbDataReader)oleDbDataReader)["Nome"].ToString();
				}
			}
			oleDbDataReader.Close();
			oleDbConnection.Close();
			return result;
		}

		public IList<Serie> buscarSeries()
		{
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand("Select Codigo, Nome from Serie Order By Nome");
			oleDbCommand.Connection = oleDbConnection;
			oleDbCommand.ExecuteNonQuery();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			List<Serie> list = new List<Serie>();
			if (oleDbDataReader.HasRows)
			{
				while (oleDbDataReader.Read())
				{
					Serie serie = new Serie();
					serie.Codigo = Convert.ToInt32(((DbDataReader)oleDbDataReader)["codigo"].ToString());
					serie.Nome = ((DbDataReader)oleDbDataReader)["Nome"].ToString();
					list.Add(serie);
				}
			}
			oleDbDataReader.Close();
			oleDbConnection.Close();
			return list;
		}

		public void SalvarSerie(string nome)
		{
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand("Insert into Serie(Nome) values (@nome)");
			oleDbCommand.Connection = oleDbConnection;
			oleDbCommand.Parameters.Add(new OleDbParameter("@nome", nome));
			try
			{
				oleDbCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oleDbConnection.Close();
			}
		}

		public void SalvarPersonagem(Personagem personagem)
		{
			OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand("Insert into Personagem(Nome, Raca, Serie) values (@nome, @raca, @serie)");
			oleDbCommand.Connection = oleDbConnection;
			oleDbCommand.Parameters.Add(new OleDbParameter("@nome", personagem.Nome));
			oleDbCommand.Parameters.Add(new OleDbParameter("@raca", personagem.Raca));
			oleDbCommand.Parameters.Add(new OleDbParameter("@serie", personagem.Serie));
			try
			{
				oleDbCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oleDbConnection.Close();
			}
		}
	}
}
