using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Assets.Source.Actors.Items;
using System.Threading;
using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Characters.Enemy;
using Assets.Source.Core;
using Assets.Source.scripts;
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
            Debug.Log(JsonUtility.ToJson(Inventory[0]));
            Debug.Log(JsonUtility.ToJson(Player.Singleton.Inventory[0]));
            //jsonMapData = MapLoader.jsonMapData,

            Debug.Log(this.Name);
            MakeSave();
        }

        public void MakeSave()
        {
            string json = JsonUtility.ToJson(this);

            Debug.Log(json);
            File.WriteAllText(Application.dataPath + "/text/test.json", json);
        }


    }
}

