﻿using System;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application
{
	public interface IProductService
	{
		List<Product> GetProducts();

	}
}

