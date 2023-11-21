using Desafio01.Models;
using System.Security.Cryptography;
using System.Text;

namespace Desafio01.Services
{
    public class CriptografiaDados
    {
        public IEnumerable<string> Codificando(CartaoCredito cartaoCredito)
        {
            List<string> list = new List<string>();
            list.Clear();
            string Elementos(int i)
            {
                if (i == 1)
                {
                    return cartaoCredito.UserDocument.ToString();
                }
                else
                {
                    return cartaoCredito.CartaoToken.ToString();
                }
            }
            for(int i=0; i<2; i++)
            {
                SHA512 sHA512 = SHA512.Create();
                byte[] Bytes = Encoding.UTF8.GetBytes(Elementos(i));
                byte[] Hash = sHA512.ComputeHash(Bytes);
                string convertido=BitConverter.ToString(Hash);
                list.Add(convertido);
            }
            return list;
        }
        
    }
}
