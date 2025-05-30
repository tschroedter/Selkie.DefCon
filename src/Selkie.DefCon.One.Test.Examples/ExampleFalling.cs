using System.Diagnostics.CodeAnalysis ;

// ReSharper disable UnusedMember.Global

namespace Selkie.DefCon.One.Test.Examples ;

[ ExcludeFromCodeCoverage ]
public class ExampleFalling
    : ExampleBase
{
    public ExampleFalling ( )
    {
        Integer1 = 0 ;
        Object1  = new object ( ) ;
        Object2  = new object ( ) ;
        Object3  = new object ( ) ;
        Integer2 = 0 ;
    }

    public ExampleFalling ( object object1 )
    {
        Integer1 = 0 ;
        Object1  = object1 ;
        Object2  = new object ( ) ;
        Object3  = new object ( ) ;
        Integer2 = 0 ;
    }

    public ExampleFalling ( object object1 ,
                            object object2 )
    {
        Integer1 = 0 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = new object ( ) ;
        Integer2 = 0 ;
    }

    public ExampleFalling ( object object1 ,
                            object object2 ,
                            object object3 )
    {
        Integer1 = 0 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = object3 ;
        Integer2 = 0 ;
    }

    public ExampleFalling ( int    integer1 ,
                            object object1 ,
                            object object2 ,
                            object object3 )
    {
        Integer1 = integer1 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = object3 ;
        Integer2 = 0 ;
    }

    public ExampleFalling ( object object1 ,
                            object object2 ,
                            object object3 ,
                            int    integer2 )
    {
        Integer1 = 0 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = object3 ;
        Integer2 = integer2 ;
    }

    public ExampleFalling ( int    integer1 ,
                            object object1 ,
                            object object2 ,
                            object object3 ,
                            int    integer2 )
    {
        Integer1 = integer1 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = object3 ;
        Integer2 = integer2 ;
    }
}