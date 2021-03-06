using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] PlayerBehavior player;

    void Update()
    {
        if (GameLogic.gameLogic.gamePaused) return;
        player.MoveHorizontal(Input.GetAxis("Horizontal"));
        player.MoveVertical(Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
            player.Shot();
    }
}
