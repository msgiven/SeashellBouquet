using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEventSO", menuName = "Scriptable Objects/GameEventSO")]
public class GameEventSO : ScriptableObject
{
    public UnityEvent OnRaise;
    public void Raise ()=> OnRaise?.Invoke();
}
