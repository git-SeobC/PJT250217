using System.Text;

namespace L20250217
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = Engine.Instance;

            engine.Load("level01.map");

            engine.Run();

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