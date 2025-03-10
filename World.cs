using PJT250217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class World
    {
        //public GameObject[] gameObjects = new GameObject[100];
        //int useGameObjectCount = 0;
        List<GameObject> gameObjects = new List<GameObject>();
        List<GameObject> renderObjList = new List<GameObject>();

        public List<GameObject> GetGameObjects
        {
            get
            {
                return gameObjects;
            }
        }

        public void Instanciate(GameObject gameObject)
        {
            //gameObjects[useGameObjectCount] = gameObject;
            //useGameObjectCount++;
            gameObjects.Add(gameObject);
        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                foreach (Component component in gameObjects[i].components)
                {
                    component.Update();
                }
            }
        }

        public void Render()
        {
            foreach (var renderObj in renderObjList)
            {
                SpriteRenderer spriteRender = renderObj.GetComponent<SpriteRenderer>();
                spriteRender.Render();
            }
        }

        public void Sort()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                SpriteRenderer spr = gameObjects[i].GetComponent<SpriteRenderer>();

                if (spr == null)
                {
                    continue;
                }

                renderObjList.Add(gameObjects[i]);
            }

            for (int i = 0; i < renderObjList.Count; i++)
            {
                for (int j = i + 1; j < renderObjList.Count; j++)
                {
                    SpriteRenderer spr1 = renderObjList[i].GetComponent<SpriteRenderer>();
                    SpriteRenderer spr2 = renderObjList[j].GetComponent<SpriteRenderer>();

                    if (spr1.orderLayer - spr2.orderLayer > 0)
                    {
                        GameObject temp = renderObjList[i];
                        renderObjList[i] = renderObjList[j];
                        renderObjList[j] = temp;
                    }
                }
            }
        }

    }
}