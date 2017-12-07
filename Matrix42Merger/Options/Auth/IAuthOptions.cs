using System;

namespace Matrix42Merger.Options.Auth
{
    public interface IAuthOptions
    {
        string EncryptKey { get; }
        string Issuer { get; }
        string Audience { get; }
        TimeSpan Lifetime { get; }
    }
}