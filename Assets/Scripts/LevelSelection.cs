using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public SceneFader sceneFader;

    public void Select(string lvlName)
    {
        sceneFader.FadeTo(lvlName);
    }
}
