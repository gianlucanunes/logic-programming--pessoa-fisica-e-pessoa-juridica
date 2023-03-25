// Cria a classe pública PessoaJuridica que vai herdar da super classe usuario
public class PessoaJuridica : Usuario
{
    // Cria as propriedades da classe
    public string Cnpj { get; set; }
    public string NomeEmpresa { get; set; }
    // Aplicação do método ToLowerInvariant para ignorar letras mínusculas e maiúsculas na hora de aplicar o filtro da área de atuação
    private string _AreaAtuacao;
    public string AreaAtuacao
    {
        get { return _AreaAtuacao; }
        set { _AreaAtuacao = value.ToLowerInvariant(); } 
    }
    // Aplicação do método ToLowerInvariant para ignorar letras mínusculas e maiúsculas na hora de aplicar o filtro do porte
    private string _Porte;
    public string Porte
    {
        get { return _Porte; }
        set { _Porte = value.ToLowerInvariant(); } 
    }
    public DateTime DataCriacao { get; set; }

    // Cria o método para exibir os dados
    public void ExibirDados()
    {
        Console.WriteLine($"\nNome: {Nome}\nIdade: {Idade} anos\nId: {Id}\nCNPJ: {Cnpj}\nNome da empresa: {NomeEmpresa}\nÁrea de atuação: {AreaAtuacao}\nPorte da empresa: {Porte}\nData de criação: {DataCriacao.ToString("dd/MM/yyyy")}\n");
    }
}