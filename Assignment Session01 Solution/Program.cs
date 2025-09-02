namespace Assignment_Session01_Solution

{
    using Demo.Data;
    

    internal class Program
    {
        static void Main(string[] args)
        {

            #region LINQ - Restriction Operators

            #region Q1- Find all products that are out of stock

            var result = from p in ListGenerator.ProductList
                         where p.UnitsInStock == 0
                         select p.ProductName;

            foreach (var name in result)
                Console.WriteLine(name);



            #endregion

            #region Q2- Find all products that are in stock and cost more than 3.00 per unit.

            var result = from p in ListGenerator.ProductList
                         where p.UnitsInStock > 0 && p.UnitPrice > 3.00M
                         select new { p.ProductName, p.UnitsInStock, p.UnitPrice };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitsInStock} units - ${item.UnitPrice}");
            }


            #endregion

            #region Q3- Returns digits whose name is shorter than their value.

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = from word in Arr.Select((name, index) => new { name, index })
                         where word.name.Length < word.index
                         select new { word.index, word.name };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.index} - {item.name}");
            }

            #endregion




            #endregion

            #region LINQ - Ordering Operators

            #region Q1- Sort a list of products by name

            var result = from p in ListGenerator.ProductList
                         orderby p.ProductName
                         select p;

            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProductID} - {item.ProductName} - {item.UnitPrice} - {item.UnitsInStock}");
            }


            #endregion

            #region Q2- Uses a custom comparer to do a case-insensitive sort of the words in an array.

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result = from word in Arr
                         orderby word.ToLower()  /// نخلي كل الكلمات lowercase علشان المقارنة
                         select word;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Q3- Sort a list of products by units in stock from highest to lowest.
            var result = from p in ListGenerator.ProductList
                         orderby p.UnitsInStock descending
                         select p;

            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitsInStock}");
            }


            #endregion

            #region Q4- Sort a list of digits, first by length of their name, and then alphabetically by the name itself.

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = from d in Arr
                         orderby d.Length, d
                         select d;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            / عملته علي حسب فهمي للمطلوب
            #endregion

            #region Q5- Sort first by-word length and then by a case-insensitive sort of the words in an array.

            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result = from w in Arr
                         orderby w.Length, w.ToLower() /// نخلي كل الكلمات lowercase علشان المقارنة
                         select w;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Q6- Sort a list of products, first by category, and then by unit price, from highest to lowest.

            var result = from p in ListGenerator.ProductList
                         orderby p.Category, p.UnitPrice descending
                         select p;

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Category} - {item.ProductName} - {item.UnitPrice}");
            }


            #endregion

            #region Q7- Sort first by-word length and then by a case-insensitive descending sort of the words in an array.

            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result =
            from word in Arr
            orderby word.Length, word.ToLower() descending
            select word;

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }

            #endregion

            #region Q8- Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result =
            (from digit in Arr
             where digit.Length > 1 && digit[1] == 'i'
             select digit).Reverse();

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }

            #endregion

            #endregion

            #region LINQ – Transformation Operators

            #region 1- Return a sequence of just the names of a list of products.

            List<Product> products = new List<Product>
            {
                new Product { ProductID = 1, ProductName = "Apple", Category = "Fruit", UnitPrice = 10, UnitsInStock = 50 },
                new Product { ProductID = 2, ProductName = "Carrot", Category = "Vegetable", UnitPrice = 5, UnitsInStock = 100 },
                new Product { ProductID = 3, ProductName = "Milk", Category = "Dairy", UnitPrice = 15, UnitsInStock = 20 }
            };

            var result =
                from p in products
                select p.ProductName;

            foreach (var name in result)
            {
                Console.WriteLine(name);
            }

            #endregion

            #region Q2- Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).

            String[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var result =
            from w in words
            select new
            {
                Upper = w.ToUpper(),
                Lower = w.ToLower()
            };

            foreach (var item in result)
            {
                Console.WriteLine($"Upper: {item.Upper}, Lower: {item.Lower}");
            }

            #endregion

            #region Q3- Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

            List<Product> products = new List<Product>
            {
                new Product { ProductID = 1, ProductName = "Apple", Category = "Fruits", UnitPrice = 10.5m, UnitsInStock = 50 },
                new Product { ProductID = 2, ProductName = "Carrot", Category = "Vegetables", UnitPrice = 5m, UnitsInStock = 100 },
                new Product { ProductID = 3, ProductName = "Milk", Category = "Dairy", UnitPrice = 20m, UnitsInStock = 30 }
            };

            var result =
                from p in products
                select new
                {
                    p.ProductID,
                    p.ProductName,
                    Price = p.UnitPrice   // Rename
                };

            foreach (var item in result)
            {
                Console.WriteLine($"ID: {item.ProductID}, Name: {item.ProductName}, Price: {item.Price}");
            }

            #endregion

            #region Q4- Determine if the value of int in an array matches their position in the array.

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result = Arr.Select((num, index) => new
            {
                Number = num,
                InPlace = (num == index)
            });

            Console.WriteLine("Number: In Place?");
            foreach (var item in result)
            {
                Console.WriteLine($"Number: {item.Number} : {item.InPlace}");
            }


            #endregion

            #region Q5- Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.

            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs =
                 from a in numbersA
                 from b in numbersB
                 where a < b
                 select new { A = a, B = b };

            Console.WriteLine("Pairs Where a < b :");
            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.A} is less than {pair.B}");
            }


            #endregion

            #region Q6- Select all orders where the order total is less than 500.00.

            List<Order> orders = new List<Order>
            {
                new Order(1, DateTime.Now.AddDays(-10), 250m),
                new Order(2, DateTime.Now.AddDays(-5), 1200m),
                new Order(3, DateTime.Now.AddDays(-3), 499.99m),
                new Order(4, DateTime.Now.AddDays(-1), 800m),
                new Order(5, DateTime.Now, 150m)
            };

            var smallOrders =
                from o in orders
                where o.Total < 500m
                select o;

            Console.WriteLine("Orders with Total < 500:");
            foreach (var order in smallOrders)
            {
                Console.WriteLine(order);
            }

            #endregion

            #region Q7- Select all orders where the order was made in 1998 or later.

            List<Order> orders = new List<Order>
        {
            new Order(1, new DateTime(1997, 12, 31), 250.00m),
            new Order(2, new DateTime(1998, 1, 15), 450.00m),
            new Order(3, new DateTime(2000, 5, 10), 800.00m),
            new Order(4, new DateTime(1996, 3, 20), 120.00m),
            new Order(5, new DateTime(1999, 7, 25), 600.00m)
        };

            var ordersFrom1998 =
                from o in orders
                where o.OrderDate.Year >= 1998
                select o;

            Console.WriteLine("Orders from 1998 or later:");
            foreach (var order in ordersFrom1998)
            {
                Console.WriteLine(order);
            }

            #endregion

            #endregion

        }
    }
}
