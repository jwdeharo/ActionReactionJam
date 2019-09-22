using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {Idle, Playing, End, Ready};

public class GameController : MonoBehaviour
{
    public GameState gameState = GameState.Idle;
    // Start is called before the first frame update
//
}
