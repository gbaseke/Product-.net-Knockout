using Test.Entities;

namespace Test.Models;

public static class ProductExt
{
    public static ProductViewModel From(this Product  product)
    {
        return new ProductViewModel() 
        { 
            Id = product.Id, 
            Name = product.Name,
            Category = product.Category,
            Price = product.Price
        };
    }

    public static Product To(this ProductViewModel  vm)
    {   
        return new Product() 
        { 
            Id = vm.Id, 
            Name = vm.Name,
            Category = vm.Category,
            Price = vm.Price
        };
    }
}       