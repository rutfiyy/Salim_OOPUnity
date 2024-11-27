using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    GameObject player;
    [SerializeField] CombatManager combatManager;
    HealthComponent healthComponent;

    private Label healthLabel;
    private Label pointsLabel;
    private Label waveLabel;
    private Label enemiesLeftLabel;

    private void OnEnable()
    {
        player = GameObject.Find("Player");
        healthComponent = player.GetComponent<HealthComponent>();
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        healthLabel = root.Q<Label>("Health");
        pointsLabel = root.Q<Label>("Points");
        waveLabel = root.Q<Label>("Wave");
        enemiesLeftLabel = root.Q<Label>("EnemiesWave");
    }

    void Update()
    {
        UpdateHealth(healthComponent.GetHealth());
        UpdatePoints(combatManager.points);
        UpdateWave(combatManager.waveNumber - 1);
        UpdateEnemiesLeft(combatManager.totalEnemies);
    }

    public void UpdateHealth(int health)
    {
        healthLabel.text = $"Health: {health}";
    }

    public void UpdatePoints(int points)
    {
        pointsLabel.text = $"Points: {points}";
    }

    public void UpdateWave(int wave)
    {
        waveLabel.text = $"Wave: {wave}";
    }

    public void UpdateEnemiesLeft(int count)
    {
        enemiesLeftLabel.text = $"Enemies Left: {count}";
    }
}
