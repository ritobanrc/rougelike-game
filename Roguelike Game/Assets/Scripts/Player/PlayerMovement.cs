using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A component on the Player GameObject that moves the player using a 2D Rigidbody and Keyboard Input
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// The current player position as a coordinate. 
    /// </summary>
    public Coord PlayerPosition { get; protected set; }

    /// <summary>
    /// A layer mask used to determine if the player can move into a new tile.
    /// </summary>
    public LayerMask PlayerCollisionMask;
    /// <summary>
    /// The player's max speed
    /// </summary>
    public float speed = 6f;
    /// <summary>
    /// The amount of time to wait after a movement has been completed.
    /// </summary>
    public float waitAfterMove = 0.05f;
    /// <summary>
    /// A reference to the Rigidbody
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// Is the player currently moving? (i.e., is the moving animation currently playing?) Used to determine if the player can start a new move. 
    /// </summary>
    private bool currentlyMoving;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerPosition = new Coord(0, 0);
    }

    private void FixedUpdate()
    {
        int h = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        int v = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        Coord movement = new Coord(h, v);

        if (currentlyMoving == false && (Mathf.Abs(h) + Mathf.Abs(v)) == 1 && CheckValidPosition(rb.position + movement.AsV2))
            StartCoroutine(Move(h, v));
    }

    /// <summary>
    /// A coroutine that moves a player with a animation
    /// </summary>
    /// <param name="h">The horizontal axis input</param>
    /// <param name="v">The vertical axis input</param>
    /// <returns>Next coroutine entry point</returns>
    private IEnumerator Move(int h, int v)
    {
        PlayerPosition += new Coord(h, v);
        currentlyMoving = true;
        Debug.Log("Started Move to Position: " + PlayerPosition.ToString());
        while ((PlayerPosition.AsV2 - rb.position).sqrMagnitude > 0.02)
        {
             rb.MovePosition(rb.position + new Vector2(h, v) * speed * Time.deltaTime);
             yield return null;
        }
        rb.MovePosition(PlayerPosition.AsV2);
        Debug.Log("Move Completed. PlayerPosition: " + PlayerPosition.ToString());
        yield return new WaitForSeconds(waitAfterMove);
        currentlyMoving = false;
    }

    /// <summary>
    /// Checks whether the player can move to a new position, or is blocked by something, like a wall. (Uses Physics)
    /// </summary>
    /// <param name="playerPosition"></param>
    /// <returns>Whether the player can move into a new tile</returns>
    private bool CheckValidPosition(Vector2 playerPosition)
    {
        // Do stuff here. 
        if (Physics2D.OverlapBox(playerPosition, new Vector2(0.8f, 0.8f), 0f, PlayerCollisionMask))
        {
            Debug.Log("OverlapBox returned true");
            return false;
        }
        return true;
    }
}