namespace Domain.Core.Base
{
    public abstract class BaseUseCase
    {
        public int TranCode { get; private set; }
        public BaseUseCase(int trancode =0) 
        {
            this.TranCode = trancode;
        }
    }
}
