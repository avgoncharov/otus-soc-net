using System;
using System.Collections.Generic;

namespace Otus.AG.Domain.Models
{
	public sealed class User: IEntity
	{
		public Guid Id { get; }

		public Guid ImageId { get; }

		public string FirstName { get;  }
		public string LastName { get;  }
		public DateTime DateOfBirth { get; }
		public Gender Gender { get; }
		public IReadOnlyCollection<string> Interests { get; }
		public City City { get; }
		public IReadOnlyCollection<User> Friends { get; }

		public User(
			Guid id,
			Guid imageId,
			string firstName,
			string lastName,
			DateTime dateOfBirth,
			Gender gender,
			IReadOnlyCollection<string> interests,
			City city,
			IReadOnlyCollection<User> friends)
		{
			Id = id;
			ImageId = imageId;
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			Gender = gender;
			Interests = interests;
			City = city;
			Friends = friends;
		}

	}
}