using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DownloadButton : MonoBehaviour
{
    public TMP_Text button;
    public float downloadingTime;
    public float currentTime;
    public bool isBlocked;
    public bool inactive;
    private int multiplier = 0;

    public GameObject icon;

    void Update() {
        if (currentTime == 0)
            button.text = "DESCARGAR";
        else if (currentTime < downloadingTime) {
            currentTime += Time.deltaTime * multiplier;

            int porcentaje = (int) Mathf.Floor((currentTime / downloadingTime) * 100);
            button.text = porcentaje +"%";
        }
        else if (inactive)
            button.text = isBlocked ? "Bloqueado" : "Completado";
        else {
            if (!isBlocked)
                icon.SetActive(true);
            inactive = true;
        }
    }

    public void DownloadingState() {
        if (!inactive) {
            multiplier = 1;
            currentTime = 1;
            //button.text = isDownloading ? "DESCARGANDO..." : "DESCARGAR";
        }
    }
}
