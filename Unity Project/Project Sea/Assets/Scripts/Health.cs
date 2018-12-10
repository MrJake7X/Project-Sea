using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public Slider slide;

    public float health;

    private float iniHealth;

	void Start ()
    {
        iniHealth = health;
	}
	
	void Update ()
    {
        slide.value = health;
	}

    public void Damage(float hit)
    {
        health -= hit;
    }
}
