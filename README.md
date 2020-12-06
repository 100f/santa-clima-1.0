<p align='center'>
<img src="https://i.imgur.com/RzGluDq.png" alt="Santa Clima Logo" width="65%" height="65%"/>
  
<br>
<br>

<img src="https://img.shields.io/badge/WinForms-purple?style=flat-square&logo=visual-studio"/>
<img src="https://img.shields.io/badge/C%23%20-%23239120.svg?&style=flat-square&logo=visual-studio&logoColor=white&color=purple"/>
<img src="https://img.shields.io/badge/MongoDB-3072a5?style=flat-square&logo=mongodb"/>

<br>

<img src="https://i.imgur.com/hsuDc5r.png" alt="Santa Clima Imagens" />
</p>

> __Um projeto para auxiliar a observar variações de parâmetros de uma estação meteorológica.__

<br>

## Sobre o Projeto
SantaClima é um programa que realiza a função de *datalogger* de uma estação meteorológica via comunicação serial, bem como retorna seus dados em gráficos cartesianos para estudo das variações de seus parâmetros coletados em certos intervalos de tempo.

O datalogger de uma estação é normalmente um dispositivo que persiste seus dados (em geral, localmente) para futuras observações e permanência dos mesmos. A ideia deste programa é armazenar os parâmetros coletados pela estação num banco de dados MongoDB dentro de um cluster online e mostrá-los, caso o usuário deseje, em gráficos para avaliação de sua variação com o tempo. É importante notar que, os gráficos serão gerados baseados nos registros inseridos nos últimos **7 dias.**

## Executando
Para rodar o projeto, clone este diretório:
```
$ git clone https://github.com/100f/santa-clima-1.0.git
```
Navegue então, até a pasta de release cujo diretório está abaixo e execute o arquivo `SantaClima.exe`:
```
$ cd bin/Release
```

## Funcionamento
1. A conexão da estação via cabo USB é feita a um computador com este software em execução.
2. A nova conexão COM serial deverá ser selecionada pelo usuário e estabelecida clicando em 'Conectar'.
3. A partir daí, a estação já está apta a mostrar na tela principal os registros e serialmente armazená-los na nuvem.

<hr>
<br>

Made by [Caio Enrique](http://github.com/100f) - Apr, 2020. :eyeglasses:



