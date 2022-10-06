using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Source.Actors.Items;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace Assets.Source.Core
{
    internal class SaveObject
    {
        public string Name;
        public int Score;
        public int Health;
        public int Damage;
        public int Armor;
        public int PositionX;
        public int PositionY;
        public string DefaultSpriteId;
        public List<string> Inventory;
        public List<string> UsedSpriteCollection;
        public List<string> Actors = new List<string>();

        public void MakeSave()
        {
            Name = Player.Singleton.Name;
            Score = Player.Singleton.Score;
            Damage = Player.Singleton.Damage;
            Health = Player.Singleton.Health;
            Armor = Player.Singleton.Armor;
            PositionX = Player.Singleton.Position.x;
            PositionY = Player.Singleton.Position.y;
            DefaultSpriteId = Player.Singleton.DefaultSpriteId;
            UsedSpriteCollection = new List<string>(Player.Singleton.UsedSpriteCollection);
            Inventory = new List<string>(Player.Singleton.Inventory);

            HashSet<Actor> actors = ActorManager.Singleton.GetActors();

            foreach (var actor in actors)
            {
                if (actor is Enemy || actor is Item)
                {
                    Actors.Add($"{actor.MapIcon};{actor.Position.x};{actor.Position.y}");
                }
            }

            string json = JsonUtility.ToJson(this, true);

            File.WriteAllText(Application.dataPath + "/text/test.json", json);
        }

        public static void LoadGame()
        {
            if (File.Exists(Application.dataPath + "/text/test.json"))
            {
                string saveString = File.ReadAllText(Application.dataPath + "/text/test.json");
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                LoadActors(saveObject);
            }
            else
            {
                Debug.Log("error");
            }
        }

        private static void LoadActors(SaveObject save)
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

            // Spawn Enemies and Items
            for (int i = 0; i < save.Actors.Count; i++)
            {
                List<string> data = save.Actors[i].Split(';').ToList();
                MapLoader.SpawnActor(data[0].First(), (Int32.Parse(data[1]), Int32.Parse(data[2])));
            }

            // Spawn player
            Player.Singleton.Position = (save.PositionX, save.PositionY);
            CameraController.Singleton.Position = Player.Singleton.Position;
            Player.Singleton.Damage = save.Damage;
            Player.Singleton.Health = save.Health;
            Player.Singleton.Armor = save.Armor;
            Player.Singleton.Score = save.Score;
            Player.Singleton.Name = save.Name;
            Player.Singleton.Inventory = new List<string>(save.Inventory);
            Player.Singleton.UsedSpriteCollection = new List<string>(save.UsedSpriteCollection);
        }

    }
}

