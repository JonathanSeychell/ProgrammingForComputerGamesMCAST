using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();

        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        FindObjectOfType<GameStatus>().AddToScore();

        //play audioclip at camera's position
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        level.BlockDestroyed();


        Destroy(gameObject);
        TriggerSparklesVFX();
    }


    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, this.transform.position, this.transform.rotation);
        Destroy(sparkles, 1f);
    }
}
