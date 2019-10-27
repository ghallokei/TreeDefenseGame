﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartingRoutine());
    }

    IEnumerator StartingRoutine()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
