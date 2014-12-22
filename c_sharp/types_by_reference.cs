using System;

namespace CSharpDeepProbe{
    class PassingObjectExamples
    {
        class Test{
            public int i = 0;
        }
        static void Main()
        {
            var test = new Test();
            DoSome(test);
            Console.WriteLine(test.i);
            DoSomeStupid(test);
            Console.WriteLine(test.i);
            DoSomeCrazy(out test);
            Console.WriteLine(test.i);
            DoSomeMoreCrazy(ref test);
            Console.WriteLine(test.i);
        }

        static void DoSome(Test t)
        {
            t.i = 10;
        }

        static void DoSomeStupid(Test t){
            t = new Test { i = 20 };
        }

        static void DoSomeCrazy(out Test t)
        {
            t = new Test { i = 30 };
        }

        static void DoSomeMoreCrazy(ref Test t)
        {
            t = new Test { i = 40 };
        }
    }
}