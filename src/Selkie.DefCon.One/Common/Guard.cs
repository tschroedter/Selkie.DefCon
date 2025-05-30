using System ;
using System.Runtime.CompilerServices ;
using JetBrains.Annotations ;

// ReSharper disable UnusedMember.Global

namespace Selkie.DefCon.One.Common
{
    [ UsedImplicitly ]
    public static class Guard
    {
        [ MethodImpl ( MethodImplOptions.AggressiveInlining ) ]
        public static void ArgumentBetween ( int                parameter ,
                                             [ NotNull ] string parameterName ,
                                             int                from ,
                                             int                to )
        {
            if ( parameter < from ||
                 parameter > to )
                throw new ArgumentException ( $"Value must be between {from} <= {parameter} <= {to}" ,
                                              parameterName ) ;
        }

        [ MethodImpl ( MethodImplOptions.AggressiveInlining ) ]
        public static void ArgumentNotEmptyOrWhitespace ( [ NotNull ] object parameter ,
                                                          [ NotNull ] string parameterName )
        {
            ArgumentNotNullOrEmpty ( parameter ,
                                     parameterName ) ;

            if ( parameter is string text &&
                 string.IsNullOrWhiteSpace ( text ) )
                throw new ArgumentException ( "Value cannot be whitespace" ,
                                              parameterName ) ;
        }

        [ MethodImpl ( MethodImplOptions.AggressiveInlining ) ]
        public static void ArgumentNotNegative ( int                parameter ,
                                                 [ NotNull ] string parameterName )
        {
            if ( parameter < 0 )
                throw new ArgumentException ( "Value cannot be negative" ,
                                              parameterName ) ;
        }

        [ MethodImpl ( MethodImplOptions.AggressiveInlining ) ]
        public static void ArgumentNotNull ( [ NotNull ] object parameter ,
                                             [ NotNull ] string parameterName )
        {
            if ( parameter == null ) throw new ArgumentNullException ( parameterName ) ;
        }

        [ MethodImpl ( MethodImplOptions.AggressiveInlining ) ]
        public static void ArgumentNotNullOrEmpty ( [ NotNull ] object parameter ,
                                                    [ NotNull ] string parameterName )
        {
            ArgumentNotNull ( parameter ,
                              parameterName ) ;

            if ( parameter is string { Length: 0 } )
                throw new ArgumentException ( "Value cannot be empty" ,
                                              parameterName ) ;
        }
    }
}