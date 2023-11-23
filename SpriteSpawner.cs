using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject[] spritePrefabs; // Array to hold your sprite prefabs
    public Transform spawnPoint; // Point where sprites will be spawned
    public Button spawnButton; // Reference to the UI button
    public TextMeshProUGUI spawnCounterText; // Reference to a UI text element for displaying the spawn count

    private int spawnCount = 0; // Counter variable

    public GameObject text;

    void Start()
    {
        //text is true
        text.SetActive(true);

        // Initialize random number generator
        Random.InitState((int)System.DateTime.Now.Ticks);

        // Attach the method to the button's click event
        spawnButton.onClick.AddListener(SpawnRandomSprite);
    }

    void UpdateSpawnCounter()
    {
        // Update the UI text to display the spawn count
        spawnCounterText.text = spawnCount + " fish";
    }

    void SpawnRandomSprite()
    {
        // Increment the spawn count
        spawnCount++;

        // Update the UI text
        UpdateSpawnCounter();

        //get rid of text
        text.SetActive(false);

        // Randomly select a sprite prefab from the array
        int randomIndex = Random.Range(0, spritePrefabs.Length);
        GameObject randomSpritePrefab = spritePrefabs[randomIndex];

        // Instantiate the selected sprite prefab at the spawn point
        GameObject newSprite = Instantiate(randomSpritePrefab, spawnPoint.position, Quaternion.identity);

        // Add Rigidbody component for gravity
        Rigidbody rb = newSprite.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = newSprite.AddComponent<Rigidbody>();
        }

        // Enable gravity
        rb.useGravity = true;
    }
}