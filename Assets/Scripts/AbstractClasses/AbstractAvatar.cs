﻿using UnityEngine;

public class AbstractAvatar : MonoBehaviour
{
    public float currentHealth = 0;
    public float healthMax = 0;

    //[SerializeField] private Vector2 position = Vector2.zero;
    public Vector2 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    private void Die()
    {
        if(currentHealth <= 0)
        {
            Destroy(this);
        }
    }
}