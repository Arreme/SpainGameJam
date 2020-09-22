using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyContacts : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField]
    Transform wall;
    [SerializeField]
    Transform nextStep;
    [SerializeField]
    Transform playerContact;
    [SerializeField]
    Transform playerBehind;
    [SerializeField]
    float distance;
    [SerializeField]
    float behindDistance;
    [SerializeField]
    LayerMask whatIsGround;
    [SerializeField]
    LayerMask whatIsPlayer;

    [Header("Contacts")]
    public bool canNextStep;
    public bool wallContact;
    public bool playerContactHit;
    public bool playerBehindHit;
    private void Update()
    {
        RaycastHit2D nextHit = Physics2D.Raycast(nextStep.position, nextStep.right, distance, whatIsGround);
        canNextStep = nextHit;

        RaycastHit2D nextWall = Physics2D.Raycast(wall.position, wall.right, distance, whatIsGround);
        wallContact = nextWall;

        RaycastHit2D nextPlayer = Physics2D.Raycast(playerContact.position, playerContact.right, distance, whatIsPlayer);
        playerContactHit = nextPlayer;

        RaycastHit2D whatBehind = Physics2D.Raycast(playerBehind.position, playerBehind.right * -1, behindDistance);
        if (whatBehind)
        {
            if (whatBehind.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                playerBehindHit = true;
            }
        }
        else
        {
            playerBehindHit = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(nextStep.position, nextStep.right * distance);
        Gizmos.DrawRay(wall.position, wall.right * distance);
        Gizmos.DrawRay(playerContact.position, playerContact.right * distance);
        Gizmos.DrawRay(playerBehind.position, playerBehind.right * -1 * behindDistance);
    }
}