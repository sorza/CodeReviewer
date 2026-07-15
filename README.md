# CodeReviewer

Exemplo acadêmico de agente construído com **Microsoft Agent Framework (MAF)** para revisão de código.  
O objetivo é demonstrar como agentes podem analisar trechos de código, identificar problemas e sugerir melhorias de forma estruturada.

## Visão Geral

O **CodeReviewer** foi desenvolvido como um agente de estudo para mostrar o uso de MAF em cenários de revisão de código.  
Ele recebe trechos de código como entrada, aplica regras de análise e retorna uma saída estruturada com comentários e sugestões.

## Funcionalidades

- **Análise automática de código**: identifica problemas comuns e boas práticas.
- **Saída estruturada**: fornece feedback organizado em categorias (erros, alertas, sugestões).
- **Integração com MAF**: utiliza middlewares e extensões do framework.
- **Exemplo acadêmico**: ideal para aprendizado e demonstração de agentes inteligentes.

// Exemplo de entrada
string nome = null;
Console.WriteLine(nome.Length);

// Saída esperada
{
  "erros": ["Possível NullReferenceException ao acessar 'nome.Length'"],
  "sugestoes": ["Adicionar verificação de null antes de acessar a propriedade"]
}

