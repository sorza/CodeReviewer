using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;
using OpenAI.Chat;
using OpenAI.Responses;
using System.ComponentModel;

const string agentMarkdownPath = "Agents/code_reviewer.md";
const string codePath = "Agents/code.txt";
const string ollamaUrl = "http://localhost:11434";
string model = "qwen2.5-coder:7b";

var handler = new HttpClientHandler();
var httpClient = new HttpClient(handler)
{
    BaseAddress = new Uri(ollamaUrl),
    Timeout = TimeSpan.FromMinutes(5)
};

var ollama = new OllamaApiClient(httpClient);
var instructions = File.ReadAllText(agentMarkdownPath);
var code = File.ReadAllText(codePath);

var codeReviewerAgent = ollama.AsAIAgent(new ChatClientAgentOptions
{
    Name = "CodeReviewerAgent",
    Description = "Agente especialista em revisão de código C# e .NET",
    ChatOptions = new ChatOptions
    {
        ModelId = model,
        Temperature = 0.7f,
        Instructions = instructions
    }
});

var codeReviewerHelper = ollama.AsAIAgent(new ChatClientAgentOptions
{
    Name = "CodeReviewerHelper",
    Description = "Agente especialista em auxiliar os revisores de código.",
    ChatOptions = new ChatOptions
    {
        ModelId = model,
        Temperature = 0.7f,
        Instructions = "Sempre responda com o nome do revisor."
    }
});


var session = await codeReviewerAgent.CreateSessionAsync();

var prompt = $"Olá, eu sou o revisor Alexandre Zordan, revise o código C# e forneça feedback construtivo, sugestões de melhoria e identifique possíveis bugs ou problemas no código a seguir:\n\n{code}";
var review  = await codeReviewerAgent.RunAsync(prompt, session);
Console.WriteLine(review);

var response = await codeReviewerHelper.RunAsync("Qual é o nome do revisor?", session);
Console.WriteLine(response);