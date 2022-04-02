using Chrio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomPlacer : SharksBehaviour
{
    public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ghost.transform.position = GlobalState.Game.GridManager.GridPosition;
    }
}
