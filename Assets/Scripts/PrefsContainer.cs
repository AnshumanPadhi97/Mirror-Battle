using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsContainer : MonoBehaviour
{
    public static PrefsContainer instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
