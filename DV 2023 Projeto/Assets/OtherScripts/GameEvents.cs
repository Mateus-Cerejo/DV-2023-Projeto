using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "GameEvents", menuName = "Custom/Game Events")]
public class GameEvents : ScriptableObject
{
    public delegate void WaveStateChanged(int waveState);
    public event WaveStateChanged OnWaveStateChanged;

    public delegate void EnemyDied(int enemyCount);
    public event EnemyDied OnEnemyDeath;

    public delegate void PlayerDied();
    public event PlayerDied OnPlayerDeath;

    public delegate void PlayerRevived();
    public event PlayerRevived OnPlayerRessurection;

    public void InvokeWaveStateChanged(int waveState)
    {
        OnWaveStateChanged?.Invoke(waveState);
    }

    public void InvokeEnemyDied(int enemyCount)
    {
        OnEnemyDeath?.Invoke(enemyCount);
    }

    public void InvokePlayerDied()
    {
        OnPlayerDeath?.Invoke();
    }

    public void InvokePlayerRevived()
    {
        OnPlayerRessurection?.Invoke();
    }
}
