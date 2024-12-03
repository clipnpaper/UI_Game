using UnityEngine;

public class Level1Hint : HintSystem
{
    public override string GetHint()
    {
        return "아이디와 패스워드를 모두 입력하셨나요?";
    }
}

public class Level2Hint : HintSystem
{
    public override string GetHint()
    {
        return "배경음을 확인해 볼까요?";
    }
}

public class Level3Hint : HintSystem
{
    public override string GetHint()
    {
        return "대학 로고를 확인해 볼까요?";
    }
}

public class Level4Hint : HintSystem
{
    public override string GetHint()
    {
        return "키보드 입력 규칙을 확인해 볼까요?";
    }
}
