public enum ActionEnum
{
    UsuarioCriado = 0,
    CheckIn = 1,
    CheckOut = 2,
    Avistado = 3,
    Bloqueado = 4,
    EntradaManual = 5,
    SaidaManual = 6,
    Perdido = 7,
}

public static class ActionEnumExtensions
{
    public static string ToFriendlyString(this ActionEnum action)
    {
        switch (action)
        {
            case ActionEnum.UsuarioCriado:
                return "Usuário criado";
            case ActionEnum.CheckIn:
                return "Check-In";
            case ActionEnum.CheckOut:
                return "Check-Out";
            case ActionEnum.Avistado:
                return "Avistado";
            case ActionEnum.Bloqueado:
                return "Bloqueado";
            case ActionEnum.EntradaManual:
                return "Entrada manual";
            case ActionEnum.SaidaManual:
                return "Saída manual";
            case ActionEnum.Perdido:
                return "Perdido";
            default:
                return "Unknown";
        }
    }
}

