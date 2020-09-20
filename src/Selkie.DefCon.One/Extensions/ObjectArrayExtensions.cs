using System ;
using System.Reflection ;
using System.Text ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Extensions
{
    public static class ObjectArrayExtensions
    {
        [ NotNull ]
        public static string ToText ( this Type [ ] parameters )
        {
            var builder = new StringBuilder ( ) ;

            for ( var index = 0 ; index < parameters.Length ; index ++ )
            {
                object parameter = parameters [ index ] ;

                if ( index != 0 &&
                     index < parameters.Length )
                    builder.Append ( ", " ) ;

                switch ( parameter )
                {
                    case null :
                        builder.Append ( "null" ) ;
                        continue ;
                    default :
                        builder.Append ( parameter ) ;
                        break ;
                }
            }

            return builder.ToString ( ) ;
        }

        [ NotNull ]
        public static string ToText ( this object [ ] parameters )
        {
            var builder = new StringBuilder ( ) ;

            for ( var index = 0 ; index < parameters.Length ; index ++ )
            {
                var parameter = parameters [ index ] ;

                if ( index != 0 &&
                     index < parameters.Length )
                    builder.Append ( ", " ) ;

                switch ( parameter )
                {
                    case null :
                        builder.Append ( "null" ) ;
                        continue ;
                    case ParameterInfo info :
                        builder.Append ( info.ParameterType.FullName ) ;
                        continue ;
                    default :
                        builder.Append ( parameter ) ;
                        break ;
                }
            }

            return builder.ToString ( ) ;
        }
    }
}