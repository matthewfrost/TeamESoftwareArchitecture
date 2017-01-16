namespace KhansKwikimartExternalServiceProxy.Responses
{
    public class KhansKwikimartResponse<T>
    {
        public bool successful { get; set; }
        public T target { get; set; }
        public string message { get; set; }
    }
}
