using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPrice {
    internal class Menu {
        public static Dictionary<int, MenuItem> MenuItems = new() {
            { 1, new MenuItem( "Show products", Program.ShowProducts ) },
            { 2, new MenuItem( "Buy product", Program.BuyProduct ) },
            { 0, new MenuItem( "Exit", () => Environment.Exit( 0 ) ) }
        };

        public static void ShowMenu() {
            foreach ( (int index, MenuItem item) in MenuItems ) {
                Console.WriteLine( $"{index}. {item.Name}" );
            }
        }

        public static void Run() {
            while ( true ) {
                ShowMenu();

                Console.Write( "> " );
                int input = Helpers.IntValidator( Console.ReadLine() );
                Console.WriteLine();

                if ( MenuItems.ContainsKey( input ) ) {
                    MenuItems[ input ].Action.Invoke();
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine( $"Option entered ({input}) does not exist. Press any key to try again..." );
                    Console.ResetColor();
                    Console.ReadKey();
                }

                Console.WriteLine();
            }
        }

        internal class MenuItem {
            public string Name { get; }
            public Action Action { get; }
            public MenuItem( string name, Action action ) {
                Name = name;
                Action = action;
            }
        }
    }
}
