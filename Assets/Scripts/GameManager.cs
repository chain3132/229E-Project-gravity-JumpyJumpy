using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Transform CurrentSpawnPoint;
    [SerializeField] private Transform[] SpawnPoints;
    [SerializeField] private bool isGetKey;
    [SerializeField] private TextMeshProUGUI keyText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        ResetSpawnPoint();
    }
    
    
    public void SetSpawnPoint(Transform spawnPoint)
    {
        CurrentSpawnPoint = spawnPoint;
    }
    public void ResetSpawnPoint()
    {
        CurrentSpawnPoint = SpawnPoints[0];
    }
    public Transform GetSpawnPoint()
    {
        return CurrentSpawnPoint;
    }

    public bool SetKey()
    {
        isGetKey = true;
        keyText.text = "X 1 ";
        return true;
    }
    public bool GetKey()
    {
        return isGetKey;
    }

}
