using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public CardFace face = CardFace.FacingUp;
    
    // State
    [Tooltip("Hide it later")]
    public bool isFlipping;
    
    // tuneable value
    public float flipSpeed = 150f;
    
    // Start is called before the first frame update
    void Start()
    {
        switch (face)
        {
            case CardFace.FacingUp:
                transform.rotation = Quaternion.Euler(0,0,0);
                break;
            case CardFace.FacingDown:
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
        }

        // Flip();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipping)
        {
            transform.Rotate(0, flipSpeed*Time.deltaTime, 0);
            if (face == CardFace.FacingUp && transform.rotation.eulerAngles.y >= 180)
            {
                isFlipping = false;
                face = CardFace.FacingDown;
                GameManager.instance.state = GameState.Judge;
            }
            else if (face == CardFace.FacingDown && transform.rotation.eulerAngles.y >= 0 && transform.rotation.eulerAngles.y <= 10)
            {
                isFlipping = false;
                face = CardFace.FacingUp;
                GameManager.instance.state = GameState.Judge;
            }
            
        }
    }

    public void Flip()
    {
        isFlipping = true;
    }

}

public enum CardFace
{
    FacingUp,
    FacingDown
}
