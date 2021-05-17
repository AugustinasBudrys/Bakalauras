using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to save varaibles between scene changes
public class VariableControl : MonoBehaviour
{
    public static VariableControl instance;

    public float time = 0;
    public float score = 0;
    // Awake function initiates an indestructible object which saves the time and score between levels
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
