using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CommentList", menuName = "CreatCommentList")]
public class CommentScriptable : ScriptableObject
{
    public List<string> comments_correct;
    public List<string> comments_error;

}
