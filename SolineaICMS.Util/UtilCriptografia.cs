namespace SolineaICMS.Util
{
    public static class UtilCriptografia
    {
        /// <summary>
        /// Criptografa um string em MD5
        /// </summary>
        /// <param name="input">Entrada a ser criptografada</param>
        /// <returns></returns>
        public static string GetMd5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
