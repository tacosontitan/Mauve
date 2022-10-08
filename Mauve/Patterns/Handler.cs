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
        private Handler<T> _nextHandler;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="Handler{T}"/> instance with the specified request.
        /// </summary>
        /// <param name="request">The request to be handled.</param>
        public Handler(T request) => _request = request;
        /// <summary>
        /// Creates a new <see cref="Handler{T}"/> instance with the specified request and followup <see cref="Handler{T}"/>.
        /// </summary>
        /// <param name="request">The request to be handled.</param>
        /// <param name="nextHandler">The next <see cref="Handler{T}"/> in the chain of responsibility.</param>
        public Handler(T request, Handler<T> nextHandler) : this(request) => _nextHandler = nextHandler;

        #endregion

        #region Public Methods

        /// <summary>
        /// Handles the request or attempts to pass the request along to the next <see cref="Handler{T}"/> in the chain.
        /// </summary>
        public void Execute()
        {
            if (!TryHandleRequest(_request))
                if (_nextHandler != null)
                    _nextHandler.Execute();
        }
        /// <summary>
        /// Handles the request or attempts to pass the request along to the next <see cref="Handler{T}"/> in the chain.
        /// </summary>
        public async Task ExecuteAsync()
        {
            if (!TryHandleRequest(_request))
                if (_nextHandler != null)
                    await _nextHandler.ExecuteAsync();

            await Task.CompletedTask;
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Sets the next <see cref="Handler{T}"/> in the chain.
        /// </summary>
        /// <param name="handler">The next <see cref="Handler{T}"/> in the chain.</param>
        internal void SetNextHandler(Handler<T> handler) =>
            _nextHandler = handler;

        #endregion

        #region Protected Methods

        /// <summary>
        /// Attempts to handle the specified request.
        /// </summary>
        /// <param name="request">The request to be handled.</param>
        /// <returns><see langword="true"/> if the handling was a success, otherwise <see langword="false"/>.</returns>
        protected abstract bool TryHandleRequest(T request);

        #endregion

    }
}
