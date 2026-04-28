using System;
using UnityEngine;
using Zenject;

public class InputService : ITickable, IInputService
{
    private const int LeftMouseButton = 0;

    public event Action Clicked;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
            HandleClick();
    }

    private void HandleClick()
    {
        Clicked?.Invoke();
    }
}