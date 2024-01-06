using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRandomCamera : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate; // Les objets que tu veux activer/désactiver
    [SerializeField] private float minActivationTime = 2f;    // Temps d'activation minimum
    [SerializeField] private float maxActivationTime = 5f;    // Temps d'activation maximum

    void Start()
    {
        // Désactiver tous les objets au début
        DeactivateAllObjects();

        // Lancer la coroutine pour activer aléatoirement les objets
        StartCoroutine(ActivateRandomObjectsRoutine());
    }

    void DeactivateAllObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }
    }

    IEnumerator ActivateRandomObjectsRoutine()
    {
        while (true)
        {
            // Choisir un indice aléatoire
            int randomIndex = Random.Range(0, objectsToActivate.Length);

            // Activer l'objet choisi
            objectsToActivate[randomIndex].SetActive(true);

            // Attendre un temps aléatoire entre minActivationTime et maxActivationTime avant de désactiver à nouveau tous les objets
            yield return new WaitForSeconds(Random.Range(minActivationTime, maxActivationTime));

            // Désactiver tous les objets
            DeactivateAllObjects();
        }
    }
}
