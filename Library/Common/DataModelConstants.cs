﻿namespace Library.Common
{
    public static class DataModelConstants
    {
        //ranges for Book entity values
        public const int BookTitleMinLength = 10;
        public const int BookTitleMaxLength = 50;

        public const int BookAuthorMinLength = 5;
        public const int BookAuthorMaxLength = 50;

        public const int BookDescriptionMinLength = 5;
        public const int BookDescriptionMaxLength = 5000;

        public const double BookRatingMinValue = 0.00;
        public const double BookRatingMaxValue = 10.00;

        // ranges for Category entity values
        public const int CategoryNameMinLength = 5;
        public const int CategoryNameMaxLength = 50;

    }
}