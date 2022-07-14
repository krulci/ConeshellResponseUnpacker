using System.Text;

namespace Unpacker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            byte[] array = Convert.FromBase64String("wN4AAyR83ruiqqs7E8/cKiNfG34erFL6duLFhZOth6uXVADalGHP/mpy0tDRHgMiGH99ehNi4oW2Dxj5icly7sTK86biDvzwoSEC06OLizUZviv9cn07qtxtxKCf/b0lM9WSSNTAYqe/sazCP83/ChegxTG9+Bue371qIgieCrkAv9Rtt10Zcn77qZaIRlEt1FGeSQk/oWnFKfG9cTgdkEGww0otWlhuix7/cix/z3zGgEU+cbfRd4s8xPKgujrfiadRwYbjLF3JWBzGhKdjG+D/Ly8FB7HEcov8Nw9/LtXjw9+mXPQ4APvun2AshKKr30Twbzkrv3pQbpwUz2Y24XpMIhAUh2Fjtq3asYr3vCt8OjFRHBzKPoidD5ewThNh4yq97DModqnkrC+U+O27nXiVQZwhTvlsSmmi/jryTK3ryKSRj7kdP5dojv9tvkC1U/ss/GDecuN5amBY19kaPm4ZHgFCnJnCHCpPfkFMk9yvyBWZEpBCiRnwk3fmh6qZddzRnbK0IOVSeUrvmmFKPvZ/6PFqENiKFbxEWJzVuOLAIuP+VNIDPqoRCkZvmf3eNZM9tbXRLRB34pYcLen1pCsb58eAvhiNuXOoPg==");
            byte[] array2 = Coneshell.NLAMANJEALE.Unpack(array);
            Console.WriteLine(Encoding.UTF8.GetString(array2));

        }
    }
}