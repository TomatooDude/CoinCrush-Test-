using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Settings/InputReader")]
public class InputReaderSO : ScriptableObject, PlayerInputMap.IGameActions
{
    private PlayerInputMap _playerInputMap;
    public event Action<Vector2> MovementEvent;
    public event Action  ShootEvent;

    private void OnEnable()
    {
        if (_playerInputMap == null)
        {
            _playerInputMap = new PlayerInputMap();

            _playerInputMap.Game.SetCallbacks(this);

            _playerInputMap.Game.Enable();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShootEvent?.Invoke();
        }
    }
}
