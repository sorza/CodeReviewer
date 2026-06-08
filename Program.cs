using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

const string agentMarkdownPath = "Agents/code_reviewer.md";
const string codePath = "Agents/code.md";
const string ollamaUrl = "http://localhost:11434";
const string model = "qwen2.5-coder:7b";

var handler = new HttpClientHandler();
var httpClient = new HttpClient(handler)
{
    BaseAddress = new Uri(ollamaUrl),
    Timeout = TimeSpan.FromMinutes(2)
};

var ollama = new OllamaApiClient(httpClient);
var instructions = File.ReadAllText(agentMarkdownPath);
var code = File.ReadAllText(codePath);

var codeReviewerAgent = ollama
    .AsAIAgent(new ChatClientAgentOptions
    {
        Name = "CodeReviewerAgent",
        Description = "Agente especista em revisão de código C# .NET",
        ChatOptions = new ChatOptions
        {
            ModelId = model,
            Temperature = 0.7f,
            Instructions = instructions
        }
    });

