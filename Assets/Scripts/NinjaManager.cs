using System;
using UnityEngine;

public class NinjaManager : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to the Animator component
    
    private Transform _player; // Reference to the player's Transform
    private static readonly int Attacked = Animator.StringToHash("attacked");
    
    // Start is called before the first frame update
    void Start()
    {
        FindPlayerAndFace();
    }

    // Update is called once per frame
    void Update()
    {
        // Additional logic for the Ninja can be added here if needed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Spell")) return;

        animator.SetBool(Attacked, true);
    }

    /// <summary>
    /// Finds the player GameObject by tag and rotates the Ninja character to face the player.
    /// </summary>
    private void FindPlayerAndFace()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObject == null)
        {
            Debug.LogError("No GameObject with tag 'Player' found in the scene.");
            return;
        }

        _player = playerObject.transform;

        // Calculate the direction from the Ninja to the Player
        Vector3 directionToPlayer = _player.position - transform.position;
        directionToPlayer.y = 0; // Keep the rotation only on the Y-axis

        // Check if the direction is valid (not zero)
        if (directionToPlayer != Vector3.zero)
        {
            // Calculate the rotation to face the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = targetRotation;
        }
    }
}