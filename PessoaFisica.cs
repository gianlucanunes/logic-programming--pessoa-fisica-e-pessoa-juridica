// Cria a classe pública PessoaFisica que vai herdar da super classe usuario
public class PessoaFisica : Usuario
{
    // Cria as propriedades da classe
    public string Rg { get; set; }
    // Aplicação do método ToLowerInvariant para ignorar letras mínusculas e maiúsculas na hora de aplicar o filtro da região
    private string _Regiao;
    public string Regiao 
    { 
        get { return _Regiao; }
        set { _Regiao = value.ToLowerInvariant(); }
    }
    // Aplicação do método ToLowerInvariant para ignorar letras mínusculas e maiúsculas na hora de aplicar o filtro da nacionalidade
    private string _Nacionalidade;
    public string Nacionalidade 
    {
        get { return _Nacionalidade; }
        set { _Nacionalidade = value.ToLowerInvariant(); } 
    }
    public DateTime DataNascimento { get; set; }

    // Cria o método para exibir os dados
    public void ExibirDados()
    {
        Console.WriteLine($"\nNome: {Nome}\nIdade: {Idade} anos\nId: {Id}\nRg: {Rg}\nRegião: {Regiao}\nNacionalidade: {Nacionalidade}\nData de nascimento: {DataNascimento.ToString("dd/MM/yyyy")}\n");
    }
}
