using PJT250217;
using SDL2;
using System.Data;
using System.Net.NetworkInformation;
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
        public IntPtr myWindow;
        public IntPtr myRenderer;
        public SDL.SDL_Event myEvent;

        public bool Init()
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("Fail Init.");
                return false;
            }

            myWindow = SDL.SDL_CreateWindow( // 메모리 포인터로 창 생성 위치 설정
                "Game",     // 창 title
                100, 100,   // 창 생성 위치
                640, 480,   // 창 크기
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

            return true;
        }

        public bool Quit()
        {
            SDL.SDL_DestroyRenderer(myRenderer);
            SDL.SDL_DestroyWindow(myWindow);

            SDL.SDL_Quit();
            return true;
        }

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
                        //Wall wall = new Wall(x, y, scene[y][x]);
                        //world.Instanciate(wall);

                        GameObject wall = new GameObject();
                        wall.Name = "Wall";
                        wall.transform.X = x;
                        wall.transform.Y = y;

                        wall.AddComponent<Wall>(new Wall());
                        SpriteRenderer spriteRenderer = wall.AddComponent<SpriteRenderer>(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.LoadBmp("wall.bmp");

                        world.Instanciate(wall);
                    }
                    else if (scene[y][x] == ' ')
                    {
                        //Floor floor = new Floor(x, y, scene[y][x]);
                        //world.Instanciate(floor);

                        GameObject floor = new GameObject();
                        floor.Name = "Floor";
                        floor.transform.X = x;
                        floor.transform.Y = y;

                        floor.AddComponent<Floor>(new Floor());
                        SpriteRenderer spriteRenderer = floor.AddComponent<SpriteRenderer>(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.LoadBmp("floor.bmp");

                        world.Instanciate(floor);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        GameObject player = new GameObject();
                        player.Name = "Player";
                        player.transform.X = x;
                        player.transform.Y = y;

                        player.AddComponent<PlayerContorller>(new PlayerContorller());
                        SpriteRenderer spriteRenderer = player.AddComponent<SpriteRenderer>(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 0;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.LoadBmp("player.bmp", true);
                        spriteRenderer.processTime = 150.0f;

                        world.Instanciate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        GameObject monster = new GameObject();
                        monster.Name = "Monster";
                        monster.transform.X = x;
                        monster.transform.Y = y;

                        monster.AddComponent<MonsterController>(new MonsterController());
                        SpriteRenderer spriteRenderer = monster.AddComponent<SpriteRenderer>(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.LoadBmp("monster.bmp");

                        world.Instanciate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        //Goal goal = new Goal(x, y, scene[y][x]);
                        //world.Instanciate(goal);
                        GameObject goal = new GameObject();
                        goal.Name = "Floor";
                        goal.transform.X = x;
                        goal.transform.Y = y;

                        goal.AddComponent<Goal>(new Goal());
                        SpriteRenderer spriteRenderer = goal.AddComponent<SpriteRenderer>(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.LoadBmp("goal.bmp");

                        world.Instanciate(goal);
                    }
                    //Floor floor = new Floor(x, y, ' ');
                    //world.Instanciate(floor);
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

            SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0);
            SDL.SDL_RenderClear(myRenderer);

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
            SDL.SDL_RenderPresent(myRenderer);
        }

        public void Run()
        {
            Console.CursorVisible = false;

            while (isRunning)
            {
                SDL.SDL_PollEvent(out myEvent);

                Time.Update();

                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false;
                        break;
                }

                Update();
                Render();
            }
        }
    }
}