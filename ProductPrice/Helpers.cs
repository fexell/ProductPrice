using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPrice {
    internal class Helpers {
        public static int IntValidator( string value ) {
            while( true ) {
                if( int.TryParse( value, out int result ) ) {
                    return result;
                } else {
                    Console.Write( "Invalid input. Please try again: " );
                    value = Console.ReadLine();
                }
            }
        }

        public static double DoubleValidator( string? value = null ) {
            if ( value == null || value == "" )
                return 0;

            value = value.Replace( '.', ',' );

            while( true ) {
                if( double.TryParse( value, out double result ) ) {
                    return result;
                } else {
                    Console.Write( "Invalid input. Please try again: " );
                    value = Console.ReadLine();
                }
            }
        }
    }
}
