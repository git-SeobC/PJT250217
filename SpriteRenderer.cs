using L20250217;
using SDL2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217
{
    public class SpriteRenderer : Component
    {
        public char Shape; // Mesh, Sprite
        public SDL.SDL_Color color;
        public int spriteSize = 30;
        public int orderLayer;

        protected bool isAnimation = false;
        protected IntPtr myTexture;
        protected IntPtr mySurface;

        protected int spriteIndexX = 0;
        protected int spriteIndexY = 0;
        public SDL.SDL_Color colorKey;

        protected string filename;

        private float elapsedTime = 0;

        private SDL.SDL_Rect sourceRect; // source image
        private SDL.SDL_Rect destinationRect; // screen size

        public float processTime = 100.0f;
        public int maxCellCountX = 5;
        public int maxCellCountY = 5;

        public SpriteRenderer()
        {

        }

        public override void Update()
        {
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;
            // Screen bitmap
            destinationRect.x = X * spriteSize;
            destinationRect.y = Y * spriteSize;
            destinationRect.w = spriteSize;
            destinationRect.h = spriteSize;

            unsafe
            {
                // 이미지 정보 가져와서 할일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);

                if (isAnimation)
                {
                    if (elapsedTime >= processTime)
                    {
                        spriteIndexX++;
                        spriteIndexX = spriteIndexX % maxCellCountX;
                        elapsedTime = 0;
                    }
                    else
                    {
                        elapsedTime += Time.deltaTime;
                    }
                    int sizeX = surface->w / maxCellCountX;
                    int sizeY = surface->h / maxCellCountY;
                    sourceRect.x = sizeX * spriteIndexX;
                    sourceRect.y = sizeY * spriteIndexY;
                    sourceRect.w = sizeX;
                    sourceRect.h = sizeY;
                }
                else
                {
                    sourceRect.x = 0;
                    sourceRect.y = 0;
                    sourceRect.w = surface->w;
                    sourceRect.h = surface->h;
                }
            }
        }

        public virtual void Render()
        {
            //SDL.SDL_SetRenderDrawColor(Engine.Instance.myRenderer, color.r, color.g, color.b, color.a);
            //SDL.SDL_RenderDrawPoint(Engine.Instance.myRenderer, X, Y);
            //SDL.SDL_RenderFillRect(Engine.Instance.myRenderer, ref myRect);
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;

            // Console print
            Engine.backBuffer[Y, X] = Shape;

            unsafe
            {
                SDL.SDL_RenderCopy(Engine.Instance.myRenderer,
                    myTexture,
                    ref sourceRect,
                    ref destinationRect);
            }
        }

        public void LoadBmp(string inFilename, bool inIsAnimation = false)
        {
            string projectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            isAnimation = inIsAnimation;
            filename = inFilename;

            // SDL -> C로 되어있기 때문에 접근 할 수 있는게 없음
            mySurface = SDL.SDL_LoadBMP(projectFolder + "/data/" + inFilename);
            unsafe // 그래서 C Pointer를 쓰기위해 unsafe 사용
            {
                // 이미지 정보 가져와서 할일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);
                // 흰색은 그래픽 렌더링할 때 빼는 ColorKey 설정
                SDL.SDL_SetColorKey(mySurface, 1, SDL.SDL_MapRGB(surface->format, colorKey.r, colorKey.g, colorKey.b));
            }
            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myRenderer, mySurface);
        }
    }
}
