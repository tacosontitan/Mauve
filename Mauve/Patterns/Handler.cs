using System.Threading.Tasks;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents a <see langword="class"/> implementing the <see href="https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern">chain of responsibility pattern</see>.
    /// </summary>
    public abstract class Handler<T> : IExecutable
    {

        #region Fields

        private readonly T _request;
        private readonly Handler<T> _nextHandler;

        #endregion

        #region Constructor

        public Handler(T request) => _request = request;
        public Handler(T request, Handler<T> nextHandler) : this(request) => _nextHandler = nextHandler;

        #endregion

        #region Public Methods

        public void Execute()
        {
            if (!TryHandleRequest(_request))
                if (_nextHandler != null)
                    _nextHandler.Execute();
        }
        public async Task ExecuteAsync()
        {
            if (!TryHandleRequest(_request))
                if (_nextHandler != null)
                    await _nextHandler.ExecuteAsync();

            await Task.CompletedTask;
        }

        #endregion

        #region Protected Methods

        protected abstract bool TryHandleRequest(T request);

        #endregion

    }
}
