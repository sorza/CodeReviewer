using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;
using OpenAI.Chat;
using OpenAI.Responses;

const string agentMarkdownPath = "Agents/code_reviewer.md";
const string codePath = "Agents/code.txt";
const string ollamaUrl = "http://localhost:11434";
string model = "qwen2.5-coder:7b";

var handler = new HttpClientHandler();
var httpClient = new HttpClient(handler)
{
    BaseAddress = new Uri(ollamaUrl),
    Timeout = TimeSpan.FromMinutes(2)
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

var response = await codeReviewerAgent.RunAsync<Result>(code);

Console.WriteLine($"Pontuação geral: {response.Result.OverallScore}/100");
Console.WriteLine($"Nota: {response.Result.Grade}");
Console.WriteLine($"Resumo: {response.Result.Summary}");

sealed record Result
{
    public string OverallScore { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}