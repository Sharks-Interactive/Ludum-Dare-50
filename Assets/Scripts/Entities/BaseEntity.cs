using UnityEngine;
using Chrio.World;
using Chrio.World.Loading;
using DG.Tweening;

namespace Chrio.Entities
{
    /// <summary>
    /// Purpose: Base class for all entities
    /// </summary>
    public class BaseEntity : SharksBehaviour, IBaseEntity
    {
        public EntityData EntityData;
        protected string EntityType { get => "BaseEntity"; }

        protected SpriteRenderer spriteRenderer;

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            base.OnLoad(_gameState, _callback);
        }

        public virtual void OnSelected() 
        {
            spriteRenderer.DOColor(Color.cyan, 0.2f); // Change color on selection!!!
        }

        public virtual void WhileSelected() { }

        public virtual void OnDeselected() 
        {
            spriteRenderer.DOColor(Color.white, 0.2f); // Change color on selection!!!
        }

        public virtual BaseEntity GetEntity() => this;
        public virtual EntityData GetData() => EntityData;
        public virtual GameObject GetGameObject() => gameObject;
        public virtual string GetEntityType() => EntityType;
        public virtual bool CompareEntityType(string EntType) => EntityType == EntType;
    }
}
