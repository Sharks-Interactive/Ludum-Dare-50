using Chrio.Entities;
using Chrio.World;
using Chrio.World.Loading;
using UnityEngine;
using SharkUtils;

namespace Chrio.UI
{
    public class BuildManager : SharksBehaviour
    {
        private BuildablesDef _buildables;
        private BuildChoiceCreator _creator = new BuildChoiceCreator();

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            _buildables = Resources.Load<BuildablesDef>("GameData/BuildDef");
            _creator.Init(GlobalState);

            RefreshUI();
        }

        public void RefreshUI()
        {
            transform.DestroyAllChildren(true);

            BuildUI();
        }

        public void BuildUI()
        {
            foreach (RoomData room in _buildables.Buildables)
            {
                _creator.CreateNewBuildChoice(transform, room);
            }
        }
    }

    public class BuildChoiceCreator
    {
        private GameObject _buildChoice;
        private Game_State.State GlobalState;

        public void Init(Game_State.State State)
        {
            GlobalState = State;

            _buildChoice = Resources.Load<GameObject>("UI/BuildChoice");
        }

        public BuildChoice CreateNewBuildChoice(Transform Parent, RoomData Data)
        {
            BuildChoice _choice = Object.Instantiate(_buildChoice, Parent).GetComponent<BuildChoice>();
            _choice.Data = Data;

            foreach (ILoadableObject _lo in ExtraFunctions.GetAllInterfaces<ILoadableObject>(_choice.gameObject))
                _lo.OnLoad(GlobalState, () => { });

            return _choice;
        }
    }
}
