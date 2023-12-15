## EXPLICAÇÕES
1. Criada uma API disponibilizando endpoints para CRUD das Categorias e também dos Tipos de Instrumentos, além disso tem um endpoint responsável por retornar 
   as categorias conforme os instrumentos passados. Caso o Type não esteja cadastrado no banco de dados o retorno será o "[Nome do Tipo] not found." 
2. Desenvolvido seguindo o padrão Domain Driven Design
3. Usado o padrão Repository
4. Foram criados alguns testes unitários
4. Na camada Infra.Data tem uma pasta Scripts contendo os scripts da Questão 2
5. No projeto Instrument.API tem uma pasta chamada Evidencias onde consta as imagems do resultado da execução da API e da procedure
6. No projeto Instrument.API tem uma pasta chamada Parametros onde consta um txt com o body usado para executar o endpoint responsável por retornar as categorias