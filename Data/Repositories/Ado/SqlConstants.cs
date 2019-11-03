namespace Data.Repositories.Ado
{
    public class SqlConstants
    {
        public const string InsertIntoBookSql =
            @"INSERT INTO [dbo].[Books]
                ([Title]
                ,[ReleaseDate]
                ,[Isbn]
                ,[Publisher])
            VALUES
                (Id
                ,Title
                ,ReleaseDate
                ,Isbn
                ,Publisher)";
    }
}