using System.Reflection;
using System.Security.Cryptography;

namespace L20250217
{
    internal class Program
    {
        #region Reflection
        //class Data
        //{
        //    public void Count()
        //    {
        //        Console.WriteLine("Count");
        //    }

        //    private void FuncA()
        //    {
        //        Console.WriteLine("private FuncA by 태규");
        //    }

        //    protected void Sum()
        //    {
        //        Console.WriteLine("protected Sum by 명찬");
        //    }

        //    public static void StaticFunction()
        //    {
        //        Console.WriteLine("StaticFunction");
        //    }

        //    public static void Add(int A, int B)
        //    {
        //        Console.WriteLine($"{A} + {B} = {A + B}");
        //    }

        //    public int Gold = 1;

        //    protected int Money = -1000;

        //    private float HP = -10.5f;

        //    public int MP
        //    {
        //        get;
        //        set;
        //    }
        //} 
        #endregion

        static void Main(string[] args)
        {
            #region Reflection
            //Data d = new Data();
            //Type classType = d.GetType();

            //// 메소드 리플렉션
            //MethodInfo[] methods = classType.GetMethods(BindingFlags.Public |
            //    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            //foreach (MethodInfo info in methods)
            //{
            //    //Console.WriteLine($"{info.Name}");
            //    if (info.Name.CompareTo("Add") == 0)
            //    {
            //        ParameterInfo[] paramInfos = info.GetParameters();
            //        foreach (ParameterInfo paramInfo in paramInfos)
            //        {
            //            Console.WriteLine(paramInfo.Name);
            //        }

            //        Object[] param = { 3, 5 };
            //        info.Invoke(d, param);
            //    }
            //}

            //// 필드 리플렉션
            //FieldInfo[] fields = classType.GetFields(BindingFlags.Public |
            //    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            //foreach (FieldInfo field in fields)
            //{
            //    Console.WriteLine($"{field.FieldType} {field.Name} {field.GetValue(d)}");
            //    field.SetValue(d, 10);
            //    Console.WriteLine($"{field.FieldType} {field.Name} {field.GetValue(d)}");
            //}

            //// 프로퍼티 리플렉션
            //PropertyInfo[] propertyInfos = classType.GetProperties(BindingFlags.Public |
            //        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            //foreach (PropertyInfo propertyInfo in propertyInfos)
            //{
            //    Console.WriteLine($"{propertyInfo.Name} {propertyInfo.GetValue(d)}");

            //}
            #endregion

            Engine.Instance.Init();
            Engine.Instance.Load("level02.map");
            Engine.Instance.Run();
            Engine.Instance.Quit();

            #region MyRegion
            //Engine engine = Engine.Instance;

            //engine.Load("level02.map");

            //engine.Run();

            //engine.Stop();

            //string tempscene = "";
            //byte[] buffer = new byte[1024];
            //FileStream fs = new FileStream("level01.map", FileMode.Open);
            //fs.Seek(0, SeekOrigin.End);
            //long fileSize = fs.Position;
            //fs.Seek(0, SeekOrigin.Begin);
            //int readCount = fs.Read(buffer, 0, (int)fileSize);
            //tempscene = Encoding.UTF8.GetString(buffer);
            //string[] scene = tempscene.Split("\r\n");

            //while (fs.CanRead)
            //{
            //    int readCount = fs.Read(buffer, 0, (int)fileSize);
            //    scene = scene + Encoding.UTF8.GetString(buffer);
            //}
            //int readCount = fs.Read(buffer, 0, 80);
            //Console.WriteLine(readCount);
            //Console.Write(Encoding.UTF8.GetString(buffer));
            //if (fs.CanRead)
            //{
            //    readCount = fs.Read(buffer, 0, 80);
            //    Console.WriteLine(readCount);
            //    Console.Write(Encoding.UTF8.GetString(buffer));
            //}
            //fs.Close();
            //Console.WriteLine(scene);

            #endregion

            #region
            //1 -> 10 ; 올림차순
            //10 -> 1 ; 내림차순
            //int[] numbers = { 1, 2, 5, 3, 6, 7, 8, 10, 9 };
            //for (int i = 0; i < numbers.Length; ++i)
            //{
            //    for (int j = 0 /*-> i + 1 = 성능은 별 차이 없지만 최적화임*/; j < numbers.Length; ++j)
            //    {
            //        if (numbers[i] < numbers[j])
            //        {
            //            int temp = numbers[i];
            //            numbers[i] = numbers[j];
            //            numbers[j] = temp;
            //        }
            //    }
            //}
            //for (int i = 0; i < numbers.Length; ++i)
            //{
            //    Console.Write(numbers[i] + ", ");
            //}
            #endregion
        }
    }
}