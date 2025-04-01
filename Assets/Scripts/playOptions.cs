using UnityEngine;
using UnityEngine.SceneManagement;

public class playOptions : MonoBehaviour
{
    public void Add()
    {
        PlayerPrefs.SetInt("SelectedOperation", 0);  
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(1);
    }

    public void Mul()
    {
        PlayerPrefs.SetInt("SelectedOperation", 2); 
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(1);
    }

    public void Sub()
    {
        PlayerPrefs.SetInt("SelectedOperation", 1); 
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(1);
    }
}
