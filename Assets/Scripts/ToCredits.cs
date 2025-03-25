using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToCredits : MonoBehaviour
{
    public void Credits(){
        SceneManager.LoadSceneAsync(2);
    }
}
