## EXPLICA��ES
1. Criada uma API disponibilizando endpoints para CRUD das Categorias e tamb�m dos Tipos de Instrumentos, al�m disso tem um endpoint respons�vel por retornar 
   as categorias conforme os instrumentos passados. Caso o Type n�o esteja cadastrado no banco de dados o retorno ser� o "[Nome do Tipo] not found." 
2. Desenvolvido seguindo o padr�o Domain Driven Design
3. Usado o padr�o Repository
4. Foram criados alguns testes unit�rios
4. Na camada Infra.Data tem uma pasta Scripts contendo os scripts da Quest�o 2
5. No projeto Instrument.API tem uma pasta chamada Evidencias onde consta as imagems do resultado da execu��o da API e da procedure
6. No projeto Instrument.API tem uma pasta chamada Parametros onde consta um txt com o body usado para executar o endpoint respons�vel por retornar as categorias