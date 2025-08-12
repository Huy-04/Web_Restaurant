namespace Domain.Core.Messages.ErrrorMessages
{
    public static class CommonError
    {
        // Description
        public const string DescriptionMaxLengthExceeded = "Description must not exceed 255 characters";

        public const string DescriptionNotBeEmpty = "Description must not be empty";

        // Img
        public const string ImgMaxLengthExceeded = "Img must not exceed 255 characters";

        public const string ImgNotBeEmpty = "Img must not be empty";

        // Prices
        public const string PricesMustNotBeEmpty = "Prices must not be empty";

        public const string PriceListUniqueCurrency = "Each currency must appear only once in price list";
    }
}