namespace Otus.AG.Domain.Models
{
	public interface IPagedFilter
	{
		public int RowPerPage { get; }
		public int PageNumber { get; }
	}
}