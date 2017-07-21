using UnityEngine;
using UnityEngine.UI;

public class ScoreLabelController : MonoBehaviour
{
    Text _label;

    void Awake() {
        _label = GetComponent<Text>();
    }
    
    void Start() {
        var contextGame = Contexts.sharedInstance.game;
        var contextGameState = Contexts.sharedInstance.gameState;

        contextGame.GetGroup(GameMatcher.Destroyed).OnEntityAdded +=
            (group, entity, index, component) => updateScore(contextGameState.score.value);

        updateScore(contextGameState.score.value);
    }

    void updateScore(int score) {
        _label.text = "SCORE\n" + score;
    }
}