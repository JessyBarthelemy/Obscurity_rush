using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSizeManager : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> particles;

    [SerializeField]
    private bool isSmall;

    void Awake(){
        if(isSmall)
            Init(isSmall);
    }

    private void Init(bool isSmall){
        this.isSmall = isSmall;
        foreach(ParticleSystem ps in particles){
            if(isSmall){
                var main = ps.main;
                main.startLifetime = 0.37f;
            }
        }
    }
}
