using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public List<string> Actors = new List<string>();

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

            HashSet<Actor> actors = ActorManager.Singleton.GetActors();

            foreach (var actor in actors)
            {
                if (actor is Enemy || actor is Item)
                {
                    Actors.Add($"{actor.MapIcon};{actor.Position.x};{actor.Position.y}");
                }
            }

            //jsonMapData = MapLoader.jsonMapData,

            MakeSave();
        }

        public void MakeSave()
        {
            string json = JsonUtility.ToJson(this, true);

            File.WriteAllText(Application.dataPath + "/text/test.json", json);
        }

        public static void LoadGame()
        {
            if (File.Exists(Application.dataPath + "/text/test.json"))
            {
                string saveString = File.ReadAllText(Application.dataPath + "/text/test.json");
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                LoadActors(saveObject.Actors);
            }
            else
            {
                Debug.Log("error");
            }
        }

        private static void LoadActors(List<string> actors)
        {
            HashSet<Actor> originalActors = ActorManager.Singleton.GetActors();
            var collection = originalActors.ToArray();

            foreach (var actor in collection)
            {
                if (actor is Enemy || actor is Item)
                {
                    ActorManager.Singleton.DestroyActor(actor);
                }
            }

            for (int i = 0; i < actors.Count; i++)
            {
                
                List<string> data = actors[i].Split(';').ToList();
                MapLoader.SpawnActor(data[0].First(), (Int32.Parse(data[1]), Int32.Parse(data[2])));
            }
        }

    }
}

