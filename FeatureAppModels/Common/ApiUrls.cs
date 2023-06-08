namespace Models.Common
{
    public static class ApiUrls
    {
        private const string WebApiUrl = "https://localhost:7114/";

        //Product
        public static string GetAllProducts => "products/GetAllProducts";
        public static string AddProduct => "products/AddProduct";
    }
}
