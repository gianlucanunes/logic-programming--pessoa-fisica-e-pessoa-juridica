/*
 * 
 *      PT-BR: Exercício de Lógica de Programação: Cadastro de pessoa Física e Pessoa Jurídica usando classes, superclasse e filtragem de dados usando LINQ.
 *
 *      Feito por: Gianluca Nunes
 *
 */

// Cria as listas de pessoa física
List<PessoaFisica> listaPF = new List<PessoaFisica>();
List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

// Menu onde o usuário escolhe que tipo de pessoa ele quer adicionar à lista
_menu:
Console.WriteLine("Olá! Deseja realizar qual operação?\n[F] Cadastrar Pessoa Física\n[J] Cadastrar Pessoa Jurídica\n[E] Exibir dados");
string opcMenu = Console.ReadLine().ToLower();

// Criando os id's e iniciando-os com o valor 1
int idPF = 1;
int idPJ = 1;

switch(opcMenu)
{
    // Cadastro de pessoa Física
    case "f":
        string opcPF = "s";

        // Local onde o usuário preenche as informações sobre Pessoa Física
        while (opcPF == "s")
        {
            // Criando o objeto objPf do tipo PessoaFisica
            PessoaFisica objPf = new PessoaFisica(); 

            // Pedindo ao usuário para preencher as informações
            Console.WriteLine("\nVocê escolheu cadastrar uma pessoa física. Preencha as informações abaixo:");
            Console.Write("\nNome: ");
            objPf.Nome = Console.ReadLine();

        _idadePf:
            // Validando a idade
            Console.Write("Idade: ");
            int idade;
            if (int.TryParse(Console.ReadLine(), out idade))
            {
                objPf.Idade = idade;
            }
            else
            {
                Console.WriteLine("\nOpção inválida!\n");
                goto _idadePf;
            }

            // Adicionando o Id da pessoa física
            objPf.Id = idPF;
            idPF++;

            Console.Write("RG: ");
            objPf.Rg = Console.ReadLine();

            Console.Write("Região: ");
            objPf.Regiao = Console.ReadLine();

            Console.Write("Nacionalidade: ");
            objPf.Nacionalidade = Console.ReadLine();

        _dataNasc:
            // Validando a data de nascimento
            Console.Write("Data de nascimento: ");
            DateTime dataNascimento;
            if (DateTime.TryParse(Console.ReadLine(), out dataNascimento))
            {
                objPf.DataNascimento = dataNascimento;
            }
            else
            {
                Console.WriteLine("\nOpção inválida!\n");
                goto _dataNasc;
            }

            // Adicionando o objeto completo à lista de Pessoa Fisica
            listaPF.Add(objPf); 

        _cadNovaPf:
            // Perguntando ao usuário se este gostaria de cadastar uma nova pessoa física
            Console.WriteLine("\nGostaria de adicionar uma nova pessoa física?\n[S] Sim\n[N] Não");
            opcPF = Console.ReadLine().ToLower();

            // Validando o input do usuário
            if (opcPF != "s" && opcPF != "n")
            {
                Console.WriteLine("\nOpção inválida!\n");
                goto _cadNovaPf;
            }
            else if (opcPF == "n")
            {
                goto _menu;
            }
        }
        break;

    // Cadastro de pessoa jurídica
    case "j":
        string opcPJ = "s";

        // Local onde o usuário preenche as informações sobre Pessoa Jurídica
        while (opcPJ == "s")
        {
            PessoaJuridica objPj = new PessoaJuridica(); // Cria o objeto Pessoa Jurídica

            // Pedindo ao usuário para preencher as informações
            Console.WriteLine("\nVocê escolheu cadastrar uma pessoa jurídica. Preencha as informações abaixo:\n");
            Console.Write("\nNome: ");
            objPj.Nome = Console.ReadLine();

        _idadePj:
            // Validando a idade
            Console.Write("Idade: ");
            int idade;
            if (int.TryParse(Console.ReadLine(), out idade))
            {
                objPj.Idade = idade;
            }
            else
            {
                Console.WriteLine("\nOpção inválida!\n");
                goto _idadePj;
            }

            // Adicionando o Id da pessoa jurídica
            objPj.Id = idPJ;
            idPJ++;

            Console.Write("CNPJ: ");
            objPj.Cnpj = Console.ReadLine();

            Console.Write("Nome da empresa: ");
            objPj.NomeEmpresa = Console.ReadLine();

            Console.Write("Área de atuação: ");
            objPj.AreaAtuacao = Console.ReadLine();

            Console.Write("Porte da empresa: ");
            objPj.Porte = Console.ReadLine();

        _dataCriacao:
            // Validando a data de criação
            Console.Write("Data de criação: ");
            DateTime dataCriacao;
            if (DateTime.TryParse(Console.ReadLine(), out dataCriacao))
            {
                objPj.DataCriacao = dataCriacao;
            }
            else
            {
                Console.WriteLine("\nOpção inválida!\n");
                goto _dataCriacao;
            }

            // Adicionando o objeto completo à lista de Pessoa Fisica
            listaPJ.Add(objPj); // Adiciona o objeto à lista

        _cadNovaPj:
            // Perguntando ao usuário se este gostaria de cadastar uma nova pessoa jurídica
            Console.WriteLine("\nGostaria de adicionar uma nova pessoa jurídica?\n[S] Sim\n[N] Não");
            opcPJ = Console.ReadLine().ToLower();

            // Validando o input do usuário
            if (opcPJ != "s" && opcPJ != "n")
            {
                Console.WriteLine("\nOpção inválida!\n");
                goto _cadNovaPj;
            }
            else if (opcPJ == "n")
            {
                goto _menu;
            }
        }
        break;

    // Aplicando a filtragem dos dados
    case "e":
        // Verifica se as listas estão vazias
        if (listaPF.Count() == 0 || listaPJ.Count() == 0)
        {
            Console.WriteLine("\nVocê precisa cadastrar ao menos 1 pessoa física e 1 pessoa jurídica para listar os dados!\n");
            goto _menu;
        }
        else
        {
            // Criando um objeto de pessoa física e exibindo os dados
            PessoaFisica objPf = new PessoaFisica();
            Console.WriteLine("----- PESSOA FÍSICA -----");
            foreach (var itemPF in listaPF)
            {
                itemPF.ExibirDados();
            }

            // Criando um objeto de pessoa jurídica e exibindo os dados
            PessoaJuridica objPj = new PessoaJuridica(); 
            Console.WriteLine("----- PESSOA JURÍDICA -----");
            foreach (var itemPJ in listaPJ)
            {
                itemPJ.ExibirDados();
            }

        _menuFiltro:
            // Perguntando em qual lista o usuário gostaria de aplicar um filtro
            Console.WriteLine("\nDeseja aplicar um filtro em qual lista? \n[F] Pessoa Física \n[J] Pessoa Jurídica");
            string opcF = Console.ReadLine().ToLower();
            
            // Criando a string de tipo de filtro
            string selF;
            // Criando a string que armazenará o filtro digitado pelo usuário
            string filtro;

            // Valida o input do usuário
            if (opcF != "f" && opcF != "j")
            {
                Console.WriteLine("\nOpção inválida!\n");
                goto _menuFiltro;
            }
            // Menu de filtro da pessoa física
            else if (opcF == "f")
            {
            _menuFiltroPf:
                // Pergunta ao usuário que filtro ele gostaria de aplicar
                Console.WriteLine("\nQual filtro deseja aplicar?\n[R] Região\n[N] Nacionalidade\n");
                selF = Console.ReadLine().ToLower();

                // Valida o input do usuário
                if (selF != "r" && selF != "n")
                {
                    Console.WriteLine("\nOpção inválida!\n");
                    goto _menuFiltroPf;
                }
                // Aplica o filtro de região
                else if (selF == "r")
                {
                _filtroRegiao:
                    // Pede ao usuário para digitar o filtro
                    Console.Write("\nDigite o filtro: ");

                    // Guarda o filtro usando a propriedade lowerinvariant, que ignora letras maiúsculas ou minúsculas
                    filtro = Console.ReadLine().ToLowerInvariant(); 

                    // Aplica o filtro na Query de pessoa física usando a expressão lambda
                    var pfQuery = listaPF.Where(i => i.Regiao == filtro); 

                    // Verifica se a Query está vazia, isto é, se o filtro digitado existe
                    if (pfQuery.Count() == 0)
                    {
                        Console.WriteLine("\nNão há nenhum filtro com esse nome!\n");
                        goto _filtroRegiao;
                    }
                    
                    // Caso o filtro exista, exibe os dados de pessoa física com filtro aplicado
                    foreach (var itemPF in pfQuery) 
                    {
                        itemPF.ExibirDados(); 
                    }
                }
                else
                {
                _filtroNacionalidade:
                    // Pede ao usuário para digitar o filtro
                    Console.Write("\nDigite o filtro: ");

                    // Guarda o filtro usando a propriedade lowerinvariant, que ignora letras maiúsculas ou minúsculas
                    filtro = Console.ReadLine().ToLowerInvariant(); 

                    // Aplica o filtro na Query de pessoa física usando a expressão lambda
                    var pfQuery = listaPF.Where(i => i.Nacionalidade == filtro); 

                    // Verifica se a Query está vazia, isto é, se o filtro digitado existe
                    if (pfQuery.Count() == 0)
                    {
                        Console.WriteLine("\nNão há nenhum filtro com esse nome!\n");
                        goto _filtroNacionalidade;
                    }

                    // Caso o filtro exista, exibe os dados de pessoa física com filtro aplicado
                    foreach (var itemPF in pfQuery)
                    {
                        itemPF.ExibirDados();
                    }
                }
            }
            // Menu de filtro da pessoa jurídica
            else if (opcF == "j")
            {
            _menuFiltroPj:
                // Pergunta ao usuário que filtro ele gostaria de aplicar
                Console.WriteLine("\nQual filtro deseja aplicar?\n[A] Área de atuação\n[P] Porte\n");
                selF = Console.ReadLine().ToLower();

                // Valida o input do usuário
                if (selF != "a" && selF != "p")
                {
                    Console.WriteLine("\nOpção inválida!\n");
                    goto _menuFiltroPj;
                }
                // Aplica o filtro de área de atuação
                else if (selF == "a")
                {
                _filtroAreaAtuac:
                    // Pede ao usuário para digitar o filtro
                    Console.Write("\nDigite o filtro: ");

                    // Guarda o filtro usando a propriedade lowerinvariant, que ignora letras maiúsculas ou minúsculas
                    filtro = Console.ReadLine().ToLowerInvariant();

                    // Aplica o filtro na Query de pessoa jurídica usando a expressão lambda
                    var pjQuery = listaPJ.Where(i => i.AreaAtuacao == selF);

                    // Verifica se a Query está vazia, isto é, se o filtro digitado existe
                    if (pjQuery.Count() == 0)
                    {
                        Console.WriteLine("\nNão há nenhum filtro com esse nome!\n");
                        goto _filtroAreaAtuac;
                    }

                    // Caso o filtro exista, exibe os dados de pessoa jurídica com filtro aplicado
                    foreach (var itemPJ in pjQuery)
                    {
                        itemPJ.ExibirDados();
                    }
                }
                else
                {
                _filtroPorte:
                    // Pede ao usuário para digitar o filtro
                    Console.Write("\nDigite o filtro: "); 

                    // Guarda o filtro usando a propriedade lowerinvariant, que ignora letras maiúsculas ou minúsculas
                    filtro = Console.ReadLine().ToLowerInvariant(); 

                    // Aplica o filtro na Query de pessoa jurídica usando a expressão lambda
                    var pjQuery = listaPJ.Where(i => i.Porte == filtro); 

                    // Verifica se a Query está vazia, isto é, se o filtro digitado existe
                    if (pjQuery.Count() == 0)
                    {
                        Console.WriteLine("\nNão há nenhum filtro com esse nome!\n");
                        goto _filtroPorte;
                    }

                    // Caso o filtro exista, exibe os dados de pessoa jurídica com filtro aplicado
                    foreach (var itemPJ in pjQuery)
                    {
                        itemPJ.ExibirDados();
                    }
                }
            }
            // Fim do programa
            Console.WriteLine("\nTecle espaço para continuar...");
            Console.ReadKey();
        }
        break;

    // Valida a opção digitada pelo usuário
    default:
        Console.WriteLine("\nOpção inválida!\n");
        goto _menu;
}