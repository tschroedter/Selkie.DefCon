// ReSharper disable NotAccessedField.Local
// ReSharper disable UnusedMember.Global

using System.Diagnostics.CodeAnalysis ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.Test.Examples ;

[ ExcludeFromCodeCoverage ]
public class ExamplePassing
    : ExampleBase
{
    public ExamplePassing ( )
    {
        Integer1 = 0 ;
        Object1  = new object ( ) ;
        Object2  = new object ( ) ;
        Object3  = new object ( ) ;
        Integer2 = 0 ;
    }

    public ExamplePassing ( object object1 )
    {
        Guard.ArgumentNotNull ( object1 ,
                                nameof ( object1 ) ) ;

        Integer1 = 0 ;
        Object1  = object1 ;
        Object2  = new object ( ) ;
        Object3  = new object ( ) ;
        Integer2 = 0 ;
    }

    public ExamplePassing ( object object1 ,
                            object object2 )
    {
        Guard.ArgumentNotNull ( object1 ,
                                nameof ( object1 ) ) ;
        Guard.ArgumentNotNull ( object2 ,
                                nameof ( object2 ) ) ;

        Integer1 = 0 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = new object ( ) ;
        Integer2 = 0 ;
    }

    public ExamplePassing ( object object1 ,
                            object object2 ,
                            object object3 )
    {
        Guard.ArgumentNotNull ( object1 ,
                                nameof ( object1 ) ) ;
        Guard.ArgumentNotNull ( object2 ,
                                nameof ( object2 ) ) ;
        Guard.ArgumentNotNull ( object3 ,
                                nameof ( object3 ) ) ;

        Integer1 = 0 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = object3 ;
        Integer2 = 0 ;
    }

    public ExamplePassing ( int    integer1 ,
                            object object1 ,
                            object object2 ,
                            object object3 )
    {
        Guard.ArgumentNotNull ( object1 ,
                                nameof ( object1 ) ) ;
        Guard.ArgumentNotNull ( object2 ,
                                nameof ( object2 ) ) ;
        Guard.ArgumentNotNull ( object3 ,
                                nameof ( object3 ) ) ;

        Integer1 = integer1 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = object3 ;
        Integer2 = 0 ;
    }

    public ExamplePassing ( object object1 ,
                            object object2 ,
                            object object3 ,
                            int    integer2 )
    {
        Guard.ArgumentNotNull ( object1 ,
                                nameof ( object1 ) ) ;
        Guard.ArgumentNotNull ( object2 ,
                                nameof ( object2 ) ) ;
        Guard.ArgumentNotNull ( object3 ,
                                nameof ( object3 ) ) ;

        Integer1 = 0 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = object3 ;
        Integer2 = integer2 ;
    }

    public ExamplePassing ( int    integer1 ,
                            object object1 ,
                            object object2 ,
                            object object3 ,
                            int    integer2 )
    {
        Guard.ArgumentNotNull ( object1 ,
                                nameof ( object1 ) ) ;
        Guard.ArgumentNotNull ( object2 ,
                                nameof ( object2 ) ) ;
        Guard.ArgumentNotNull ( object3 ,
                                nameof ( object3 ) ) ;

        Integer1 = integer1 ;
        Object1  = object1 ;
        Object2  = object2 ;
        Object3  = object3 ;
        Integer2 = integer2 ;
    }
}