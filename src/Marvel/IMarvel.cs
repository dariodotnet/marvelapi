namespace Marvel
{
    public interface IMarvel
    {
        IMarvel Initialize(string publicKey, string privateKey, bool bypassCertificate = false);
    }
}