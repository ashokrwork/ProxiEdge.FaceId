namespace ProxiEdge.FaceId.Base
{
    public enum FaceIdEndPoint
    {
        westus,
        westus2,
        eastus,
        eastus2,
        westcentralus,
        southcentralus,
        westeurope,
        northeurope,
        southeastasia,
        eastasia,
        australiaeast,
        brazilsouth,
        canadacentral,
        centralindia,
        uksouth,
        japaneast,
        uscentral,
        francecentral,
        koreacentral,
        japanwest,
        northcentralus
    }

    
    internal enum FaceEndPoint
    {
        detect,
        findsimilars,
        verify,
        group,
        identify
    }

    internal enum FaceListEndPoint
    {
        facelists,
        largefacelists
    }

    
    internal enum GroupEndPoint
    {
        persongroups,
        largepersongroups
    }

    public enum FindSimilarMode
    {
        matchPerson,
        matchFace
    }

    internal static class WebClientContentType
    {
        public static string Binary = "application/octet-stream";
        public static string Json = "application/json";

    }
}
