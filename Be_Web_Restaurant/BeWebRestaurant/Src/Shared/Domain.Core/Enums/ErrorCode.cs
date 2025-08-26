namespace Domain.Core.Enums
{
    public enum ErrorCode
    {
        IdNotFound,

        InvalidStatus,

        NameEmpty,
        NameTooLong,
        NameAlreadyExists,

        // Number
        NotNegative,

        // Duplicate Property
        DuplicateEntry,

        //Collection
        CollectionEmpty,

        TypeMismatch
    }
}