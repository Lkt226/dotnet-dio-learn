namespace dotnet_dio_learn
{
    public class Aluno
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }

        public string nomeCompleto()
        {
            return nome + " " + sobrenome;
        }

        public decimal nota { get; set; }
    }
}