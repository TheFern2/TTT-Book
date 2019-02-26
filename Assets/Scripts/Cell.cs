using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    // Variables
    private static int cellIndex;

    // References for textures
    public Sprite squareEmpty;
    public Sprite squareO;
    public Sprite squareX;

    // Testing variables: Delete later on!
    public int currentPlayer = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        cellIndex = int.Parse(this.transform.tag);
        Debug.Log("You have clicked tile " + cellIndex);

        // Change texture on mouse down
        ChangeTexture(currentPlayer);
    }

    // This function will change the texture based on the player
    void ChangeTexture(int player)
    {
        if (player == 1)
        {
            GetComponent<SpriteRenderer>().sprite = squareX;
        }

        if (player == 2)
        {
            GetComponent<SpriteRenderer>().sprite = squareO;
        }
    }
}
