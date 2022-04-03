using Chrio.World;
using Chrio.World.Loading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Chrio.UI
{
    public class ResourceText : SharksBehaviour
    {
        private TextMeshProUGUI _resourceText;
        private ResourceManager.Resources _lastResources;

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            _resourceText = GetComponent<TextMeshProUGUI>();
            StartCoroutine(CalculateResourceChanges());
        }

        IEnumerator CalculateResourceChanges ()
        {
            yield return new WaitForSeconds(1);

            ResourceManager.Resources _resourceDifference = GlobalState.Game.ResourceManager.GlobalResources - _lastResources;
            _lastResources = GlobalState.Game.ResourceManager.GlobalResources;
            _resourceText.text = $"Power: {_lastResources.Power} ({_resourceDifference.Power})";

            StartCoroutine(CalculateResourceChanges());
        }
    }
}
