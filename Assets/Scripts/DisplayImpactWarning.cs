using UnityEngine;

public class DisplayImpactWarning : MonoBehaviour
{
    public GameObject shipBase;

    public GameObject warningMessage;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject [] activeAlienBullets = GameObject.FindGameObjectsWithTag("AlienBullet");

        bool displayImpactMessage = false;
        foreach (GameObject alienBullet in activeAlienBullets)
        {
            float x = alienBullet.transform.position.x;
            float shipLeftBorder = shipBase.transform.position.x - shipBase.transform.lossyScale.x / 2;
            float shipRightBorder = shipBase.transform.position.x + shipBase.transform.lossyScale.x / 2;

            Vector3 impactPos = new Vector3(x, shipBase.transform.position.y, alienBullet.transform.position.z);

            //Debug.Log(alienBullet.transform.position);
            
            if (x >= shipLeftBorder && x <= shipRightBorder)
            {
                displayImpactMessage = true;
                break;       
            }
        }

        warningMessage.SetActive(displayImpactMessage);
        audioSource.enabled = displayImpactMessage;
    }
}
