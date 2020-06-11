namespace GameLogic
{
    public enum ActionType
    {
        Bet,
        Call,
        Raise,
        Fold,
        Check
    }
    public struct Action
    {
        public int Money { get; private set; }
        public ActionType ActionType { get; private set; }

        public Action(int money, ActionType actionType)
        {
            Money = money;
            ActionType = actionType;
        }
    }
}