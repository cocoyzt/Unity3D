using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    void Awake()
    {
        Debug.Log("onAwake");
    }
    void Start()
    {
        Debug.Log("onStart");
    }

    void Update()
    {
        Debug.Log("onUpdate");
    }
    void FixedUpdate()
    {
        Debug.Log("onFixedUpdate");
    }
    void LateUpdate()
    {
        Debug.Log("onLateUpdate");
    }
    void OnGUI()
    {
        Debug.Log("onGUI");
    }
    void Reset()
    {
        Debug.Log("onReset");
    }
    void OnDisable()
    {
        Debug.Log("onDisable");
    }
    void OnDestroy()
    {
        Debug.Log("onDestroy");
    }
}
