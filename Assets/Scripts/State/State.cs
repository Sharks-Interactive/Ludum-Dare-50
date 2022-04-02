using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Chrio.Entities;
using Chrio.World.Loading;
using Chrio.Controls;
using Chrio.Effects;
using System;

namespace Chrio.World
{
    public static class Game_State
    {
        public class Controls
        {
            public bool Locked;
            public float Sensitivity;

            public Vector2 MousePosition { get
                {
                    return GlobalState.Game.MainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                } 
            }
            public ControlType CType;
#pragma warning disable IDE0044 // Add readonly modifier - but let's not for state swapping OnLoad
            private State GlobalState;
#pragma warning restore IDE0044 // Add readonly modifier

            public Controls(State GlobalState)
            {
                this.GlobalState = GlobalState;
                Locked = true;
                Sensitivity = 1.5f;

                CType = ControlType.Keyboard;
            }
        }

        public class Construction
        {
            public enum PlacingType
            {
                None,
                Power,
                Water,
                Defense,
                Bunks
            }

            public PlacingType Placing;
            public Dictionary<Guid, BaseRoom> Rooms = new Dictionary<Guid, BaseRoom>();

            /// <summary>
            /// Checks if a square is free (This is really slow)
            /// </summary>
            /// <param name="Position"> The position to check if it's square is occupied </param>
            /// <returns> Is the square free? </returns>
            public bool GetSquareIsFree(Vector3 Position)
            {
                foreach (BaseRoom room in Rooms.Values) if (room.transform.position == Position) return true;
                return false;
            }

            public (Guid, BaseRoom) AddRoom(State GlobalState, GameObject Room)
            {
                BaseRoom _room = Room.GetComponent<BaseRoom>();
                _room.OnLoad(GlobalState, () => { });

                Guid _id = Guid.NewGuid();
                Rooms.Add(_id, _room);

                return (_id, _room);
            }
        }

        public class Game
        {
            public bool Running;
            public Camera MainCamera;
            public CameraShake Shake;
            public Chrio.Player.Player Player;
            public GridManager GridManager;

            public Entities Entities;
            public Construction Construction;

            public Game()
            {
                Entities = new Entities();
                Construction = new Construction();

                Running = true;
                MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                Shake = MainCamera.transform.parent != null ? MainCamera.transform.parent.GetComponent<CameraShake>() : null;
            }
        }

        public class Entities
        {
            private readonly Dictionary<int, IBaseEntity> EntityIDs;
            public Dictionary<GameObject, IBaseEntity> WorldEntities;

            public Entities()
            {
                WorldEntities = new Dictionary<GameObject, IBaseEntity>();
                EntityIDs = new Dictionary<int, IBaseEntity>();

                GameObject[] _allEnts = GameObject.FindGameObjectsWithTag("Entity");

                // For getting currently existing entities at the time of the game starting
                for (int i = 0; i < _allEnts.Length; i++)
                {
                    WorldEntities.Add(_allEnts[i], _allEnts[i].GetComponent<IBaseEntity>());
                    EntityIDs.Add(_allEnts[i].GetInstanceID(), WorldEntities[_allEnts[i]]);
                }                
            }

            public IBaseEntity GetEntityByID (int ID) => EntityIDs.ContainsKey(ID) ? EntityIDs[ID] : null;
            
            /// <summary>
            /// Adds an entity to the global state
            /// </summary>
            /// <param name="ID"> ID Of the entity to add. </param>
            /// <param name="EntObject"> The gameobejct of the entity to add. </param>
            /// <param name="Ent"> A reference to the entities entity </param>
            public void AddEntity(GameObject EntObject, IBaseEntity Ent)
            {
                WorldEntities.Add(EntObject, Ent);
                EntityIDs.Add(EntObject.GetInstanceID(), Ent);
            }

            public static void InitEntity<T>(GameObject NewEntity, State GlobalState, EntityData Data) where T : BaseEntity
            {
                IBaseEntity Entity = NewEntity.GetComponent<IBaseEntity>();
                T EntBehaviour = Entity.GetEntity() as T;

                EntBehaviour.EntityData = Data;
                EntBehaviour.OnLoad(GlobalState, () => { }); // Init ent

                GlobalState.Game.Entities.AddEntity(NewEntity, Entity.GetEntity());
            }
        }

        public class State
        {
            public Controls Controls;
            public Game Game;
            public LevelLoader LevelLoader;

            public bool LowQuality = false;

            public State()
            {
                Controls = new Controls(this);
                Game = new Game();

                LowQuality = PlayerPrefs.GetInt("LQ", 0) != 0;
            }
        }
    }
}
