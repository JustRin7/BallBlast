using UnityEngine;
using UnityEngine.UI;

public class UILevelProgress : MonoBehaviour
{
    [SerializeField] private StoneSpawner stoneSpawner;//спавнер
    [SerializeField] private LevelProgress LevelProgress;//левел

    [SerializeField] private Image progressBar;
    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Text moneyText;

    //private float fillAmountStep;
    public static int currentMomey;


    private void Start()
    {
       currentLevelText.text = LevelProgress.currentLevel.ToString();
       nextLevelText.text = (LevelProgress.currentLevel + 1).ToString();

        currentMomey = 10;
        moneyText.text = currentMomey.ToString();

        progressBar.fillAmount = 0;
       // fillAmountStep = 1 / stoneSpawner.AmountSpawned;
    }

    private void Update()
    {
       currentLevelText.text = LevelProgress.currentLevel.ToString();
       nextLevelText.text = (LevelProgress.currentLevel + 1).ToString();
        moneyText.text = currentMomey.ToString();
       //progressBar.fillAmount = 1 / stoneSpawner.AmountSpawned;
       //moneyText.text = currentMomey.ToString();
    }
}
