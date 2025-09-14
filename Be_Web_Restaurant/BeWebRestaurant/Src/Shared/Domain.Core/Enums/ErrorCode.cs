namespace Domain.Core.Enums
{
    public enum ErrorCode
    {
        IdNotFound,

        // Relationship mismatch
        NoMatchingCombination,

        InvalidStatus,

        NameEmpty,
        NameTooLong,
        NameAlreadyExists,

        NotNegative,
        ExceedsMaximum,

        // Duplicate Property
        DuplicateEntry,

        //Collection
        CollectionEmpty,

        TypeMismatch,
    }
}