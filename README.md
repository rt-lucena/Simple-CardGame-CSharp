# BlackJack.Core

Biblioteca de classes em C# (.NET 8) que modela as estruturas de um jogo de Blackjack simplificado.

---

## Solução

A solução foi organizada em duas camadas: **Enums**, que definem os tipos do domínio do jogo, e **Models**, que contêm as classes com as regras e comportamentos.

A classe `Carta` representa uma carta do baralho e sabe calcular seu próprio valor no contexto do Blackjack. O `Baralho` agrupa as 52 cartas e é responsável por embaralhar e distribuí-las. A `Mao` acumula as cartas de um participante e aplica a regra do **Ás flexível** (vale 11 ou 1 para evitar estouro).

O `Jogador` gerencia o saldo em fichas e as apostas, enquanto o `Dealer` herda de `Jogador` e adiciona o comportamento autônomo do banco: comprar cartas automaticamente até atingir 17 pontos. Por fim, a `Rodada` orquestra o fluxo completo de uma partida, desde a distribuição inicial até a apuração do resultado.

---

## Estrutura

```
BlackJack.Core/
├── Enums/
│   ├── Naipe.cs        # Copas, Ouros, Paus, Espadas
│   ├── Valor.cs        # As a Rei
│   └── Resultado.cs    # JogadorVenceu, DealerVenceu, Empate, Blackjack
└── Models/
    ├── Carta.cs        # Carta com naipe, valor e pontuação
    ├── Baralho.cs      # 52 cartas com embaralhamento e distribuição
    ├── Mao.cs          # Conjunto de cartas com cálculo de valor e Ás flexível
    ├── Jogador.cs      # Jogador com fichas e aposta
    ├── Dealer.cs       # Herda Jogador, compra cartas automaticamente até 17
    └── Rodada.cs       # Orquestra o fluxo completo de uma rodada
```

---

## Como executar

```bash
git clone https://github.com/rt-lucena/Simple-BlackJack-CSharp.git
cd BlackJack.Core
dotnet build
```

---

## Alunos

* **Nome:** Rafael Teofilo Lucena
* **RM:** 555600
