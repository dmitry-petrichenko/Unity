using UnityEngine;
using UnityEngine.UI;

public class ScoreLabelController : MonoBehaviour
{
    Text _label;

    void Awake() {
        _label = GetComponent<Text>();
    }
    
    void Start() {
        var contextInput = Contexts.sharedInstance.input;
        var contextGameState = Contexts.sharedInstance.gameState;

        contextInput.GetGroup(InputMatcher.Input).OnEntityAdded +=
            (group, entity, index, component) => updateScore(contextGameState.score.value);

        updateScore(contextGameState.score.value);
    }

    void updateScore(int score) {
        _label.text = "Score " + score;
    }
}