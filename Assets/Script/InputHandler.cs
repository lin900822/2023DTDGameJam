using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Vector2 GetLeftStickAxis(int index)
    {
        if (index < 0 || index >= Gamepad.all.Count) return Vector2.zero;

        return Gamepad.all[index].leftStick.ReadValue();
    }
    
    public Vector2 GetRightStickAxis(int index)
    {
        if (index < 0 || index >= Gamepad.all.Count) return Vector2.zero;
        
        return Gamepad.all[index].rightStick.ReadValue();
    }

    public bool GetFired(int index)
    {
        if (index < 0 || index >= Gamepad.all.Count) return false;
        
        return Gamepad.all[index].rightTrigger.wasPressedThisFrame || Gamepad.all[index].rightShoulder.wasPressedThisFrame;
    }
    
    public bool GetFiring(int index)
    {
        if (index < 0 || index >= Gamepad.all.Count) return false;
        
        return Gamepad.all[index].rightTrigger.isPressed || Gamepad.all[index].rightShoulder.isPressed;
    }
    
    public bool GetSkilled(int index)
    {
        if (index < 0 || index >= Gamepad.all.Count) return false;
        
        return Gamepad.all[index].leftTrigger.wasPressedThisFrame || Gamepad.all[index].leftShoulder.wasPressedThisFrame;
    }
    
    public bool GetSkilling(int index)
    {
        if (index < 0 || index >= Gamepad.all.Count) return false;
        
        return Gamepad.all[index].leftTrigger.isPressed || Gamepad.all[index].leftShoulder.isPressed;
    }
}
