using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        FindObjectOfType<FixedJoystick>().gameObject.SetActive(false);
    }
}
