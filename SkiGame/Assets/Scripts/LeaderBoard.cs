using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<float> results = new List<float>();
    void Start()
    {
        results.Clear();
        for (int i = 0; i < 5; i++)
        {
            float toAdd= PlayerPrefs.GetFloat("time" + i, 99999);
            results.Add(toAdd);
        }
    }
    public void AddResults(float time)
    {
        results.Add(time);
        results.Sort();
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat("time" + i, results[i]);
        }
        PlayerPrefs.Save();
    }
  
}
