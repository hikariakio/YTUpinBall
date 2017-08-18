using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Ylimit
{
    public float xmin, xmax, zmin, zmax;
}

[System.Serializable]
public class Tlimit
{
    public float xmin, xmax, zmin, zmax;
}

[System.Serializable]
public class Ulimit
{
    public float xmin, xmax, zmin, zmax;
}

public class BallManager : MonoBehaviour {

    public Ylimit ylimit;
    public Tlimit tlimit;
    public Ulimit ulimit;

    public Text higscoretext;
    public Text scoretext;
    private int score;
    private int highscore;

    bool gameover=false;

    public AudioClip deathclip;
    public GameObject deathParticle;

    AudioSource aud;
  
    public GameObject[] wordArray;

	void Start ()
    {
        aud = GetComponent<AudioSource>();
        scoretext.text = score.ToString();
        highscore = PlayerPrefs.GetInt("High Score");
        higscoretext.text = "H i g h s c o r e : " + highscore.ToString();        
    }


    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Y")
        {
            Destroy(other.gameObject);
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            ScoreUpdate();
            aud.Play();
            StartCoroutine(Ywait());
        }

        if (other.gameObject.tag == "T")
        {
            Destroy(other.gameObject);
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            ScoreUpdate();
            aud.Play();
            StartCoroutine(Twait());

        }

        if (other.gameObject.tag == "U")
        {
            Destroy(other.gameObject);
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            ScoreUpdate();
            aud.Play();
            StartCoroutine(Uwait());
        

        }


        else if ( other.gameObject.tag == "DeathArea")
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            gameover = true;
            animationplay.GameOverAnimation();
            aud.clip = deathclip;
            aud.Play();

            if ( score > highscore)
            {
                PlayerPrefs.SetInt("High Score", score);
                highscore = score;
                higscoretext.text = "H i g h s c o r e : " + highscore.ToString();
            }
        }
        
    }

    private void Update()
    {
        if (gameover && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator Ywait()
    {
        yield return new WaitForSeconds(4);
        Instantiate(wordArray[0], new Vector3(Random.Range(ylimit.xmin, ylimit.xmax), 0.25f, Random.Range(ylimit.zmin, ylimit.zmax)), Quaternion.identity);
    }
    IEnumerator Twait()
    {
        yield return new WaitForSeconds(4);
        Instantiate(wordArray[1], new Vector3(Random.Range(tlimit.xmin, tlimit.xmax), 0.25f, Random.Range(tlimit.zmin, tlimit.zmax)), Quaternion.identity);
    }
    IEnumerator Uwait()
    {
        yield return new WaitForSeconds(4);
        Instantiate(wordArray[2], new Vector3(Random.Range(ulimit.xmin, ulimit.xmax), 0.25f, Random.Range(ulimit.zmin, ulimit.zmax)), Quaternion.identity);
    }
    void ScoreUpdate()
    {
        score++;
        scoretext.text = score.ToString();
    }
}
