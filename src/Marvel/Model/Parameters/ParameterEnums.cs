namespace Marvel.Model
{
    public enum ParameterCharacterOrder
    {
        None, ByName, ByModified, ByNameDescending, ByModifiedDescending
    }

    public enum ParameterComicFormat
    {
        None,
        Comic,
        Magazine,
        TradePaperback,
        HardCover,
        Digest,
        GraphicNovel,
        DigitalComic,
        InfiniteComic
    }

    public enum ParameterComicFormatType
    {
        None, Comic, Collection
    }

    public enum ParameterComicDateDescriptor
    {
        None, LastWeek, ThisWeek, NextWeek, ThisMonth
    }

    public enum ParameterComicOrder
    {
        None,
        ByFocDate,
        ByOnSaleDate,
        ByTitle,
        ByIssueNumber,
        ByModified,
        ByFocDateDescending,
        ByOnSaleDateDescending,
        ByTitleDescending,
        ByIssueNumberDescending,
        ByModifiedDescending
    }

    public enum ParameterEventOrder
    {
        None,
        ByName,
        ByStartDate,
        ByModified,
        ByNameDescending,
        ByStartDateDescending,
        ByModifiedDescending
    }
}