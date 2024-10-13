using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class StringCipher
    {
        private const int SaltSize = 16;  // Tamaño del salt en bytes
        private const int KeySize = 32;   // Tamaño del hash en bytes
        private const int Iterations = 10000;  // Número de iteraciones para PBKDF2
        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;  // Algoritmo

        // Método para encriptar una cadena
        public static string Encrypt(string plainText)
        {
            // Generar un salt aleatorio
            var salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);  // Llenar el salt con valores aleatorios
            }

            // Derivar la clave usando PBKDF2
            var hash = Rfc2898DeriveBytes.Pbkdf2(plainText, salt, Iterations, HashAlgorithm, KeySize);

            // Concatenar el salt y el hash en una sola cadena (Base64)
            var hashBytes = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

            return Convert.ToBase64String(hashBytes);
        }

        // Método para verificar si una contraseña coincide con el hash almacenado
        public static bool Verify(string plainText, string hashedPlainText)
        {
            var hashBytes = Convert.FromBase64String(hashedPlainText);

            // Extraer el salt y el hash del arreglo de bytes
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var hash = new byte[KeySize];
            Array.Copy(hashBytes, SaltSize, hash, 0, KeySize);

            // Derivar la clave con la contraseña proporcionada y el salt extraído
            var newHash = Rfc2898DeriveBytes.Pbkdf2(plainText, salt, Iterations, HashAlgorithm, KeySize);

            // Comparar el hash original con el generado
            return CryptographicOperations.FixedTimeEquals(hash, newHash);
        }
    }
}
