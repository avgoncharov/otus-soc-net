using System;

namespace Otus.AG.Domain.Models
{
	public sealed class City:IEntity
	{
		public Guid Id { get;  }
		
		public string Name { get; }
		
		
		public City(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}