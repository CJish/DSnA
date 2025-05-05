using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA.DataStructures
{
    // Ege's code
    public class BSTExample
    {
        public static void RunExample()
        {
            // Sample list of products for the catalog
            Product[] products =
            {
            new Product(101, "Laptop", 1000),
            new Product(202, "Smartphone", 500),
            new Product(303, "Tablet", 300),
            new Product(404, "Monitor", 150),
            new Product(505, "Keyboard", 80)
            };

            Console.WriteLine("Adding Products to BST:");

            var bst = new BST();
            foreach (var product in products)
            {
                bst.Add(product);
            }

            Console.WriteLine("\nProducts in Order (by Product ID):");
            bst.DisplayInOrder();

            Console.WriteLine("\nSearching for Product with ID 303:");
            var searchResult = bst.Contains(303) ? "Found" : "Not Found";
            Console.WriteLine($"Product with ID 303: {searchResult}");

            Console.WriteLine("\nTop 5 Cheapest Products:");
            ShowTop5Cheapest(bst);
        }

        // Method to show the 5 cheapest products
        static void ShowTop5Cheapest(BST bst)
        {
            var products = bst.GetAllProducts();
            Array.Sort(products, (x, y) => x.Price.CompareTo(y.Price));

            for (int i = 0; i < Math.Min(5, products.Length); i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - ${products[i].Price}");
            }
        }

        // Performance benchmark for large datasets
        public static void RunBenchmark(int numberOfProducts)
        {
            Console.WriteLine($"Running benchmark with {numberOfProducts} products.");

            // Create a list of products with random prices and IDs
            var rng = new Random();
            var products = new Product[numberOfProducts];
            for (int i = 0; i < numberOfProducts; i++)
            {
                products[i] = new Product(i, $"Product {i}", rng.Next(50, 1000));
            }

            // Benchmark BST insertion
            var bst = new BST();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var product in products)
            {
                bst.Add(product);
            }
            stopwatch.Stop();
            Console.WriteLine($"BST - Time to insert {numberOfProducts} products: {stopwatch.ElapsedMilliseconds} ms");

            // Benchmark searching for a product
            int searchID = rng.Next(0, numberOfProducts);
            stopwatch.Restart();
            var found = bst.Contains(searchID);
            stopwatch.Stop();
            Console.WriteLine($"BST - Time to search for product ID {searchID}: {stopwatch.ElapsedMilliseconds} ms");

            // Benchmark sorting the products
            stopwatch.Restart();
            Array.Sort(products, (x, y) => x.Price.CompareTo(y.Price));
            stopwatch.Stop();
            Console.WriteLine($"Array Sort - Time to sort {numberOfProducts} products by price: {stopwatch.ElapsedMilliseconds} ms");
        }

        public static void RunTests()
        {
            Console.WriteLine("Product Catalog Example");
            // Real-world example of using BST
            BSTExample.RunExample();
            Console.WriteLine("\n--- Benchmarking ---");
            BSTExample.RunBenchmark(1000);
            BSTExample.RunBenchmark(10000);
            // BSTExample.RunBenchmark(100000);
            // running this 100,000 times causes stack overflow problems
            // because the tree is only right-sided and recursive
        }
    }

    public class Product
    {
        public int ProductID;
        public string Name;
        public double Price;

        public Product(int id, string name, double price)
        {
            ProductID = id;
            Name = name;
            Price = price;
        }
    }

    public class BSTNode
    {
        public Product Product;
        public BSTNode Left;
        public BSTNode Right;

        public BSTNode(Product product)
        {
            Product = product;
            Left = Right = null;
        }
    }

    public class BST
    {
        public BSTNode Root;

        public void Add(Product product)
        {
            Root = InsertNode(Root, product);
        }

        private BSTNode InsertNode(BSTNode node, Product product)
        {
            if (node == null)
                return new BSTNode(product);

            if (product.ProductID < node.Product.ProductID)
                node.Left = InsertNode(node.Left, product);
            else if (product.ProductID > node.Product.ProductID)
                node.Right = InsertNode(node.Right, product);
            else
                node.Product = product;

                return node;
        }

        public bool Contains(int productID)
        {
            return FindNode(Root, productID) != null;
        }

        private BSTNode FindNode(BSTNode node, int productID)
        {
            if (node == null)
                return null;

            if (node.Product.ProductID == productID)
                return node;

            return productID < node.Product.ProductID
                ? FindNode(node.Left, productID)
                : FindNode(node.Right, productID);
        }

        public void DisplayInOrder()
        {
            TraverseInOrder(Root);
            Console.WriteLine();
        }

        private void TraverseInOrder(BSTNode node)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left);
                Console.WriteLine($"{node.Product.ProductID}: {node.Product.Name} - ${node.Product.Price}");
                TraverseInOrder(node.Right);
            }
        }

        // Get all products for sorting or display
        public Product[] GetAllProducts()
        {
            var products = new List<Product>();
            GatherAllProducts(Root, products);
            return products.ToArray();
        }

        private void GatherAllProducts(BSTNode node, List<Product> products)
        {
            if (node != null)
            {
                GatherAllProducts(node.Left, products);
                products.Add(node.Product);
                GatherAllProducts(node.Right, products);
            }
        }
    }
}
