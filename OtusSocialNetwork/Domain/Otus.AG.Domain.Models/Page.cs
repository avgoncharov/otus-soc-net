using System.Collections.Generic;

namespace Otus.AG.Domain.Models
{
	public sealed class Page<T>
	{
		public int RowPerPage { get; set; }
		public int PageNumber { get; set; }
		public IReadOnlyCollection<T> Items { get; set; }
	}
}