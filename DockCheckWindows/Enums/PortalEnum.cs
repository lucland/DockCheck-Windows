public enum PortalEnum
{
    //PORTALID CAN BE "P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8"
    P1 = 1,
    P2 = 2,
    P3 = 3,
    P4 = 4,
    P5 = 5,
    P6 = 6,
    P7 = 7,
    P8 = 8,
}

public static class PortalEnumExtensions
{
    public static string ToFriendlyString(this PortalEnum portal)
    {
        switch (portal)
        {
            case PortalEnum.P1:
                return "P1";
            case PortalEnum.P2:
                return "P2";
            case PortalEnum.P3:
                return "P3";
            case PortalEnum.P4:
                return "P4";
            case PortalEnum.P5:
                return "P5";
            case PortalEnum.P6:
                return "P6";
            case PortalEnum.P7:
                return "P7";
            case PortalEnum.P8:
                return "P8";
            default:
                return "P0";
        }
    }
}

