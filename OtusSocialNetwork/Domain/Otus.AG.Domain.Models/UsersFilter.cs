using System;
using System.Collections.Generic;

namespace Otus.AG.Domain.Models
{
	public struct UsersFilter : IPagedFilter
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public Gender? Gender { get; set; }
		public IReadOnlyCollection<string> Interests { get; set; }
		public City City { get; set; }
		public int RowPerPage { get; set; }
		public int PageNumber { get; set; }

		public bool IsEmpty { get; set; }

		public static UsersFilter Empty { get; } =
			new UsersFilter
			{
				RowPerPage = 30,
				PageNumber = 0,
				IsEmpty = true
			};
	}
}