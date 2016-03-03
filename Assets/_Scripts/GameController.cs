using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    //Private instance variables
    private int _scoreValue;
    private int _livesValue;

	// PUBLIC INSTANCE VARIABLES
	public int tankCount;
	public GameObject tank;

    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }
        set
        {
            this._scoreValue = value;
            this.Scorelabel.text = "Score:" + this._scoreValue;

        }
    }
    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }
        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Lives:" + this._livesValue;
            }

        }
    }
	
	// Use this for initialization
	void Start () {
		this._GenerateTanks ();
        this._initialize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}
     //Public instance variables
    
    public EnemyController  enemies;
    public PlayerController players;
    
    public Text LivesLabel;
    public Text Scorelabel;
    public Text GameOverLabel;
    public Text HighscoreLabel;
    public Button RestartButton;
    
    //Private Methods###########
    private void _initialize(){
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.GameOverLabel.enabled = false;
        this.HighscoreLabel.enabled = false;
        this.RestartButton.gameObject.SetActive(false);

       
      
    }
    
    //set highscores,restart button on and, lives and scores off on game over
    private void _endGame()
    {
        this.HighscoreLabel.text = "High Score:" + this._scoreValue;
        this.GameOverLabel.enabled = true;
        this.LivesLabel.enabled = false;
        this.Scorelabel.enabled = false;
        this.HighscoreLabel.enabled = true;
        this.players.gameObject.SetActive(false);
        //this._gameOverSound.Play();
        //this.RestartButton.enabled = true;
        this.RestartButton.gameObject.SetActive(true);

    }

    public void RestartButtonClick()
    {
        Application.LoadLevel("Main");
    }
}

