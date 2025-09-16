

namespace ProductPrice {
    class Program {
        public static string currency = "SEK";
        public static Dictionary<string, double> products = new() {
            { "Apple", 5.00 },
            { "Banana", 5.50 },
            { "Orange", 5.25 }
        };

        static double CalculateTotal( string product, double price, int quantity, double tax = 0.25 ) => price * quantity * (1 + tax);

        public static void ShowProducts() {
            foreach ( var product in products.Select((item, index) => new { item, index } ) ) {
                Console.WriteLine($"Product {product.index + 1}: {product.item.Key} | Price: {product.item.Value} {currency}");
            }
        }

        static void Main(string[] args) {
            Menu.Run();
        }
    }
}