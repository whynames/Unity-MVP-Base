using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class IdlePlayerInput : MonoBehaviour, IIdlePlayerInput
{
    [SerializeField]
    DigitalRubyShared.FingersJoystickScript joyStickRef;


    public event Action<DigitalRubyShared.FingersJoystickScript, Vector2> OnJoystickChanged
    {
        add
        {
            joyStickRef.JoystickExecuted += value;
        }
        remove
        {
            joyStickRef.JoystickExecuted -= value;

        }
    }
    public event Action<DigitalRubyShared.FingersJoystickScript, Vector2> OnJoystickBegan
    {
        add
        {
            joyStickRef.JoystickBegan += value;
        }
        remove
        {
            joyStickRef.JoystickBegan -= value;

        }

    }
    public event Action<DigitalRubyShared.FingersJoystickScript, Vector2> OnJoystickEnded
    {
        add
        {
            joyStickRef.JoystickEnded += value;
        }
        remove
        {
            joyStickRef.JoystickEnded -= value;

        }
    }
}
public interface IPlayerInput
{



    Vector2 GetMovementVector();
    float GetHorizontalInput();
    float GetVerticalInput();
    bool IsJumpPressed();
    bool IsAttackPressed();
}

public interface IIdlePlayerInput
{
    event System.Action<DigitalRubyShared.FingersJoystickScript, Vector2> OnJoystickChanged;
    event System.Action<DigitalRubyShared.FingersJoystickScript, Vector2> OnJoystickBegan;
    event System.Action<DigitalRubyShared.FingersJoystickScript, Vector2> OnJoystickEnded;
}