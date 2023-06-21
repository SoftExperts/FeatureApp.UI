namespace Models.Common
{
    public static class ApiUrls
    {
        private const string WebApiUrl = "https://localhost:7114/";

        //Product
        public static string GetAllProducts => "products/GetAllProducts";
        public static string GetFilteredProducts => "products/GetFilteredProducts";
        public static string AddProduct => "products/AddProduct";
        public static string UpdateProduct => "products/UpdateProduct";
        public static string GetById => "products/GetProductById/";
        public static string DeleteProduct => "products/DeleteProduct/";
    }
}
