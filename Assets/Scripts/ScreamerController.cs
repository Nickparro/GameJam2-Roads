using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerController : MonoBehaviour
{
    public Animator screamerAnimator;
    public bool isRunning;
    public float animationTime;
    // Start is called before the first frame update
    void Start()
    {
        screamerAnimator.GetComponent<Animator>();
        if(isRunning)
        {
            screamerAnimator.SetBool("isRunning",true);
        }
        Destroy(gameObject, animationTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
