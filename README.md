# CodeReviewer

> Um agente inteligente de revisão de código C# .NET alimentado por IA

## Sobre o Projeto

CodeReviewer é uma aplicação console que utiliza inteligência artificial para realizar revisões automatizadas de código C# .NET. O projeto implementa um agente especializado chamado **DotNet Sentinel v1**, que analisa código seguindo as melhores práticas de desenvolvimento, princípios SOLID e Clean Code.

## Características

-  **Agente IA Especializado**: Revisor sênior focado em C# e .NET
-  **Análise de Segurança**: Detecta vulnerabilidades como SQL Injection, credenciais expostas e XSS
-  **Verificação de Performance**: Identifica gargalos e códigos não otimizados
-  **Padrões de Design**: Valida implementação de Repository, Unit of Work e Dependency Injection
-  **Relatório Estruturado**: Saída detalhada com pontuação, pontos fortes e melhorias necessárias
-  **Foco em .NET 10**: Sugestões alinhadas com as funcionalidades mais modernas do C# 14

## Tecnologias

- **.NET 10**: Framework principal
- **Microsoft.Agents.AI**: Framework de agentes IA da Microsoft
- **OllamaSharp**: Cliente para comunicação com o servidor Ollama
- **User Secrets**: Gerenciamento seguro de credenciais


##  Funcionamento do Agente

O **DotNet Sentinel v1** segue um fluxo de trabalho estruturado:

1. **Análise Estática**: Identifica erros de sintaxe e violações de estilo
2. **Verificação de Padrões**: Compara com design patterns estabelecidos
3. **Avaliação de Performance**: Detecta gargalos e otimizações possíveis
4. **Feedback Estruturado**: Gera relatório com:
   -  O que está bom
   -  O que deve mudar
   -  Por que deve mudar
