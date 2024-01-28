using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPlayerScript : MonoBehaviour
{
    [SerializeField]
    GameObject ordenarPadre;
    [SerializeField] GameObject prefab = null;

    [SerializeField]
    TMP_InputField miInputField;

    [SerializeField]
    PlayersSO playersSO;

    [SerializeField]
    int scena = 2;

    // Start is called before the first frame update
    void Start()
    {
        playersSO.Limpiar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPlayer()
    {
        string playerName = miInputField.text;

        if (playersSO.InsertarElemento(playerName) && playerName != "")
        {
            GameObject obj = Instantiate(prefab, ordenarPadre.transform);
            TMP_Text textoTMP = obj.GetComponent<TextMeshProUGUI>();
            textoTMP.text = "- " + playerName;
            miInputField.text = "";
        }

    }
    public void Jugar()
    {
        if (playersSO.players.Count > 0)
        {
            Destroy(FindAnyObjectByType<AudioMenus>().gameObject);
            SceneManager.LoadScene(scena);
        }
    }
}
