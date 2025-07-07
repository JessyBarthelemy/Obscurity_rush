using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterReader
{
    private static ParameterReader instance;

    public static ParameterReader Instance{
        get{
            if(instance == null)
                instance = new ParameterReader();

            return instance;
        }

        private set{
            instance = value;
        }
    }

    private bool isSoundActivated;
    public bool IsSoundActivated{
         get{
            return isSoundActivated;
        }

        set{
            PlayerPrefs.SetInt("IsSoundActivated", value ? 1 : 0);
            isSoundActivated = value;
        }
    }

    private ParameterReader(){
        IsSoundActivated = PlayerPrefs.GetInt("IsSoundActivated", 1) == 1 ? true : false;
    }
}