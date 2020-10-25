using System;
using System.Collections.Generic;

namespace Otus.AG.Domain.Models
{
	public class User: IEntity
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

		public UserType UserType { get; }

		public User(
			Guid id,
			Guid imageId,
			string firstName,
			string lastName,
			DateTime dateOfBirth,
			Gender gender,
			IReadOnlyCollection<string> interests,
			City city,
			IReadOnlyCollection<User> friends,
			UserType userType = UserType.Common)
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



		public static  User More { get; } =
			new User(
				Guid.Empty,
				Guid.Empty,
				"...",
				"...",
				DateTime.MinValue,
				Gender.Male,
				null,
				null,
				null,
				UserType.More);
	}
}