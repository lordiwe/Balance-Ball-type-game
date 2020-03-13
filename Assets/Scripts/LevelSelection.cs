using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public SceneFader sceneFader;

    public Button[] levelButtons;

    public void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 0);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }

    }

    public void Select(string lvlName)
    {
        sceneFader.FadeTo(lvlName);
    }
}
