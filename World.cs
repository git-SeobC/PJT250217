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
                gameObjects[i].Update();
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Render();
            }
        }

        public void Sort()
        {
            //gameObjects.Sort();
            // == 
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = i + 1; j < gameObjects.Count; j++)
                {
                    if (gameObjects[i].orderLayer - gameObjects[j].orderLayer > 0)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }
            }
        }

    }
}