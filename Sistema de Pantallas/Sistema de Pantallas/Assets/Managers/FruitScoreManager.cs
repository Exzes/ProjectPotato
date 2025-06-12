using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FruitScoreManager : MonoBehaviour
{
    public static FruitScoreManager Instance;

    public int currentFruitScore { get; private set; } = 0;

    [SerializeField] private TextMeshProUGUI fruitText;

    private bool active = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        active = PlayManager.Instance.canPlayerMove;
        UpdateFruitUI();
    }

    public void AddFruitAmount(int amount)
    {
        currentFruitScore += amount;
        active = true;
        UpdateFruitUI();
    }

    public int GetFruitScore()
    {
        int fruit = currentFruitScore;
        return fruit;
    }

    public void ResetFruitScore()
    {
        currentFruitScore = 0;
        UpdateFruitUI();
    }

    private void UpdateFruitUI()
    {
        if (fruitText != null && active)
        {
            fruitText.text = "Frutas: " + currentFruitScore.ToString();
        }
    }
}