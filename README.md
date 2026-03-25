# CardGame.Core

Biblioteca de classes em C# (.NET 8) que modela as estruturas genéricas de um jogo de cartas com baralho padrão de 52 cartas.

---

## Sobre o Projeto

O **CardGame.Core** é uma biblioteca desenvolvida com o objetivo de fornecer uma base genérica e reutilizável para jogos de cartas utilizando um baralho padrão de 52 cartas.

O projeto abstrai os principais elementos comuns a esse tipo de jogo, como:

* Cartas
* Baralho
* Mão de jogo
* Jogador

A proposta é separar claramente a **estrutura do jogo** das **regras específicas**, permitindo que diferentes tipos de jogos sejam implementados a partir dessa base, sem necessidade de reescrever funcionalidades fundamentais.

---

## Propósito

Esta biblioteca fornece os **blocos fundamentais** reutilizáveis por qualquer jogo de cartas: baralho, carta, mão e jogador.

---

## Estrutura

```
CardGame.Core/
├── Enums/
│   ├── Naipe.cs        # Copas, Ouros, Paus, Espadas
│   ├── Valor.cs        # As a Rei (valores ordinais 1–13)
│   └── Resultado.cs    # JogadorVenceu, AdversarioVenceu, Empate
└── Models/
    ├── Carta.cs        # Carta com naipe e valor (sem pontuação embutida)
    ├── Baralho.cs      # 52 cartas com embaralhamento e distribuição
    ├── Mao.cs          # Conjunto de cartas com pontuação configurável
    └── Jogador.cs      # Jogador com fichas e aposta
```

---

## Como usar

```bash
git clone <repositório>
cd CardGame.Core
dotnet build
```

---

## Alunos

* **Nome:** Rafael Teofilo Lucena
* **RM:** 555600

---

Se quiser dar um próximo passo, posso te ajudar a adicionar:

* exemplos de código (`Exemplo de uso`)
* testes unitários sugeridos
* ou até uma versão pronta para publicação no NuGet 🚀
