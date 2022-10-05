using System.Collections.Generic;
using System.Linq;
using Assets.Source.Actors;
using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Characters.Enemy;
using Assets.Source.Actors.Items;
using Assets.Source.Core;
using Assets.Source.scripts;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character, IDamageablePlayer
    {
        public override char MapIcon => 'p';
        public override string DefaultSpriteId => "PackCastle01_0";
        public override string DefaultName => "Player";
        public int Score { get; set; } = 0;
        public override int Damage { get; set; } = 10;
        public override int Health { get; set; } = 100;

        public List<Item> Inventory = new List<Item>();

        public Item FloorItem = null;

        public string Name = "Röszkei Rambó";

        public static Player Singleton { get; private set; }

        private List<Crosshair> _crosshairs = new List<Crosshair>();

        private float _movementTimeThreshold = 0.35f;

        public Direction Facing = Direction.Right;

        private Dictionary<Direction, float> _movementCounters = new Dictionary<Direction, float>()
        {
            { Direction.Up, 0 },
            { Direction.Down, 0 },
            { Direction.Left, 0 },
            { Direction.Right, 0 }
        };

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            SetSprite(DefaultSpriteId);
            Singleton = this;

            CreateCrosshair(1);
        }

        protected override void OnUpdate(float deltaTime)
        {
            HealthBar_Script.CurrentHealth = (float)Health;

            HandleInput(deltaTime);
            HandleContinousKeyPress(deltaTime);
            ShowHud();
            UpdateCrosshairs();
        }

        private void CreateCrosshair(int offset)
        {
            Crosshair crosshair = ActorManager.Singleton.Spawn<Crosshair>(this.Position.x, this.Position.y);
            crosshair.Offset = offset;
            _crosshairs.Add(crosshair);
        }

        private void UpdateCrosshairs()
        {
            foreach (Crosshair crosshair in _crosshairs)
            {
                crosshair.Move(this);
            }
        }

        private void ShowHud()
        {
            HealthBar_Script.HealthBar.fillAmount = HealthBar_Script.CurrentHealth / HealthBar_Script.MaxHealth;

            UserInterface.Singleton.SetText($"Damage: {Damage}\nScore: {Score}", UserInterface.TextPosition.TopRight, "magenta");
            UserInterface.Singleton.SetText($"Health: {Health}\n", UserInterface.TextPosition.TopLeft, "red");

            UserInterface.Singleton.SetText($"{CreateInventoryString()}", UserInterface.TextPosition.BottomRight, "red");
            if (FloorItem != null)
            {
                UserInterface.Singleton.SetText($"Press 'E' to pick up {FloorItem.DefaultName}", UserInterface.TextPosition.BottomCenter, "white");
            }
            else
            {
                UserInterface.Singleton.SetText("", UserInterface.TextPosition.BottomCenter, "white");
            }
        }

        private void ContinualMovement(Direction direction, float deltatime)
        {
            switch (direction)
            {
                case Direction.Up:
                    _movementCounters[direction] += deltatime;
                    break;
                case Direction.Down:
                    _movementCounters[direction] += deltatime;
                    break;
                case Direction.Left:
                    _movementCounters[direction] += deltatime;
                    break;
                case Direction.Right:
                    _movementCounters[direction] += deltatime;
                    break;
            }

            var directionsToZero = _movementCounters.Where(element => element.Key != direction).Select(element => element.Key).ToList();

            // Reset all other direction counters to 0
            foreach (var dir in directionsToZero)
            {
                _movementCounters[dir] = 0;
            }

            if (_movementCounters[direction] >= _movementTimeThreshold)
            {
                TryMove(direction);
                _movementCounters[direction] = 0;
            }
        }
        private void HandleInput(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Move up
                TryMove(Direction.Up);
                Facing = Direction.Up;
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Move down
                TryMove(Direction.Down);
                Facing = Direction.Down;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Move left
                TryMove(Direction.Left);
                Facing = Direction.Left;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Move right
                TryMove(Direction.Right);
                Facing = Direction.Right;
            }

            if (Input.GetKeyDown(KeyCode.E) && FloorItem != null)
            {
                FloorItem.Pickup(this);
                FloorItem = null;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttackEnemiesUnderCrosshairs();
            }

            if (Input.GetKeyDown(KeyCode.F5))
            {
                SaveObject saveGame = new SaveObject();
            }

            if (Input.GetKeyDown(KeyCode.F9))
            {
                SaveObject.LoadGame();
            }
        }

        private void HandleContinousKeyPress(float deltaTime)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                ContinualMovement(Direction.Up, deltaTime);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                ContinualMovement(Direction.Down, deltaTime);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                ContinualMovement(Direction.Left, deltaTime);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                ContinualMovement(Direction.Right, deltaTime);
            }
        }

        private void AttackEnemiesUnderCrosshairs()
        {
            foreach (var crosshair in _crosshairs)
            {
                if (ActorManager.Singleton.GetActorAt(crosshair.Position) is Enemy enemy)
                {
                    enemy.ApplyDamage(this);
                }
            }
        }

        public override void TryMove(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);
            
            if (actorAtTargetPosition == null)
            {
                // No obstacle found, just move
                Position = targetPosition;
                CameraController.Singleton.Position = targetPosition;
                FloorItem = null;
            }
            else if (actorAtTargetPosition is Item item)
            {
                Position = targetPosition;
                CameraController.Singleton.Position = targetPosition;
                FloorItem = item;
            }
            else if (actorAtTargetPosition is Enemy enemy)
            {
                enemy.OnCollision(this);
            }
            else if (actorAtTargetPosition is Door door)
            {
                foreach (Item element in Inventory)
                {
                    if (element is Key key)
                    {
                        door.DoorOpen();
                    }
                }

            }
        }

        private string CreateInventoryString()
        {
            if (Inventory.Count == 0)
            {
                return "Inventory: \nNone";
            }
            else
            {
                string output = "Inventory: \n";
                Inventory.ForEach(item => output += $"{item.Name}\n");
                return output;
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Item item)
            {
                FloorItem = item;
            }
            else if (anotherActor is Enemy enemy)
            {
                ApplyDamage(enemy);
            }
            
            else
            {
                FloorItem = null;
            }
            return false;
        }

        public void OnDeath()
        {
            ActorManager.Singleton.DestroyActor(this);
            SceneManager.LoadScene("DeathScene");
        }

        public void ApplyDamage(Enemy enemy)
        {
            Health -= enemy.Damage;
            EventLog.AddEvent($"{enemy.DefaultName} hits {Name} for {enemy.Damage}");
            if (Health <= 0)
            {
                // Die
                OnDeath();
                UserInterface.Singleton.SetText($"Health: {Health}\nDamage: {Damage}\nScore: {Score}", UserInterface.TextPosition.TopRight, "magenta");
            }
        }
    }
}
