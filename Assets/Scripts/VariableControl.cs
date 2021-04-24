using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableControl : MonoBehaviour
{
    public static VariableControl instance;

    public float time = 0;
    public float score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
    }
}
