namespace minimalWebApiDotNet.config
{
    public static class ConnectionString
    {
        private static bool Prod = false;
        private static string connStringProd = "Server=sql11.freesqldatabase.com, 3306;User ID=sql11644925;Password=YrDp1EFMSt;Database=sql11644925;";
        private static string connStringDev = "Server=localhost;User ID=movieComparatorImdbBDD;Password=movieComparatorImdbBDD;Database=movieComparatorImdbBDD;Trusted_Connection=true;TrustServerCertificate=true;";
        public static string GetString()
        {
            if (Prod)
            {
                return connStringProd;
            }
            else
            {
                return connStringDev;
            }

        }
    }
}
