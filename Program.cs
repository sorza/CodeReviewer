using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.Chat;

const string agentMarkdownPath = "Agents/code_reviewer.md";
const string codePath = "Agents/code.txt";
const string model = "gpt-4o-mini";
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var openAiApiKey = config["OpenAI:ApiKey"];
var openAi = new OpenAIClient(openAiApiKey);

var instructions = File.ReadAllText(agentMarkdownPath);
var code = File.ReadAllText(codePath);

var codeReviewerAgent = openAi
    .GetChatClient(model)
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

/*
var result = await codeReviewerAgent.RunAsync(code);
Console.WriteLine(result);*/

await foreach(var token in codeReviewerAgent.RunStreamingAsync(code))
    Console.Write(token);
