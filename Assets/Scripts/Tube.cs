using System.Collections.Generic;
using UnityEngine;
public class Tube : MonoBehaviour{
    [SerializeField] private TubeView tubeView;
    [SerializeField] private TubeControl tubeConrtol;
    private Stack<BallView> ballStack;

    public TubeView TubeView { get => tubeView;}

    public Stack<BallView> getBallStack(){
        if(ballStack == null)
            ballStack = new Stack<BallView>();
        return ballStack;
    }
    
    public TubeControl TubeConrtol { get => tubeConrtol;}
}
