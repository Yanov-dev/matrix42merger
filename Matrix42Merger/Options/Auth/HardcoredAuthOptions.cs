using System;

namespace Matrix42Merger.Options.Auth
{
    public class HardcoredAuthOptions : IAuthOptions
    {
        public string EncryptKey { get; } = "very_secure_encrypt_key";
        public string Issuer { get; } = "Overlord";
        public string Audience { get; } = "google.com";
        public TimeSpan Lifetime { get; } = TimeSpan.FromHours(6);
    }
}