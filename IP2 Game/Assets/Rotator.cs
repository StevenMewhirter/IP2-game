﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotator : MonoBehaviour {
    
    public float rotationAngle = 90f;
    public float rotationStart = 0f;

    public void CubePieceRotation()
    {
        StartCoroutine(NiceRotation(rotationStart, rotationAngle, 1.0f));
    }
  
    IEnumerator  NiceRotation(float start, float end, float maxTime)
    {
        float t = 0;
        while (t < maxTime)
        {
            t += Time.deltaTime*2;
            print("called");
            Quaternion rot = GetComponent<Transform>().rotation;
            
            rot.x = Mathf.Lerp(start, end, t*t*t);

            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(rot.x, rot.y, rot.z));

            if(t >= maxTime)
            {
                rot.x = end;
            }
            NewRotValues();
            yield return null;
        }
    }

    public void NewRotValues()
    {
        rotationStart = rotationAngle;
        rotationAngle += 90f;
    }
}
