using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Assets.Source.Actors.Items;
using System.Threading;
using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Characters.Enemy;
using Assets.Source.Core;
using Assets.Source.scripts;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Core
{
    internal class SaveObject
    {
        public string Name;
        public int Score;
        public int Health;
        public int Damage;
        public int PositionX;
        public int PositionY;
        public string DefaultSpriteId;
        public List<Item> Inventory;
        public List<ActorSaveObject> DynamicActors;
        //private string jsonMapData;

        public SaveObject()
        {
            Debug.Log("Save");

            Name = Player.Singleton.Name;
            Score = Player.Singleton.Score;
            Damage = Player.Singleton.Damage;
            Health = Player.Singleton.Health;
            PositionX = Player.Singleton.Position.x;
            PositionY = Player.Singleton.Position.y;
            DefaultSpriteId = Player.Singleton.DefaultSpriteId;
            Inventory = new List<Item>(Player.Singleton.Inventory);
            DynamicActors = new List<ActorSaveObject>();

            HashSet<Actor> actors = ActorManager.Singleton.GetActors();

            foreach (var actor in actors)
            {
                if (actor is Enemy || actor is Item)
                {
                    DynamicActors.Add(new ActorSaveObject(actor.MapIcon, actor.Position.x, actor.Position.y));
                }
            }

            //jsonMapData = MapLoader.jsonMapData,

            MakeSave();
        }

        public void MakeSave()
        {
            string json = JsonUtility.ToJson(this);
            /*
            ActorSaveObject[] actors = new ActorSaveObject[DynamicActors.Count];
            for (int i = 0; i < DynamicActors.Count; i++)
            {
                actors[i] = DynamicActors[i];
            }

            

            foreach (var item in Inventory)
            {
                json += JsonUtility.ToJson(item);
            }
            */
            File.WriteAllText(Application.dataPath + "/text/test.json", json);
        }

        public static void LoadGame()
        {
            if (File.Exists(Application.dataPath + "/text/test.json"))
            {
                string saveString = File.ReadAllText(Application.dataPath + "/text/test.json");
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            }
            else
            {
                Debug.Log("error");
            }
        }

    }
}

