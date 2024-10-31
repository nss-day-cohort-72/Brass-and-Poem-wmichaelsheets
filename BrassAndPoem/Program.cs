
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
var products = new List<Product>
{
    new Product {Name = "Trumpet", Price = 1345.67M, ProductTypeId = 1},
    new Product {Name = "Moonlit Serenade", Price = 25.11M, ProductTypeId = 2},
    new Product {Name = "Fairy's Dream", Price = 20.90M, ProductTypeId = 2},
    new Product {Name = "Tuba", Price = 4567.89M, ProductTypeId = 1},
    new Product {Name = "Whispering Wind", Price = 15.67M, ProductTypeId = 2}
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
var productTypes = new List<ProductType>
{
    new ProductType {Id = 1, Title = "Brass"},
    new ProductType {Id = 2, Title = "Poem"}
};
//put your greeting here
string greeting = @"Welcome to the Brass & Poem inventory system!
Please choose an option from the menu below.
   ";

Console.WriteLine(greeting);

//implement your loop here
int choice = 0;
while (choice != 5)
    DisplayMenu();


void DisplayMenu()
{
    Console.WriteLine(@"Choose an option:
                        1. Display all products
                        2. Delete a product
                        3. Add a new product
                        4. Update product properties
                        5. Exit");

    if (int.TryParse(Console.ReadLine(), out int result))
    {
        choice = result;
    }
    else
    {
        choice = 0;
    }

    switch (choice)
    {
        case 1:
            Console.WriteLine($"Display all products:");
            Console.WriteLine($" ");
            DisplayAllProducts(products, productTypes);
            break;

        case 2:
            Console.WriteLine("Delete a product:");
            Console.WriteLine($" ");
            DeleteProduct(products, productTypes);
            break;

        case 3:
            Console.WriteLine($"Add a new product:");
            Console.WriteLine($" ");
            AddProduct(products, productTypes);
            break;

        case 4:
            Console.WriteLine("Update product properties:");
            Console.WriteLine($" ");
            UpdateProduct(products, productTypes);
            break;

        case 5:
            Console.WriteLine("Getting you outta here!");
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("-------------");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name} at ${products[i].Price} (Type: {productTypes.FirstOrDefault(pt => pt.Id == products[i].ProductTypeId)?.Title})");
    }

    Console.WriteLine("-------------");
    Console.WriteLine();
}


void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Choose the product that you would like to delete:");
    Console.WriteLine();

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name} at ${products[i].Price} (Type: {productTypes.FirstOrDefault(pt => pt.Id == products[i].ProductTypeId)?.Title})");
    }

    Console.WriteLine("-------------");

    Console.WriteLine();

    int choose;
    while (true)
    {
        Console.Write("Enter the number of the product that you would like to delete (or 0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out choose) && choose >= 0 && choose <= products.Count)
        {
            break;
        }
        Console.WriteLine("Invalid input. Please try again.");
    }

    if (choose == 0)
    {
        Console.WriteLine("Deletion cancelled.");
        return;
    }

    int indexToRemove = choose - 1;
    Product productToRemove = products[indexToRemove];
    products.RemoveAt(indexToRemove);
    Console.WriteLine($"The product '{productToRemove.Name}' has been removed from the inventory.");
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Product newProduct = new Product();

    Console.Write("Enter the name of the product: ");
    newProduct.Name = Console.ReadLine();

    decimal price;
    Console.Write("Enter the selling price for {newProduct.name}: ");
    while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
    {
        Console.Write("Invalid input. Please enter a non-negative number: ");
    }
    newProduct.Price = price;

    Console.WriteLine("Select the product type:");

    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }

    int typeChoice;
    while (!int.TryParse(Console.ReadLine(), out typeChoice) || typeChoice < 1 || typeChoice > productTypes.Count)
    {
        Console.Write("Invalid input. Please enter a valid product type number: ");
    }
    newProduct.ProductTypeId = productTypes[typeChoice - 1].Id;

    products.Add(newProduct);

    Console.WriteLine($"New product has been added to the inventory.");
    Console.WriteLine($"Product Details: {newProduct.Name}, Price: ${newProduct.Price}, Type: {productTypes.First(pt => pt.Id == newProduct.ProductTypeId).Title}");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Choose the product that you would like to modify:");
    Console.WriteLine();

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name} at ${products[i].Price} (Type: {productTypes.FirstOrDefault(pt => pt.Id == products[i].ProductTypeId)?.Title})");
    }

    Console.WriteLine("-------------");

    Console.WriteLine();

    int choose;
    while (true)
    {
        Console.Write("Enter the number of the product that you would like to modify (or 0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out choose) && choose >= 0 && choose <= products.Count)
        {
            break;
        }
        Console.WriteLine("Invalid input. Please try again.");
    }

    if (choose == 0)
    {
        Console.WriteLine("Action cancelled.");
        return;
    }

    int indexToModify = choose - 1;
    Product productToUpdate = products[indexToModify];
    Console.WriteLine($"Selected product: {ProductDetails(productToUpdate)}");
    Console.WriteLine();

    Console.Write("Enter the new name (leave blank to keep the same): ");
    string newName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newName))
    {
        productToUpdate.Name = newName;
    }

    Console.Write("Enter the new selling price (leave blank to keep the same): ");
    decimal newPrice;
    if (decimal.TryParse(Console.ReadLine(), out newPrice))
    {
        productToUpdate.Price = newPrice;
    }

    Console.WriteLine("Enter the new product type (or 0 to keep the same): ");

    var productTypes = new List<ProductTypeId> { apparelType, potionsType, enchantedObjectsType, wandsType };
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }


    int newTypeChoice;
    if (int.TryParse(Console.ReadLine(), out newTypeChoice) && newTypeChoice > 0 && newTypeChoice <= productTypes.Count)
    {
        productToUpdate.ProductTypeId = productTypes[newTypeChoice - 1];
    }


    Console.WriteLine($"The product has been updated:");
    Console.WriteLine(ProductDetails(productToUpdate));
}
// don't move or change this!
public partial class Program { }