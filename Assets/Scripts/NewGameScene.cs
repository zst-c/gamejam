public class NewGameScene : MemoryScene
{
    protected override string[] Labels
    {
        get
        {
            var labels = new[] { "usnm [0]", "usnm [1]", "btn_Cc", "btn_Ok" };
            return labels;
        }
    }
}