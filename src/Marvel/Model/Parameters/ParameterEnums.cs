﻿namespace Marvel.Model
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

    public enum ParameterSeriesType
    {
        None, Collection, OneShot, Limited, OnGoing
    }

    public enum ParameterSeriesOrder
    {
        None,
        ByTitle,
        ByModified,
        ByStartYear,
        ByTitleDescending,
        ByModifiedDescending,
        ByStartYearDescending
    }

    public enum ParameterStoryOrder
    {
        None, ById, ByModified, ByIdDescending, ByModifiedDescending
    }

    public enum ParameterCreatorOrder
    {
        None,
        ByLastName,
        ByFirstName,
        ByMiddleName,
        BySuffix,
        ByModified,
        ByLastNameDescending,
        ByFirstNameDescending,
        ByMiddleNameDescending,
        BySuffixDescending,
        ByModifiedDescending
    }
}