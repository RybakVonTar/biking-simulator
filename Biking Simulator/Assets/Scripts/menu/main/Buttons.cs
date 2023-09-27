using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button yourButton;
    public string sceneName;
    public bool exit;
    public bool save;
    public bool newLevel;
    public bool restart;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (exit)
        {
            Application.Quit();
        }
        else if (save)
        {
            Debug.Log("SOBEK");
            BikeFrame bike = FindObjectOfType<BikeFrame>();
            DistanceCounter counter = FindObjectOfType<DistanceCounter>();
            bike.position = bike.transform.position;

            FileManager.WriteToFile("loadSaveData.json", new LoadSave(true));
            FileManager.WriteToFile("bikeSaveData.json", bike);
            FileManager.WriteToFile("levelSaveData.json", new LevelSave(SceneManager.GetActiveScene().name));
            FileManager.WriteToFile("scoreSaveData.json", counter);

            CoinCollectible[] coinsListNow = FindObjectsOfType<CoinCollectible>();
            List<bool> coinsSkullEmoji = new();
            for (int i = 0; i < coinsListNow.Length; i += 1) {
                coinsSkullEmoji.Add(coinsListNow[i].collected);
            }
            CoinListSave coinsList = new(coinsSkullEmoji);

            SpeedBoostCollectible[] speedBoostListNow = FindObjectsOfType<SpeedBoostCollectible>();
            List<bool> speedBoostSkullEmoji = new();
            for (int i = 0; i < speedBoostListNow.Length; i += 1) {
                speedBoostSkullEmoji.Add(speedBoostListNow[i].collected);
            }
            SpeedBoostListSave speedBoostList = new(speedBoostSkullEmoji);

            DoubleJumpCollectible[] doubleJumpListNow = FindObjectsOfType<DoubleJumpCollectible>();
            List<bool> doubleJumpSkullEmoji = new();
            for (int i = 0; i < doubleJumpListNow.Length; i += 1) {
                doubleJumpSkullEmoji.Add(doubleJumpListNow[i].collected);
            }
            DoubleJumpListSave doubleJumpList = new(doubleJumpSkullEmoji);

            Debug.Log(coinsList.coinList[0] + " SAVED");
            FileManager.WriteToFile("coinsSaveData.json", coinsList);
            FileManager.WriteToFile("speedBoostSaveData.json", speedBoostList);
            FileManager.WriteToFile("doubleJumpSaveData.json", doubleJumpList);

            SceneManager.LoadScene(sceneName: sceneName);
        } 
        else if (newLevel || restart)
        {
            FileManager.WriteToFile("loadSaveData.json", new LoadSave(false));
            SceneManager.LoadScene(sceneName: sceneName); 
        }
        else
        {
            SceneManager.LoadScene(sceneName: sceneName); 
        }
    }
}
