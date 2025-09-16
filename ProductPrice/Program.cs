

namespace ProductPrice {
    class Program {
        public const string CURRENCY = "SEK";

        public static Dictionary<int, ProductItem> products = new() {
            { 1, new ProductItem( "Apple", 5.00 ) },
            { 2, new ProductItem( "Banana", 3.00 ) },
            { 3, new ProductItem( "Orange", 4.00 ) },
        };

        static double CalculateTotal( string product, double price, int quantity, double tax = 0.25 ) => price * quantity * (1 + tax);

        public static void ShowProducts() {
            foreach( var product in products ) {
                Console.WriteLine( $"{product.Key}. {product.Value.Name} - {product.Value.Price} {CURRENCY}" );
            }
        }

        public static void BuyProduct() {
            Console.WriteLine( "---------------BUY PRODUCT---------------" );
            ShowProducts();
            Console.WriteLine( "-----------------------------------------" );
            Console.Write( "Select product: " );
            int productId = Helpers.IntValidator( Console.ReadLine() );
            Console.Write( "Quantity: " );
            int quantity = Helpers.IntValidator( Console.ReadLine() );
            Console.Write( "Tax: " );
            double tax = Helpers.DoubleValidator( Console.ReadLine() );
            
            if( tax != 0 ) {
                Console.WriteLine(
                    $"You bought {quantity} {products[ productId ].Name} for {CalculateTotal( products[ productId ].Name, products[ productId ].Price, quantity, tax )} {CURRENCY}"
                );
            } else {
                Console.WriteLine(
                    $"You bought {quantity} {products[ productId ].Name} for {CalculateTotal( products[ productId ].Name, products[ productId ].Price, quantity )} {CURRENCY}"
                );
            }
        }

        static void Main(string[] args) {
            Menu.Run();
        }
    }

    class ProductItem {
        public string Name { get; }
        public double Price { get; }

        public ProductItem( string name, double price ) {
            Name = name;
            Price = price;
        }
    }
}