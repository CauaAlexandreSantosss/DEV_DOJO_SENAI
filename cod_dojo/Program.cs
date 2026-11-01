// Nivel 1

/* O sistema começa cadastrando o cliente. Peçam os dados abaixo e, no final, mostrem a ficha formatada.

- Nome e nickname (texto).
- Plataforma: PC, PS5, Xbox ou Switch (texto).
- Ano em que virou cliente (número inteiro).
- Saldo em reais (número com centavos). */

using System.Globalization;
using System.Runtime.CompilerServices;

Console.WriteLine("NIVEL 1", "\n");

Console.WriteLine(" --- Ficha do Cliente ---");


Console.WriteLine("Crie um nome: ");
string nome = Console.ReadLine();


Console.WriteLine("Crie um nick name: ");
string nickName = Console.ReadLine();

Console.WriteLine("Qual plataforma voce ira ultilizar: ");
string plataforma = Console.ReadLine();

Console.WriteLine("Em que ano voce virou cliente? ");
int anoCliente = int.Parse(Console.ReadLine());

Console.WriteLine("Qual seu saldo em reais? ");
double saldo = double.Parse(Console.ReadLine());


Console.WriteLine("\n=== FICHA FORMATADA ===");
Console.WriteLine("Nome: " + nome + " | Nickname: " + nickName);
Console.WriteLine("Plataforma: " + plataforma + " | Desde: " + anoCliente);
Console.WriteLine("Saldo: R$ " + saldo.ToString("F2") + "\n");

/* Nivel 2 
 * O cliente quer saber se pode comprar um jogo. Perguntem o nome, a plataforma e o preço do jogo. Aqui é só uma consulta: **o saldo não muda**.

**Regras de negócio:**

- Jogo de outra plataforma: não pode comprar, e o sistema avisa o motivo.
- Mesma plataforma, mas o saldo não dá: mostra quanto falta.
- Tudo certo: pode comprar, e mostra quanto sobraria.
- Maiúsculas e minúsculas não importam: "ps5" é igual a "PS5". */

Console.WriteLine("CONSULTA DE JOGOS");

Console.WriteLine("Qual o nome do jogo? ");
string nomeJogo = Console.ReadLine();

Console.WriteLine("Qual a plataforma do jogo? ");
string plataformaJogo = Console.ReadLine();

Console.WriteLine("Qual o preço do jogo? ");
double precoJogo = double.Parse(Console.ReadLine());

if (plataforma.ToLower() != plataformaJogo.ToLower())
{
    Console.WriteLine("Não pode comprar, pois o jogo é de outra plataforma.");
}
else if (saldo < precoJogo)
{
    double falta = precoJogo - saldo;
    Console.WriteLine($"Não pode comprar, pois falta R$ {falta:F2}.");
}
else
{
    double sobra = saldo - precoJogo;
    Console.WriteLine($"Pode comprar! Sobraria R$ {sobra:F2}.");
}




/* Nivel 3 
 * Perguntem quantos jogos o cliente já tem, criem um array desse tamanho e peçam o nome de cada jogo. Depois, mostrem a biblioteca numerada e o total de jogos.

- Se o usuário digitar 0 ou um número negativo, considerem 1 jogo (a biblioteca não pode ficar vazia). */

Console.WriteLine("FICHARIO DE CONSULTA DE JOGOS");


Console.WriteLine("quantos jogos voce ja tem? ");
int qtsJogos = int.Parse(Console.ReadLine());

if (qtsJogos <= 0)
{
    qtsJogos = 1;
    Console.WriteLine("Número inválido. Considerando 1 jogo.");
}

string[] bibliotecaJogos = new string[qtsJogos];

for (int i = 0; i < bibliotecaJogos.Length; i++)
{
    Console.WriteLine($"Qual o nome do jogo {i + 1}? ");
    bibliotecaJogos[i] = Console.ReadLine();

    if (bibliotecaJogos[i] == null || bibliotecaJogos[i] == "")
    {
        Console.WriteLine("Nome inválido. Por favor, digite novamente.");
        i--; // Decrementa o índice para repetir a entrada
    }
}
Console.WriteLine("\nBiblioteca numerada:");
for (int i = 0; i < bibliotecaJogos.Length; i++)
{
    Console.WriteLine((i + 1) + " - " + bibliotecaJogos[i]);
}
Console.WriteLine("Total de jogos: " + bibliotecaJogos.Length + "\n");




/* Nivel 4 

O cliente digita o nome de um jogo e o sistema procura na biblioteca, pra evitar compra repetida.

- Maiúsculas e minúsculas não importam.
- Achou o jogo? Parem de procurar, não precisa olhar o resto do array. */

Console.WriteLine(" --- JOGOS DA SUA BIBLIOTECA ---");
Console.WriteLine("digite sair para encerrar a busca");
string JogoAProcurar;
do
{
    Console.WriteLine(" Qual jogo você está procurando? ");
    string jogoAProcurar = Console.ReadLine();

    if (jogoAProcurar.ToLower() == "sair")
    {
        break;

    }
    bool encontrada = false;
    for (int i = 0; i < bibliotecaJogos.Length; i++)
    {
        if (bibliotecaJogos[i].ToLower() == jogoAProcurar.ToLower())
        {
            encontrada = true;
            break;
        }
    }
    if (encontrada)
    {
        Console.WriteLine(" Jogo encontrado na Biblioteca");
    }
    else
    {
        Console.WriteLine(" Jogo não encontrado na Biblioteca");
    }
} while (true);

/* ## Nível 5: Quanto já gastou

Para cada jogo da biblioteca, perguntem quanto o cliente pagou. Guardem os valores num array de números do mesmo tamanho da biblioteca.

**Regras de negócio:**

- Mostrar o total gasto e a média por compra.
- Gastou mais de R$ 500,00? É cliente VIP.
- Não é VIP? Mostrar quanto falta pra virar. */

Console.WriteLine("-- MEDIA ARITMÉTICA DOS GASTOS --");

double[] valoresJogos = new double[bibliotecaJogos.Length];
double mediaAritmeticaJogos = 0;
double totalGasto = 0;

for (int i = 0; i < bibliotecaJogos.Length; i++)
{
    Console.WriteLine($"Quanto você pagou pelo jogo {bibliotecaJogos[i]}? ");
    valoresJogos[i] = double.Parse(Console.ReadLine());
    totalGasto += valoresJogos[i];
    mediaAritmeticaJogos += valoresJogos[i];
}

mediaAritmeticaJogos = totalGasto / bibliotecaJogos.Length;
Console.WriteLine("Total gasto: R$ " + totalGasto.ToString("F2") + " | Média por compra: R$ " + mediaAritmeticaJogos.ToString("F2"));

if (mediaAritmeticaJogos > 500)
{
    Console.WriteLine("Você é cliente VIP!");
}
else if (mediaAritmeticaJogos == 500)
{
    Console.WriteLine("Você está no limite de cliente VIP!");
}
else
{
    double faltaParaVIP = 500 - mediaAritmeticaJogos;
    Console.WriteLine("Você não é cliente VIP. Faltam R$ " + faltaParaVIP.ToString("F2") + " para se tornar VIP.");
}

/* Nivel 6: Jogos ## O jogo mais caro

Sem perguntar nada novo, descubram qual foi o jogo mais caro que o cliente comprou e mostrem o nome e o valor.

*/

// Encontrar o jogo mais caro

Console.WriteLine("\n--- JOGO MAIS CARO ---");
double precoMaximo = 0;
int indiceJogoMaisCaro = 0;

for (int i = 0; i < bibliotecaJogos.Length; i++)
{
    if (valoresJogos[i] > precoMaximo)
    {
        precoMaximo = valoresJogos[i];
        indiceJogoMaisCaro = i;
    }
}

Console.WriteLine("Seu jogo mais caro é: " + bibliotecaJogos[indiceJogoMaisCaro] + " - R$ " + precoMaximo.ToString("F2"));



/* Nivel 7 
Perguntem quantas horas o cliente jogou cada jogo e guardem num novo array.

**Regras de negócio:**

- Mostrar o total de horas jogadas.
- Mostrar o jogo mais jogado.
- Listar os jogos encostados (0 horas: comprou e nunca jogou). Se não tiver nenhum, mostrar uma mensagem. */

Console.WriteLine("--- HORAS JOGADAS ---- ");

double[] horasJogadas = new double[bibliotecaJogos.Length];
double totalHorasJogadas = 0;

for (int i = 0; i < bibliotecaJogos.Length; i++)
{
    Console.WriteLine($"Quantas horas você jogou {bibliotecaJogos[i]}? ");
    horasJogadas[i] = double.Parse(Console.ReadLine());
    totalHorasJogadas += horasJogadas[i];
}

Console.WriteLine("Total de horas jogadas: " + totalHorasJogadas.ToString("F2") + "h");


/* ## Nível 9 e 10: Menu com Opções e Top 3 */

Console.WriteLine("\n===== LOJA DE GAMES =====");
Console.WriteLine("1 - Ver ficha");
Console.WriteLine("2 - Ver biblioteca");
Console.WriteLine("3 - Relatório de gastos");
Console.WriteLine("4 - Horas jogadas");
Console.WriteLine("5 - Comprar jogo");
Console.WriteLine("6 - Top 3 mais jogados");
Console.WriteLine("0 - Sair");


while (true)
{
    Console.WriteLine("\nEscolha uma opção: ");
    string opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            // Mostrar ficha do cliente
            Console.WriteLine("\n=== FICHA FORMATADA ===");
            Console.WriteLine("Nome: " + nome + " | Nickname: " + nickName);
            Console.WriteLine("Plataforma: " + plataforma + " | Desde: " + anoCliente);
            Console.WriteLine("Saldo: R$ " + saldo.ToString("F2") + "\n");
            break;

        case "2":
            // Mostrar biblioteca
            Console.WriteLine("\nBiblioteca numerada:");
            for (int i = 0; i < bibliotecaJogos.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + bibliotecaJogos[i]);
            }
            Console.WriteLine("Total de jogos: " + bibliotecaJogos.Length + "\n");
            break;

        case "3":
            // Relatório de gastos
            totalGasto = 0;
            for (int i = 0; i < valoresJogos.Length; i++)
            {
                totalGasto += valoresJogos[i];
            }
            mediaAritmeticaJogos = totalGasto / valoresJogos.Length;

            precoMaximo = 0;
            indiceJogoMaisCaro = 0;
            for (int i = 0; i < valoresJogos.Length; i++)
            {
                if (valoresJogos[i] > precoMaximo)
                {
                    precoMaximo = valoresJogos[i];
                    indiceJogoMaisCaro = i;
                }
            }

            Console.WriteLine("\n--- RELATÓRIO DE GASTOS ---");
            Console.WriteLine("Total gasto: R$ " + totalGasto.ToString("F2"));
            Console.WriteLine("Média por compra: R$ " + mediaAritmeticaJogos.ToString("F2"));
            Console.WriteLine("Jogo mais caro: " + bibliotecaJogos[indiceJogoMaisCaro] + " - R$ " + precoMaximo.ToString("F2"));

            if (mediaAritmeticaJogos > 500)
                Console.WriteLine("Status: Cliente VIP 🌟");
            else
                Console.WriteLine("Status: Cliente Comum");
            break;

        case "4":
            // Mostrar horas jogadas completo (Nível 7)
            totalHorasJogadas = 0;
            double maxHoras = -1;
            int indiceMaisJogado = 0;
            int contadorEncostados = 0;

            for (int i = 0; i < horasJogadas.Length; i++)
            {
                totalHorasJogadas += horasJogadas[i];
                if (horasJogadas[i] > maxHoras)
                {
                    maxHoras = horasJogadas[i];
                    indiceMaisJogado = i;
                }
                if (horasJogadas[i] == 0)
                {
                    contadorEncostados++;
                }
            }

            Console.WriteLine("\n--- RELATÓRIO DE HORAS JOGADAS ---");
            Console.WriteLine("Total de horas: " + totalHorasJogadas.ToString("F2") + "h");
            Console.WriteLine("Mais jogado: " + bibliotecaJogos[indiceMaisJogado] + " (" + maxHoras + "h)");

            Console.WriteLine("Jogos encostados (0 horas):");
            if (contadorEncostados == 0)
            {
                Console.WriteLine("- Nenhum jogo encostado! Você jogou todos.");
            }
            else
            {
                for (int i = 0; i < horasJogadas.Length; i++)
                {
                    if (horasJogadas[i] == 0)
                    {
                        Console.WriteLine("- " + bibliotecaJogos[i]);
                    }
                }
            }
            break;

        case "5":
            // Comprar jogo (Nível 8 integrado ao menu)
            Console.WriteLine("\n--- COMPRA DE JOGO NOVO ---");
            Console.WriteLine("Qual o nome do jogo que deseja comprar? ");
            string novoNomeJogo = Console.ReadLine();

            Console.WriteLine("Qual a plataforma do jogo? ");
            string novaPlataformaJogo = Console.ReadLine();

            Console.WriteLine("Qual o preço do jogo? ");
            double novoPrecoJogo;
            if (!double.TryParse(Console.ReadLine(), out novoPrecoJogo))
            {
                Console.WriteLine("Preço inválido. Compra cancelada.");
                break;
            }

            // Regra 1: Já tem o jogo?
            bool jaPossui = false;
            for (int i = 0; i < bibliotecaJogos.Length; i++)
            {
                if (bibliotecaJogos[i].Equals(novoNomeJogo, StringComparison.OrdinalIgnoreCase))
                {
                    jaPossui = true;
                    break;
                }
            }

            if (jaPossui)
            {
                Console.WriteLine($"Compra bloqueada: Você já possui o jogo '{novoNomeJogo}'.");
            }
            // Regra 2: Plataforma diferente?
            else if (!plataforma.Equals(novaPlataformaJogo, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Compra bloqueada: O jogo é para '{novaPlataformaJogo}', mas sua plataforma é '{plataforma}'.");
            }
            // Regra 3: Saldo não dá?
            else if (saldo < novoPrecoJogo)
            {
                double falta = novoPrecoJogo - saldo;
                Console.WriteLine($"Saldo insuficiente. Faltam R$ {falta:F2}.");
            }
            // Regra 4: Tudo certo
            else
            {
                saldo -= novoPrecoJogo;

                Array.Resize(ref bibliotecaJogos, bibliotecaJogos.Length + 1);
                Array.Resize(ref valoresJogos, valoresJogos.Length + 1);
                Array.Resize(ref horasJogadas, horasJogadas.Length + 1);

                int novoIndice = bibliotecaJogos.Length - 1;
                bibliotecaJogos[novoIndice] = novoNomeJogo;
                valoresJogos[novoIndice] = novoPrecoJogo;
                horasJogadas[novoIndice] = 0;

                Console.WriteLine($"\n✅ Jogo '{novoNomeJogo}' adicionado à biblioteca com sucesso!");
                Console.WriteLine($"Saldo restante: R$ {saldo:F2}");
            }
            break;

        case "6":
            // Nível 10: Top 3 mais jogados (Lógica pura, sem LINQ/métodos prontos)
            Console.WriteLine("\n===== TOP 3 MAIS JOGADOS =====");
            if (bibliotecaJogos.Length < 3)
            {
                Console.WriteLine("A biblioteca precisa ter pelo menos 3 jogos para exibir o Top 3.");
                break;
            }

            // 1º Lugar (Maior valor)
            int idx1 = -1;
            double max1 = -1;
            for (int i = 0; i < horasJogadas.Length; i++)
            {
                if (horasJogadas[i] > max1)
                {
                    max1 = horasJogadas[i];
                    idx1 = i;
                }
            }

            // 2º Lugar (Maior valor ignorando o índice do 1º)
            int idx2 = -1;
            double max2 = -1;
            for (int i = 0; i < horasJogadas.Length; i++)
            {
                if (i != idx1 && horasJogadas[i] > max2)
                {
                    max2 = horasJogadas[i];
                    idx2 = i;
                }
            }

            // 3º Lugar (Maior valor ignorando os índices do 1º e do 2º)
            int idx3 = -1;
            double max3 = -1;
            for (int i = 0; i < horasJogadas.Length; i++)
            {
                if (i != idx1 && i != idx2 && horasJogadas[i] > max3)
                {
                    max3 = horasJogadas[i];
                    idx3 = i;
                }
            }

            Console.WriteLine($"1º {bibliotecaJogos[idx1]} - {max1}h");
            Console.WriteLine($"2º {bibliotecaJogos[idx2]} - {max2}h");
            Console.WriteLine($"3º {bibliotecaJogos[idx3]} - {max3}h");
            break;

        case "0":
            // Sair do programa
            Console.WriteLine($"Até a próxima, {nickName}!");
            return;

        default:
            Console.WriteLine("Opção inválida. Digite um número de 0 a 6.");
            break;
    }
}