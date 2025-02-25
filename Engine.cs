using PJT250217;
using System.Data;
using System.Text;

namespace L20250217
{
    public class Engine
    {
        private Engine() { }

        static Engine instance;

        static public char[,] backBuffer = new char[20, 40];
        static public char[,] frontBuffer = new char[20, 40];

        static public Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }
                return instance;
            }
        }

        protected bool isRunning = true;

        protected ConsoleKeyInfo keyInfo;

        public World world;

        public void Load(string pFileName)
        {
            //file에서 로딩
            //string[] scene = {
            //    "**********",
            //    "*P       *",
            //    "*        *",
            //    "*        *",
            //    "*        *",
            //    "*   M    *",
            //    "*        *",
            //    "*        *",
            //    "*       G*",
            //    "**********"
            //};
            #region 파일 byte 읽어오기 버전

            //string tempscene = "";
            //byte[] buffer = new byte[1024];
            //FileStream fs = new FileStream("level01.map", FileMode.Open);
            //fs.Seek(0, SeekOrigin.End);
            //long fileSize = fs.Position;
            //fs.Seek(0, SeekOrigin.Begin);
            //int readCount = fs.Read(buffer, 0, (int)fileSize);
            //tempscene = Encoding.UTF8.GetString(buffer);
            //tempscene = tempscene.Replace("\0", "");
            //string[] scene = tempscene.Split("\r\n");

            #endregion byte 단위는 \r\n 줄바꿈 등 표시도 다 읽어옴

            #region StreamReader 파일 읽기

            List<string> scene = new List<string>();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(pFileName);
                while (!sr.EndOfStream)
                {
                    scene.Add(sr.ReadLine());
                }
            }
            catch (FileNotFoundException e)
            {

            }
            finally
            {
                sr.Close();
            }

            #endregion

            world = new World();

            for (int y = 0; y < scene.Count; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    if (scene[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, scene[y][x]);
                        world.Instanciate(wall);
                    }
                    else if (scene[y][x] == ' ')
                    {
                        //Floor floor = new Floor(x, y, scene[y][x]);
                        //world.Instanciate(floor);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        Player player = new Player(x, y, scene[y][x]);
                        world.Instanciate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, scene[y][x]);
                        world.Instanciate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        Goal goal = new Goal(x, y, scene[y][x]);
                        world.Instanciate(goal);
                    }
                    Floor floor = new Floor(x, y, ' ');
                    world.Instanciate(floor);
                }
            }

            //sort
            world.Sort();

        }

        public void ProcessInput()
        {
            Input.Process();
        }

        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            // io 가 제일 느림, 특히 모니터 출력이 제일 느림
            // Console.Clear(); 화면 지우는 것 또한 작업이 느림
            world.Render();

            for (int Y = 0; Y < 20; ++Y)
            {
                for (int X = 0; X < 40; ++X)
                {
                    if (Engine.frontBuffer[Y, X] != Engine.backBuffer[Y, X])
                    {
                        Engine.frontBuffer[Y, X] = Engine.backBuffer[Y, X];
                        Console.SetCursorPosition(X, Y);
                        Console.Write(frontBuffer[Y, X]);
                    }
                }
            }
        }

        public void Run()
        {
            float frameTime = 1000.0f / 60.0f;
            double elapsedTime = 0.0;

            Console.CursorVisible = false;
            while (isRunning)
            {
                Time.Update();
                //if (elapsedTime >= frameTime)
                //{
                    ProcessInput();
                    Update();
                    Render();
                    Input.ClearInput();
                    //elapsedTime = 0;
                //}
                //else
                //{
                //    elapsedTime += Time.deltaTime;
                //}
            }
        }
    }
}