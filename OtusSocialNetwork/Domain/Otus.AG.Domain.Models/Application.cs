using System;

namespace Otus.AG.Domain.Models
{
	public sealed class Application: IEntity
	{
		public Guid Id { get; }
		public User Sender { get;  }
		public DateTime Date { get; }
		public bool Accepted { get; }

		public Application(Guid id, User sender, DateTime date, bool accepted)
		{
			Id = id;
			Sender = sender;
			Date = date;
			Accepted = accepted;
		}
	}
}