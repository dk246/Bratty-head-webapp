using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public GameObject[] planesTypes;
    public Paddle playerPaddle;
    public int playerScore { get; private set; }
    public Text playerScoreText;
    public Text playerScoreText2;
    public Paddle computerPaddle;
    public int computerScore { get; private set; }
    public Text computerScoreText;
    public Text computerScoreText2;
    public GameObject[] panels;

    public Text count;
    public GameObject txt;
    //public GameObject[] 

    public InputField inpt;
    public Text inpt_text;
   
    public GameObject cam;
    public Text UserName;
    public Text UserName2;
    public music music;
    public Camera camera;
    public string name = "tesing";
    public Button[] letterButtons;

    public Button clear_btn;

    public GameObject Arrows;

    public static bool orient = false;
    public AudioClip song1;
    public AudioClip song2;
    public GameObject cnv;
    public Canvas canvas;
    public AudioSource audioSource;


    public void rotate()
    {

    }
    private void Start()
    {

        if (Screen.height > 1100)
        {
            orient = true;
            print("rotate");
            cam.transform.Rotate(0, 0, 90);
            camera.orthographicSize = 10.2f;
            cnv.transform.Rotate(0, 0, -90);
            //ball.transform.Rotate(0, 0, 90);
            canvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.67f;
            planesTypes[0].SetActive(false);
            planesTypes[1].SetActive(true);
         
        }
        else
        {
            planesTypes[0].SetActive(true);
            planesTypes[1].SetActive(false);
            orient = false;
            ball.transform.Rotate(0, 0, 0);
            //print("rotate");
            cam.transform.Rotate(0, 0, 0);
            camera.orthographicSize = 5f;
            cnv.transform.Rotate(0, 0, 0);
            canvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0f;
        }
        print("size"+Screen.height);
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        Arrows.SetActive(false);
     
        music.MusicOn2();
        //NewGame();
        for (int x = 0; x < panels.Length; x++)
        {

            if (x == 0)
            {
                panels[x].SetActive(true);
                
            }
            else
            {
                panels[x].SetActive(false);
            }
        }

    }

    public void PlayGame()
    {

        for (int x = 0; x < panels.Length; x++)
        {

            if (x == 1)
            {
                panels[x].SetActive(true);

            }
            else
            {
                panels[x].SetActive(false);
            }
        }
    }

    public void InpOk()
    {
        if (inpt.text != "" || inpt.text != " ") {

            for (int x = 0; x < panels.Length; x++)
            {

                if (x == 2)
                {
                    panels[x].SetActive(true);
                }
                else
                {
                    panels[x].SetActive(false);
                }
            }

        }
        
        //print(inpt.text);
    }
    public void Clear() {
        name ="";
    }
    public void LetterButton(string letter) {

        name += letter; 

    }
    private void Update()
    {
      

        inpt_text.text = name;
     
        inpt.text = name;

        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }

        if (playerScore == 10)
        {
            music.MusicOff();
            music.MusicOn2();
            panels[3].SetActive(true);
            Arrows.SetActive(false);
            ball.ResetVelo();

        }
        else if (computerScore == 10)
        {
            music.MusicOff();
            music.MusicOn2();
            panels[4].SetActive(true);
            Arrows.SetActive(false);
            ball.ResetVelo();
        }
    }

    public void NewGame()
    {
        music.MusicOn();
        UserName.text = inpt.text;
        UserName2.text = inpt.text;
        Arrows.SetActive(true);

        for (int x = 0; x < panels.Length; x++)
        {

            panels[x].SetActive(false);

        }
        SetPlayerScore(0);
        SetComputerScore(0);
        StartCoroutine("Count");
        //StartRound();

    }

    public void StartRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void PlayerScores()
    {
        audioSource.clip = song1;
        audioSource.Play(0);
        SetPlayerScore(playerScore + 1);
        ball.ResetVelo();
        ball.AddStartingForce();

    }

    public void ComputerScores()
    {
        audioSource.clip = song2;
        audioSource.Play(0);
        SetComputerScore(computerScore + 1);
        ball.ResetVelo();
        ball.AddStartingForce();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
        playerScoreText2.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
        computerScoreText2.text = score.ToString();

    }


    IEnumerator Count()
    {

        ball.ResetVelo();
        ball.ResetPosition();
        txt.SetActive(true);
        count.text = "3";
        yield return new WaitForSeconds(1f);
        count.text = "2";
        yield return new WaitForSeconds(1f);
        count.text = "1";
        yield return new WaitForSeconds(1f);
        txt.SetActive(false);
        StartRound();
    }
}
