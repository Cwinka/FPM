using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
public class PlayerReader : MonoBehaviour
{
    private PlayerInput inp;

    private Vector2 directionFlat;
    public Vector3 Direction { get; private set; }
    public bool JumpPressed { get; private set; }

    public void Awake()
    {
        inp = GetComponent<PlayerInput>();
    }

    public Vector3 ReadDirection()
    {
        directionFlat = inp.actions["Move"].ReadValue<Vector2>();
        Direction = new Vector3(directionFlat.x, 0f, directionFlat.y).normalized;
        return Direction;
    }

    public bool ReadJump()
    {
        JumpPressed = inp.actions["Jump"].IsPressed();
        return JumpPressed;
    }

    public void ReadInputs()
    {
        ReadDirection();
        ReadJump();
    }
}
