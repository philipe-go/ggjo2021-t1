using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class BossCoreController : MonoBehaviour
{
    [SerializeField] Material heartMaterial;
    bool changeColor = false;
    Health bossHP;
    
    void Start() {
        bossHP = gameObject.GetComponent<Health>();
    }

    void Update()
    {
        if (gameObject.GetComponent<Health>().health == 0)
        {
            GameObject.FindObjectOfType<SkullatronHandController>().isBossDead = true;
            Destroy(this.gameObject, 1f);
        }

        if (changeColor)
        {
            heartMaterial.color = Color.LerpUnclamped(heartMaterial.color, Color.red, 1*Time.deltaTime);
            if (heartMaterial.color == Color.red) changeColor = false;
        }
    }

    internal void Hit(int damage)
    {
#if UNITY_EDITOR
        Debug.Log("Core hit");
#endif
        if (bossHP) bossHP.ChangeHealth(damage);
        
        heartMaterial.color = Color.yellow;
        changeColor = true;
    }
}
