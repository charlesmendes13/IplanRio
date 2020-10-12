# IplanRio
Desafio Desenvolvedor .NET da IplanRio.

## Problema
Imagine que você ficou responsável por construir uma funcionalidade para o sistema de fiscalização da Vigilância Sanitária que seja capaz de receber o cadastro de todos os shoppings centers da cidade. Seu cliente também deseja que na solução ele possa visualizar esses shoppings centers de forma clara num mapa georreferenciado e também, criar um trajeto para que os fiscais possam seguir um roteiro de fiscalização que otimize a distância percorrida no deslocamento. Os fiscais realizam várias visitas durante o dia, sempre saindo da sede da Prefeitura na Cidade Nova e retornando no final do dia.

## Requisitos
•	Sua solução deverá ser capaz de armazenar o cadastro dos shoppings centers em um banco de dados.

•	Considere a utilização de serviços de mapas como Google Maps, Here, MapBox e etc, para a exibição dos shoppings centers no mapa e os demais serviços de georreferenciamento e geoprocessamento.

•	Cada shopping center deverá ter o seu endereço georreferenciado seguindo o sistema referencial WS84 e as coordenadas obtidas deverão ser armazenadas no cadastro.

•	Para visualização dos shoppings centers no mapa, sua solução deve possuir:
o	Um marcador no mapa da localidade do shopping;
o	O nome do shopping center e;
o	O endereço.

•	Para a criação do trajeto de acordo com o roteiro de fiscalizações é muito importante para o seu cliente, que ele veja a rota no mapa e saiba a ordem de fiscalização para cada shopping center.

## Solução

### Banco de Dados
Para a criação do banco de dados, tabelas e seeds execute o seguinte comando Nuget:
```
PM> Update-Database
```

### Projeto
Toda a aplicação foi desenvolvida em Core 2.1, após a execução do comando acima basta iniciar a aplicação.

### Testes
Os testes unitários formam desenvolvidos utilizando Xunit, para a execução dos mesmos vá ate o painel de testes do Visual Studio e inicie a verificação.

## Observações*
Não utilizei uma tabela para persistir as coordenadas dos shoppings, ao invés disso utilizei a funcionalidade Geocode do Google Maps, cujo a finalidade e receber um endereço e retornar à localidade em coordenadas do mesmo. Assim deixando essa responsabilidade para o front-end.

Mas se caso tivesse que implementar da maneira requisitada utilizaria a mesma funcionalidade Geocode para obter as coordenadas ao digitar o endereço no formulário de cadastro de Shoppings, utilizando um evento onBlur do JavaScript. Assim persistindo as coordenadas em um array JavaScript, e posteriormente junto ao POST de criação de um Shopping enviando o mesmo para o back-end para persistência na tabela coordenadas no banco de dados.
