using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Otus.AG.Domain.Models;
using Otus.AG.Domain.Services;
using MySql.Data.MySqlClient;

namespace Otus.AG.Infra.DAL.MySql
{
	internal sealed class CitiesRepository : ICitiesRepository
	{
		private readonly MySqlConnection _connection;

		public CitiesRepository(MySqlConnection connection)
		{
			_connection = connection;
		}

		public async Task<Page<City>> GetCitiesAsync(
			string template,
			int rowPerPage,
			int pageNumber,
			CancellationToken token)
		{
			await using var cmd = _connection.CreateCommand();
			
			cmd.CommandText = SelectByTemplate;
			cmd.CommandType = CommandType.Text;
			var templateParam = new MySqlParameter("@temmplate", MySqlDbType.VarChar) {Value = $"{template}%"};
			cmd.Parameters.Add(templateParam);
			
			var rppParam = new MySqlParameter("@rpp", MySqlDbType.Int32) {Value = rowPerPage+1};
			cmd.Parameters.Add(rppParam);
			
			var offsetParam = new MySqlParameter("@offset", MySqlDbType.Int32) {Value = rowPerPage * pageNumber};
			cmd.Parameters.Add(offsetParam);
			
			await using var reader = await cmd.ExecuteReaderAsync(token).ConfigureAwait(false);
			if (reader.HasRows != true)
			{
				return new Page<City>
				{
					PageNumber = pageNumber,
					RowPerPage = rowPerPage,
					Items = Array.Empty<City>()
				};
			}
			
			
			var i = 0;
			var result = new List<City>();
			while (await reader.ReadAsync(token).ConfigureAwait(false))
			{
				if (i <= rowPerPage)
				{
					result.Add(new City(Guid.Parse(reader[0].ToString()),
						reader[1].ToString()));
				}
				else
				{
					result.Add(new City(Guid.Empty, "..."));
				}

			}

			return new Page<City>
			{
				PageNumber = pageNumber,
				RowPerPage = rowPerPage,
				Items = result.AsReadOnly()
			};

		}

		public async Task<City> GetCityByIdAsync(Guid id, CancellationToken token)
		{
			await using var cmd = _connection.CreateCommand();
			
			cmd.CommandText = SelectById;
			cmd.CommandType = CommandType.Text;
			var p = new MySqlParameter("@currId", MySqlDbType.Guid) {Value = id};
			cmd.Parameters.Add(p);
			
			await using var reader = await cmd.ExecuteReaderAsync(token).ConfigureAwait(false);
			if (reader.HasRows)
			{
				await reader.ReadAsync(token).ConfigureAwait(false);
				return new City(Guid.Parse(reader[0].ToString()), reader[1].ToString());
			}

			return null;
		}

		public async Task<City> GetCityByNameIdAsync(string name, CancellationToken token)
		{
			await using var cmd = _connection.CreateCommand();
			
			cmd.CommandText = SelectByName;
			cmd.CommandType = CommandType.Text;
			var p = new MySqlParameter("@name", MySqlDbType.VarChar) {Value = name};
			cmd.Parameters.Add(p);
			
			await using var reader = await cmd.ExecuteReaderAsync(token).ConfigureAwait(false);
			if (reader.HasRows)
			{
				await reader.ReadAsync(token).ConfigureAwait(false);
				return new City(Guid.Parse(reader[0].ToString()), reader[1].ToString());
			}

			return null;
		}


		private const string SelectById =
			"select BIN_TO_UUID(id) id, name from cities where id = UUID_TO_BIN(@currId)";
		
		
		private const string SelectByName =
			"select BIN_TO_UUID(id) id, name from cities where name = @name";


		private const string SelectByTemplate =
			"select BIN_TO_UUID(id) id, name from cities where name like @temmplate order by name limit @rpp offset @offset";
	}
}