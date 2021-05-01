using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleChangeScene : MonoBehaviour
{

    public void changeScene(int x)
    {
        SceneManager.LoadScene(x);
    }

}
