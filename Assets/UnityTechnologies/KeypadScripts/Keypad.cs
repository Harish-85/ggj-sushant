using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject hud;
    public GameObject inv;

    public GameObject animateOB;
    public Animator ANI;

    public Text textOB;
    public string answer = "4578";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public bool animate;

    private bool isKeypadActive = false;

    void Start()
    {
        keypadOB.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleKeypad();
        }

        if (textOB.text == "Right" && animate)
        {
            ANI.SetBool("animate", true);
            Debug.Log("its open");
        }

        if (isKeypadActive)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            player.GetComponent<ThirdPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void ToggleKeypad()
    {
        isKeypadActive = !isKeypadActive;

        if (isKeypadActive)
        {
            keypadOB.SetActive(true);
        }
        else
        {
            Exit();
        }
    }

    public void Number(int number)
    {
        textOB.text += number.ToString();
        button.Play();
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
            correct.Play();
            textOB.text = "Right";
        }
        else
        {
            wrong.Play();
            textOB.text = "Wrong";
        }
    }

    public void Clear()
    {
        textOB.text = "";
        button.Play();
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<ThirdPersonController>().enabled = true;
        isKeypadActive = false;
    }
}

