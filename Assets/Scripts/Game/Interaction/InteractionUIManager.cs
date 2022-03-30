using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace Chrio.UI
{
    public class InteractionUIManager : SharksBehaviour
    {
        #region SINGLETON PATTERN
        public static InteractionUIManager _instance;
        public static InteractionUIManager instance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<InteractionUIManager>();

                    if (_instance == null)
                    {
                        GameObject container = new GameObject("UI Interaction Loading Failure!");
                        _instance = container.AddComponent<InteractionUIManager>();
                    }
                }

                return _instance;
            }
        }
        #endregion

        public TextMeshProUGUI InteractionText;
        public Animator Animator;

        public void SetInteractionText(string text)
        {
            Animator.SetBool("Visible", true);
            InteractionText.text = text;
        }
    }
}
