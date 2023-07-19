using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerHp : HP
{

    [SerializeField] private TextMeshProUGUI Hp;
    [SerializeField] GameObject Panel;
    public GameObject menuPanel;
    private bool isMenuActive;
    private bool isCursorVisible;
    public TextMeshProUGUI timerText;
    private float currentTime;
    private bool isTimerRunning;

    private void Start()
    {
        currentHP = MaxHP;
        Hp.text = currentHP.ToString();
        Panel.SetActive(false);
        timerText.text = "Time: 0";
        menuPanel.SetActive(false);
        isMenuActive = false;
        isCursorVisible = false;
    }
    public override void TakeDamage(float damage)
    {
        currentHP -= damage;
        Hp.text = currentHP.ToString();
        if (currentHP <= 0)
        {
            Dead();
        }

        
    }
     
    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = "Time: " + GetFormattedTime(currentTime);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            isMenuActive = !isMenuActive;
            menuPanel.SetActive(isMenuActive);

            isCursorVisible = isMenuActive;
            if (isCursorVisible)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f; 
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
        }
    }

    private string GetFormattedTime(float time)
    {
        // Форматирование времени в формат "минуты:секунды:миллисекунды"
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void Dead()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void DOMOI()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void Zanovo()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }


}
