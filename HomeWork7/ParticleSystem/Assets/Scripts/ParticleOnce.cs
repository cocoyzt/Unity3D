using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnce : MonoBehaviour {

    private ParticleSystem particleSys;  // 粒子系统  

    // Use this for initialization
    void Start () {
        particleSys = this.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        UI.OnclickAction += Boom;
    }

    private void OnDisable()
    {
        UI.OnclickAction -= Boom;
    }

    void Boom(Object sender, string info)
    {
        particleSys.Play();
    }
}
