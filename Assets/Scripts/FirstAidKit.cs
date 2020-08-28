using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstAidKit : MonoBehaviour
{
    public int startStoredHealth = 75;
    public float currentStoredHealth;
    public float regenerationSpeed = 0.5f;

    PlayerHealth playerHealth;
    GameObject player;

    public GameObject textObj;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        currentStoredHealth = startStoredHealth;

        text = textObj.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ((int)currentStoredHealth).ToString() + " HP";

        if (currentStoredHealth <= 75)
        {
            currentStoredHealth += regenerationSpeed * Time.deltaTime;
            text.text = ((int)currentStoredHealth).ToString() + " HP";
        }
        if (currentStoredHealth > startStoredHealth)
        {
            currentStoredHealth = startStoredHealth;
        }
        if (currentStoredHealth < 0)
        {
            currentStoredHealth = 0;
        }
    }

    public void TakeHealth()
    {      
        if (playerHealth.currentHealth < 100)
        {
            playerHealth.AddHealth(currentStoredHealth);
            currentStoredHealth -= currentStoredHealth;
            text.text = ((int)currentStoredHealth).ToString() + " HP";
        }     
    }
}
