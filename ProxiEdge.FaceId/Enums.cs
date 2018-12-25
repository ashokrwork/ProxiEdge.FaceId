using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId
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

    internal enum FaceIdOperation
    {
        detect,
        findsimilars,
        verify
    }

    public enum FindSimilarMode
    {
        matchPerson,
        matchFace
    }

    public static class WebClientContentType
    {
        public static string Binary = "application/octet-stream";
        public static string Json = "application/json";

    }
}
