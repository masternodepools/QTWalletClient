namespace QTWalletClient.Models
{
    public class QTResponseModel<T>
    {
        public T Result { get; set; }
        public string Error { get; set; }
        public string Id { get; set; }
    }
}
