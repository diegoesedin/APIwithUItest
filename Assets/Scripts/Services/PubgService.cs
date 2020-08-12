using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Class for communication with PUBG Services
/// </summary>
public class PubgService
{
    /*** API PARAMS ***/
    private const string API_URL = "https://api.pubg.com/";
    private const string API_KEY = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI4OGQzZmVmMC1iZTY3LTAxMzgtYjQ1NC0wNDE0YWVmYjg0MjEiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNTk3MTk1MDU4LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6ImQtZXNlZGluLWdtYWlsIn0.d_3FU4-aFwUbBY3Dyop9rUINWexwvADBazFiwd4OD5k";
    
    /******************/

    /// <summary>
    /// GET method for all Tournament's list
    /// </summary>
    /// <param name="saveTournaments">Receive a method for serialization or local save</param>
    /// <returns></returns>
    public IEnumerator GetTournaments(Action<Tournaments> saveTournaments)
    {
        string endpointPath = API_URL + "tournaments";

        Debug.Log("Requesting tournaments...");
        UnityWebRequest request = UnityWebRequest.Get(endpointPath);
        request.SetRequestHeader("Authorization", API_KEY);
        request.SetRequestHeader("Accept", "application/vnd.api+json");
        UnityWebRequestAsyncOperation operation = request.SendWebRequest();

        yield return operation;

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Failed to connect. " + request.error);
        }
        else
        {
            Debug.Log("Tournaments received. Loading data...");
            try
            {
                Debug.Log("Reading JSON: " + request.downloadHandler.text);
                Tournaments tournaments = ScriptableObject.CreateInstance<Tournaments>();
                JsonUtility.FromJsonOverwrite(request.downloadHandler.text, tournaments);
                saveTournaments(tournaments);
            }
            catch (Exception e)
            {
                Debug.Log("Deserialization failed. " + e.Message);
            }
        }
    }
}
