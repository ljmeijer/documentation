/*
using UnityEngine;
using System.Collections;

public class AnotherOnMemberExpressionQuote : MonoBehaviour {
    void OnMouseEnter() {
        if (!animation.IsPlaying("mouseOverEffect"))
            animation.Play("mouseOverEffect");
        
    }
}
*/
/*
import UnityEngine
import System.Collections

class AnotherOnMemberExpressionQuote(MonoBehaviour):

	def OnMouseEnter():
		if not animation.IsPlaying('mouseOverEffect'):
			animation.Play('mouseOverEffect')

*/
function OnMouseEnter() {
    if (!animation.IsPlaying("mouseOverEffect"))
        animation.Play("mouseOverEffect");
}
