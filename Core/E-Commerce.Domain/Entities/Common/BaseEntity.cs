using System;
namespace E_Commerce.Domain.Entities.Common
{
	public abstract class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}

