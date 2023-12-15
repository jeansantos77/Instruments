USE dbFinancialInstruments;
GO

-- Verifica se a procedure existe
IF OBJECT_ID('CategorizeFinancialInstruments', 'P') IS NOT NULL
BEGIN
    -- Se existir, dropa a procedure
    DROP PROCEDURE CategorizeFinancialInstruments;
END;
GO

CREATE PROCEDURE CategorizeFinancialInstruments
AS
BEGIN
    -- Declaração de variáveis
    DECLARE @InstrumentID INT;
    DECLARE @MarketValue DECIMAL(18, 2);
    DECLARE @TypeInstrument VARCHAR(50);

	CREATE TABLE #TempIDs (Id INT);
	
    -- Declaração do Cursor que vai ler todos os Financial Instruments que ainda não foram processados
    DECLARE InstrumentCursor CURSOR FOR
        SELECT Id, MarketValue, TypeInstrument 
		FROM FinancialInstruments 
		WHERE DateProcessed IS NULL;

    -- Abertura do Cursor
    OPEN InstrumentCursor;

    -- Inicialização do Fetch
    FETCH NEXT FROM InstrumentCursor INTO @InstrumentID, @MarketValue, @TypeInstrument;

    -- Loop através dos registros
    WHILE @@FETCH_STATUS = 0
    BEGIN
	    -- Armazena os ID's que estão sendo lidos para depois mostrar o resultado final
	    INSERT INTO #TempIDs (Id) VALUES (@InstrumentID);

		DECLARE @FindType INT;
		DECLARE @NameCategory VARCHAR(50) = NULL;

		-- Verifica se existe no banco de dados esse Type
	    SELECT @FindType = 1 from TypeInstruments WHERE [Name] = @TypeInstrument;

		-- Se não houver registros, salva a categoria como NOT FOUND para mostrar para o usuário que falta essa inserção no banco de dados
		IF @FindType = 0
		BEGIN
			SET @NameCategory = @TypeInstrument + ' not found!';
		END
		ELSE
		BEGIN
		   -- Verifica se a categoria é Medium
		   SELECT @NameCategory = [Name] FROM Categories WHERE StartValue <= @MarketValue AND EndValue >= @MarketValue;

		   IF @NameCategory IS NULL
		   BEGIN
		      -- Se não for, verifica se é Low 
			  SELECT TOP 1 @NameCategory = [Name] FROM Categories WHERE StartValue > @MarketValue AND EndValue = 0;
		   END

		   IF @NameCategory IS NULL
		   BEGIN
		      -- Senão verifica se é High
			  SELECT TOP 1 @NameCategory = [Name] FROM Categories WHERE StartValue < @MarketValue AND EndValue = 0 ORDER BY StartValue DESC;
		   END
		END

		-- Atualiza a tabela com a categoria encontrada e salva a data do processamento
		UPDATE FinancialInstruments
		SET CategoryName = @NameCategory,
		    DateProcessed = GETDATE()
		WHERE Id = @InstrumentID

        FETCH NEXT FROM InstrumentCursor INTO @InstrumentID, @MarketValue, @TypeInstrument;
    END

    CLOSE InstrumentCursor;
    DEALLOCATE InstrumentCursor;

    -- Exibição as categorias
    SELECT CategoryName 
	FROM FinancialInstruments
	WHERE Id IN (SELECT Id FROM #TempIDs);

	-- Drop da tabela temporária após uso
    DROP TABLE #TempIDs;
END;