# CodeReviewer

> Um agente inteligente de revisão de código C# .NET alimentado por IA

## Sobre o Projeto

CodeReviewer é uma aplicação console que utiliza inteligência artificial (OpenAI GPT-4) para realizar revisões automatizadas de código C# .NET. O projeto implementa um agente especializado chamado **DotNet Sentinel v1**, que analisa código seguindo as melhores práticas de desenvolvimento, princípios SOLID e Clean Code.

## Características

- 🤖 **Agente IA Especializado**: Revisor sênior focado em C# e .NET
- 🔒 **Análise de Segurança**: Detecta vulnerabilidades como SQL Injection, credenciais expostas e XSS
- ⚡ **Verificação de Performance**: Identifica gargalos e códigos não otimizados
- 📐 **Padrões de Design**: Valida implementação de Repository, Unit of Work e Dependency Injection
- 📊 **Relatório Estruturado**: Saída detalhada com pontuação, pontos fortes e melhorias necessárias
- 🎯 **Foco em .NET 10**: Sugestões alinhadas com as funcionalidades mais modernas do C# 14

## Tecnologias

- **.NET 10**: Framework principal
- **Microsoft.Agents.AI**: Framework de agentes IA da Microsoft
- **OpenAI GPT-4o-mini**: Modelo de linguagem para análise
- **User Secrets**: Gerenciamento seguro de credenciais

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Conta na [OpenAI Platform](https://platform.openai.com/)
- Visual Studio 2026 ou Visual Studio Code

## Configuração

### 1. Clone o repositório

```bash
git clone https://github.com/sorza/CodeReviewer.git
cd CodeReviewer
```

### 2. Configure a API Key da OpenAI

#### Visual Studio:
1. Clique com botão direito no projeto
2. Selecione **Manage User Secrets**
3. Adicione a configuração:

```json
{
  "OpenAI:ApiKey": "sua-api-key-aqui"
}
```

#### Via CLI:
```bash
dotnet user-secrets set "OpenAI:ApiKey" "sua-api-key-aqui"
```

> ** Nota**: Obtenha sua API Key em https://platform.openai.com/api-keys

### 3. Restaure as dependências

```bash
dotnet restore
```

##  Como Usar

### 1. Adicione o código a ser revisado

Edite o arquivo `Agents/code.txt` com o código C# que deseja analisar.

### 2. Execute a aplicação

```bash
dotnet run
```

A revisão será exibida em tempo real no console com streaming de resposta.

## Estrutura do Projeto

```
CodeReviewer/
├── Agents/
│   ├── code_reviewer.md    # Configuração do agente revisor
│   └── code.txt            # Código a ser analisado
├── Program.cs              # Ponto de entrada da aplicação
├── CodeReviewer.csproj     # Arquivo de projeto
└── README.md
```

## 🧠 Funcionamento do Agente

O **DotNet Sentinel v1** segue um fluxo de trabalho estruturado:

1. **Análise Estática**: Identifica erros de sintaxe e violações de estilo
2. **Verificação de Padrões**: Compara com design patterns estabelecidos
3. **Avaliação de Performance**: Detecta gargalos e otimizações possíveis
4. **Feedback Estruturado**: Gera relatório com:
   - ✅ O que está bom
   - ⚠️ O que deve mudar
   - 💡 Por que deve mudar

## 📊 Exemplo de Saída

```json
{
  "OverallScore": 45,
  "Grade": "C-",
  "Summary": "O código funciona, mas possui riscos de segurança...",
  "Strengths": [
    "Uso correto de namespaces",
    "Nomes de variáveis claros"
  ],
  "Improvements": [
    "Remover SQL Injection",
    "Implementar async/await",
    "Remover credenciais do código"
  ],
  "CodeExamples": ["..."],
  "NextSteps": [
    "Criar interface IRepository",
    "Configurar segredos no Key Vault"
  ],
  "Encouragement": "Bom trabalho na lógica central!"
}
```

## Segurança

-  Usa **User Secrets** para armazenar API Keys
-  Não armazena credenciais em código
-  Detecta e alerta sobre strings suspeitas (tokens, connection strings)

##  Solução de Problemas

### Erro: HTTP 429 (insufficient_quota)

**Causa**: Sem créditos na conta OpenAI

**Solução**:
1. Acesse https://platform.openai.com/usage
2. Verifique seu saldo e limites
3. Configure billing em https://platform.openai.com/settings/organization/billing/overview

### Erro: DirectoryNotFoundException

**Causa**: Arquivos da pasta `Agents/` não copiados para saída

**Solução**: Já corrigido no `.csproj` com `CopyToOutputDirectory="PreserveNewest"`

## Desenvolvimento

### Dependências

```xml
<PackageReference Include="Microsoft.Agents.AI" Version="1.13.0" />
<PackageReference Include="Microsoft.Agents.AI.OpenAI" Version="1.13.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="10.0.9" />
```

### Debug

```bash
dotnet build
dotnet run
```