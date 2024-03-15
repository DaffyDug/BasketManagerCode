using System;
using System.Collections.Generic; 

class BasketManager 
{
    public static readonly BasketManager basketManager;
    public List<Product> products = new List<Product>();
    private BasketManager()
    { }
    static BasketManager()
    {
        basketManager = new BasketManager();
    }
    public void Add(Product product)
    {
        products.Add(product);
    }
    public void Remuve(int index)
    {
        products.RemoveAt(index);
    }
    public void PrintInfo()
    {
        for (int i = 0; i < products.Count; i++)
        {
            Product item = products[i];
            Console.WriteLine($"{i + 1}--{item.Name_Produrt}");
        }
    }
    public void PrintInfoCategoryProduct()
    {
        for (int i = 0; i < products.Count; i++)
        {
            Product item = products[i];
            Console.WriteLine($"{i}--{item}");
        }
    }
}
public class Product
{
    public string Name_Produrt { get; }
    public double Price { get; }
    public CategoryProduct _Category { get; }

    public Product(string name_product, double price, CategoryProduct _Product)
    {
        Name_Produrt = name_product;
        Price = price;
        this._Category = _Product;
    }
}
class AddProduct : ICommandBasket, IInfoEnum_CategoryProduct
{
    public void Run()
    {
        Console.WriteLine("\nвведите название продукта: ");
        string nameproduct = Console.ReadLine();
        Console.WriteLine("введите цену продука: ");
        if (!int.TryParse(Console.ReadLine(), out int value))
        {
            Console.WriteLine("нельзя воодить пустые символы");
            return;
        }
        Console.WriteLine("выберите катергорию продукта: ");
        ShowEnum_CategoryProduct();
        Array colection = Enum.GetValues(typeof(CategoryProduct));
        if (InputHelper.Input("\nкакую котегорию хотите выбрать? ", 1, colection.Length, out int value2))
        {
            CategoryProduct categoryProduct = (CategoryProduct)value2;
            if (!string.IsNullOrEmpty(nameproduct))
            {
                Product product = new Product(nameproduct, value, categoryProduct);
                BasketManager.basketManager.Add(product);
                Console.WriteLine("продукт добавлен\n");
            }
            else
            {
                Console.WriteLine("нельзя воодить пустые символы");
            }
        }
    }
    public void ShowEnum_CategoryProduct()
    {
        var colection = Enum.GetValues(typeof(CategoryProduct));
        System.Collections.IList list = colection;
        for (int i = 0; i < list.Count; i++)
        {
            object item = list[i];
            Console.WriteLine($"{i + 1}--{item.ToString()}");
        }
    }
}
class RemoveProduct : ICommandBasket
{
    public void Run()
    {
        BasketManager.basketManager.PrintInfo();
        if (InputHelper.Input("какой продукт вы хотите удалить: ", 1, BasketManager.basketManager.products.Count, out int intvalue))
        {
            BasketManager.basketManager.Remuve(intvalue - 1);
        }
        Console.WriteLine("продукт удален\n");
    }
}
class Printinfo : ICommandBasket
{
    public void Run()
    {
        if (BasketManager.basketManager.products.Count != 0)
        {
            BasketManager.basketManager.PrintInfo();
            if (BasketManager.basketManager.products.Count > 0)
            {
                if (InputHelper.Input("о каком продукте вы хотите узнать информацию:\n ", 1, BasketManager.basketManager.products.Count, out int inputvalue))
                {
                    var nameproduct = BasketManager.basketManager.products[inputvalue - 1].Name_Produrt;
                    var priceproduct = BasketManager.basketManager.products[inputvalue - 1].Price;
                    var category = BasketManager.basketManager.products[inputvalue - 1]._Category;

                    Console.WriteLine($"имя продукта: {nameproduct}\nцена продукта: {priceproduct}\nкатегория продукта: {category}");
                }
            }

        }
        else
        {
            Console.WriteLine("путсо!");
        }
    }
}
class PrintinfoCategoryProduct : ICommandBasket
{
    public void Run()
    {
        Array collection = Enum.GetValues(typeof(CategoryProduct));
        BasketManager.basketManager.PrintInfoCategoryProduct();
        if (BasketManager.basketManager.products.Count != 0)
        {
            System.Collections.IList list = collection;
            for (int i = 0; i < list.Count; i++)
            {
                object item = list[i];
                Console.WriteLine($"{i + 1}--{item}");
            }
            if (InputHelper.Input("Выберите категорию о которой хотите получить инфу: ", 1, collection.Length, out int inputvalue))
            {
                List<Product> products = new List<Product>();
                foreach (var item in BasketManager.basketManager.products)
                {
                    if (item._Category == (CategoryProduct)inputvalue)
                    {
                        products.Add(item);
                        Console.WriteLine(item.Name_Produrt);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("пусто!");
        }
    }
}
public enum CategoryProduct
{
    vegetables = 1,
    bakery,
    fruits
}
