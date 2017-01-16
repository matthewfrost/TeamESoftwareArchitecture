namespace ExternalServiceProxy.Responses
{
    public class UndercuttersResponse<T>
    {
        public bool successful { get; set; }
        public T target { get; set; }
        public string message { get; set; }
    }
}
