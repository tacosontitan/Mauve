namespace Mauve.Net
{
    internal interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
