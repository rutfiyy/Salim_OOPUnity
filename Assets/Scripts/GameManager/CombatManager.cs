using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;

    bool waveInProgress = false;

    void Update()
    {
        //Menjalankan timer untuk interval wave
        if (!waveInProgress)
            timer += Time.deltaTime;
        
        //Menjalankan wave selanjutnya dan mereset timer
        if (!waveInProgress && timer >= waveInterval)
        {
            StartNextWave();
            timer = 0; 
        }
    }

    void StartNextWave()
    {
        waveNumber++;
        totalEnemies = 0;
        waveInProgress = true;

        //Mengaktifkan seluruh spawner
        foreach (var spawner in enemySpawners)
        {
            spawner.ResetSpawner();
            spawner.isSpawning = true;
        }
    }

    public void CheckWaveCompletion()
    {
        //Memeriksa apakah wave telah berakhir
        foreach (var spawner in enemySpawners)
        {
            if (spawner.totalKillWave > 0)
                return;
        }

        waveInProgress = false;
    }
}
