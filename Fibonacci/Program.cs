// Criamos um dicionário que irá conter as respostas já obtidas, evitando operações redundantes
var answers = new Dictionary<int, int>(){
    {0, 0},
    {1, 1}
};

var running = true;

const string positive = "Valor pertence à sequência de fibonacci";
const string negative = "Valor não pertence à sequência de fibonacci";
const string error = "Valor inválido";

Console.WriteLine("***** FIBONACCI *****");
Console.WriteLine("Para sair, insira x");

while (running)
{
    Console.Write("Insira um número\n>");
    string? input = Console.ReadLine();
    if (input == null)
    {
        continue;
    }
    else if (input.Equals("x", StringComparison.OrdinalIgnoreCase))
    {
        running = false;
    }
    else
    {
        int value;
        if (!int.TryParse(input, out value))
        {
            Console.WriteLine(error);
        }
        else if (value <= 0)
        {
            Console.WriteLine(negative);
        }
        else
        {
            if (valueIsInSequence(value))
            {
                Console.WriteLine(positive);
            }
            else
            {
                Console.WriteLine(negative);
            }
        }
    }
}

int fibonacci(int index)
{
    if (answers.Keys.Contains(index))
    {
        return answers[index];
    }

    var results = fibonacci(index - 1) + fibonacci(index - 2);
    answers[index] = results; // Guardamos o novo resultado no dicionário
    return results;
}

bool valueIsInSequence(int value)
{
    if (value < 0)
    {
        return false;
    }
    if (answers.Values.Contains(value))
    {
        return true;
    }

    // Se o último valor é maior que o valor dado, não é possível que o número esteja na sequencia
    if (answers.Values.Last() > value)
    {
        return false;
    }

    while (answers.Values.Last() < value)
    {
        // Sempre último valor processado + 1
        var temp = fibonacci(answers.Count);
        if (temp == value)
        {
            return true;
        }
    }

    return false;
}