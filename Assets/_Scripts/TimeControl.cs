using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public GameObject[] People;
    public List <Animator> animList;
    [SerializeField, Range(-1f, 5f)] public float timeMultiplier = 1f;
    
    void Start()
    {
        animList = new List<Animator>();
        for (int i = 0; i < People.Length; i++)
        {
            animList.Add(People[i].GetComponent<Animator>());
        }
    }

    void Update()
    {
        foreach (Animator anim in animList)
        {
            anim.SetFloat("animSpeed", timeMultiplier);
        }
        
    }
}
